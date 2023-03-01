import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { State } from '../state.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(public State: State, private http: HttpClient, private router: Router, private authService: AuthService) { }

  ngOnInit() {
    let t = this;
  }

  public Login() {
    let t = this;
    this.authService.login();
    t.State.SetUser();
    t.router.navigate(['home']);
  }
}

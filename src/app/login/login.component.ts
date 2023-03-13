import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { State } from '../state.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { AuthenticateUserRequest, AuthenticateUserResponse } from 'src/model/apitypes';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(public State: State, private http: HttpClient, private router: Router, private authService: AuthService) { }
  public login_req = <AuthenticateUserRequest>{};

  public Login() {
    let t = this;
    console.log("próba logowania");
    console.log(t.login_req.Email);
    console.log(t.login_req.Password);
    t.http.post<AuthenticateUserResponse>(t.State.webApiUrl + t.State.webApiCommandAccountLogin, t.login_req).subscribe(res => {
      console.log(res);
    }
    )

    this.authService.login();
    t.State.SetUser();
    t.router.navigate(['home']);
  }
}

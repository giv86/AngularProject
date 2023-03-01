import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { State } from '../state.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(public State: State, private http: HttpClient, private router: Router) { }

  public Register() {

  }

}

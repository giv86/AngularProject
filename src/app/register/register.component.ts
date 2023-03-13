import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { State } from '../state.service';
import { Router } from '@angular/router';
import { RegisterNewUserRequest } from 'src/model/apitypes';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(public State: State, private http: HttpClient, private router: Router) { }

  public register_req = <RegisterNewUserRequest>{};

  public Register() {
    let t = this;
    console.log(t.register_req.Email);
    t.http.post<boolean>(t.State.webApiUrl + t.State.webApiCommandAccountRegisterUser, t.register_req).subscribe(res => {
      console.log(res);
    }
    )
  };
}

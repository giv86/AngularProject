import { Injectable } from '@angular/core';
import { DBOUsers } from '../model/apitypes'

@Injectable({
  providedIn: 'root'
})
export class State {
  public IsTopMenuVisible: boolean = false;
  public IsAdmin: boolean = false;

  public webApiUrl: string = 'https://localhost:7116/api/';

  public webApiCommandAccountRegisterUser: string = "Account/RegisterUser";
  public webApiCommandAccountModifyUser: string = "";
  public webApiCommandAccountRemoveUser: string = "";
  public webApiCommandAuthenticate: string = "";
  public webApiCommandAccountLogin: string = "Authentication/Login";

  public User?: DBOUsers;

  constructor() { }

  ngOnInit() {
  }

  public SetUser() {
    let t = this;
    this.IsTopMenuVisible = true;
    this.IsAdmin = false;
  }
}

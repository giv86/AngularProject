import { Injectable } from '@angular/core';
import { DBOUsers } from '../model/apitypes'

@Injectable({
  providedIn: 'root'
})
export class State {
  public IsTopMenuVisible: boolean = false;
  public IsAdmin: boolean = false;

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

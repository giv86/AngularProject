import { HttpClient } from '@angular/common/http';
import { Component, ViewEncapsulation } from '@angular/core';
import { State } from './state.service';
import { RouterModule, Routes } from '@angular/router';
import { Navigation } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  constructor(private State: State, private router: RouterModule) {
    this.title = 'AngularProject';
  }

  public title: string;

  get topMenuVisible(): boolean {
    return this.State.IsTopMenuVisible;
  }
}

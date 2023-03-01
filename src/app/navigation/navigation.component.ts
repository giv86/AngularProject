import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { State } from '../state.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {

  constructor(public State: State, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    let t = this;
  }

}

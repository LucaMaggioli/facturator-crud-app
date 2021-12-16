import { Component } from '@angular/core';
import {UserService} from "./login/services/user.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(public _userService:UserService) {
  }

  logOut(){
    this._userService.logOutUser();
  }

  logIn(){

  }

  title = 'facturator';
}

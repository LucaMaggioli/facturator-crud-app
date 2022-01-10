import { Component, OnInit } from '@angular/core';
import {FormControl} from "@angular/forms";
import {VendorService} from "../../services/vendor.service";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hidePassword = true;
  usernameControl = new FormControl('');
  passwordControl = new FormControl('');

  constructor(
    private router: Router,
    private _vendorService:VendorService,
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
  }

  login(){
    this._authService.logInVendor(this.usernameControl.value, this.passwordControl.value);
    this.router.parseUrl('vendor/home')
  }
  hidePasswordToggle(){
    this.hidePassword = !this.hidePassword;
  }
}

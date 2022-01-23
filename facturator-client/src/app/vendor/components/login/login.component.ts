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

  async login(){
    await this._authService.logInVendor(this.usernameControl.value, this.passwordControl.value).then((res)=>{
      console.log("loginVendor Method of authService return a Observable with result = " + res);
      if (res){
        // HOW TO CALL A ROUTE WITH QUERYPARAMS SEE: https://angular-training-guide.rangle.io/routing/query_params  AND  https://angular.io/guide/router#accessing-query-parameters-and-fragments
        // this.router.navigate(['vendor'], {queryParams: {isUserLogged: this._authService.isUserLogged()}}).then(()=>{});
      }
    });
  }

  singin(){
    this._authService.singinVendor(this.usernameControl.value, this.passwordControl.value).then(()=>{
      console.log("after sing in");
      this.router.parseUrl('vendor');
    });
  }

  hidePasswordToggle(){
    this.hidePassword = !this.hidePassword;
  }
}

import { Injectable } from '@angular/core';
import {VendorService} from "./vendor.service";
import {ClientService} from "./client.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser:any;
  isUserLogger:boolean = false;

  constructor(
    private _vendorService:VendorService,
    private _clientService:ClientService
  ) { }

  logInVendor(username:string, password:string){
    this._vendorService.logIn(username, password).then(result=>{
      console.log("auth service");
      console.log(result);
      //if result != error then set current user as user returned from api
      this.currentUser = result;
      localStorage.userLogged = this.currentUser;
    });
  }
}

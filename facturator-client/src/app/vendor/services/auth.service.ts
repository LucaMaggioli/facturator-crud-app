import { Injectable } from '@angular/core';
import {VendorService} from "./vendor.service";
import {ClientService} from "./client.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser:any = null;
  isUserLogger:boolean = false;

  constructor(
    private _vendorService:VendorService,
    private _clientService:ClientService
  ) { }

  logInVendor(username:string, password:string){
    this._vendorService.logIn(username, password).then(vendor=>{
      console.log("auth service");
      console.log(vendor);
      if (vendor !== "Password or username incorrect"){
        this.isUserLogger = true;
        this.currentUser = vendor;
        //localStorage.currentUser = vendor;
        //localStorage.isUserLogged = true;
      }
      else {
        console.log("vendor = undefined, user not logged");
        this.isUserLogger = false;
      }
      //if result != error then set current user as user returned from api
      //this.currentUser = result;
      //localStorage.userLogged = this.currentUser;
    });
  }

  logOut(){
    localStorage.removeItem("currentUser");
    localStorage.removeItem("isUserLogged");

    this.isUserLogger = false;
  }
}

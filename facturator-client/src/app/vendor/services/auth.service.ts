import { Injectable } from '@angular/core';
import {VendorService} from "./vendor.service";
import {ClientService} from "./client.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser:any;

  constructor(
    private _vendorService:VendorService,
    private _clientService:ClientService
  ) { }

  logInVendor(username:string, password:string){
    this._vendorService.logIn(username, password).then(result=>{
      console.log("in login component");
      console.log(result);
      this.currentUser = result;
      localStorage.userLogged = result;
    });
  }
}

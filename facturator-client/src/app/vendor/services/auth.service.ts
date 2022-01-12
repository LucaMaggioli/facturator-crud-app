import { Injectable } from '@angular/core';
import {VendorService} from "./vendor.service";
import {ClientService} from "./client.service";
import {env} from "./config";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser:any = null;
  isUserLogger:boolean = localStorage.userLogged;

  constructor(
    private router:Router,
    private _vendorService:VendorService,
    private _clientService:ClientService
  ) { }

  async logInVendor(username:string, password:string){
    await fetch(env.APIURL + '/vendor/login', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify({
        'username': username,
        'password': password
      })
    }).then(response=>{
      if (response.status === 502){
        console.log("Password or Username Incorrect")
      }
      if (response.status === 200){
        response.json().then(result=> {
          console.log("login success")
          this.setUserLogged(result);
          this.router.navigate(['vendor/home/info']);
        });
      }
    });
  }

  async singinVendor(username:string, password:string){
    return await fetch(env.APIURL + '/vendor/singin', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify({
        'username': username,
        'password': password
      })
    }).then((response) => {
      if(response.status === 502){
        console.log("ERROR: "+ response.status);
        response.json().then(result=> {
          console.log(result);
        });
      }
      if(response.status === 501){
        console.log("ERROR: "+ response.status);
        response.json().then(result=> {
          console.log(result);
        });
      }
      if(response.status === 200){
        response.json().then(vendorData=> {
          console.log("Singin success!");
          this.setUserLogged(vendorData);
          this.router.navigate(['/vendor/home/info']);
        });
      }
    });
  }

  private setUserLogged(userLogged:any){
    console.log("setting user Logged")
    console.log(userLogged);
    this.isUserLogger = true;
    this.currentUser = userLogged;
    localStorage.userLogged = true;
    localStorage.currentUserId = userLogged.id;
    localStorage.currentUserJson = JSON.stringify(userLogged);
    localStorage.currentUser = userLogged;
  }

  logOut(){
    localStorage.removeItem("userLogged");
    localStorage.removeItem("currentUserId");
    localStorage.removeItem("currentUser");
    this.currentUser = null;
    this.isUserLogger = false
    console.log("logot, redirecting to login")
    this.router.navigate(['/vendor/login']).then(r => console.log(r));
  }
}

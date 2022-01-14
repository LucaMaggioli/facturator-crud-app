import { Injectable } from '@angular/core';
import {VendorService} from "./vendor.service";
import {env} from "./config";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isUserLogger:boolean = localStorage.userLogged;

  constructor(
    private router:Router,
  ) { }

  isUserLogged(){
    return localStorage.getItem('userLogged');
  }
  getUserLoggedId(){
    return localStorage.getItem('currentUserId')
  }

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
    localStorage.userLogged = true;
    localStorage.currentUserId = userLogged.id;
  }

  logOut(){
    localStorage.removeItem("userLogged");
    localStorage.removeItem("currentUserId");
    this.router.navigate(['/vendor/home/login']).then(r => console.log(r));
  }
}

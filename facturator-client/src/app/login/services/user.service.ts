import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  isUserLogged = !!localStorage.userLogged;

  constructor() { }

  login(){

  }

  logInUser(username:string, password:string){
    //call the api to ask the DB if the username and password are right
    if(username === "luca" && password === "admin" ){
      this.isUserLogged = true;
      localStorage.userLogged = "luca"
      console.log("User logged in succesfully");
      return true;
    }
    else{
      return false
    }
  }

  logOutUser(){
    if (localStorage.userLogged){
      localStorage.removeItem("userLogged");
      this.isUserLogged = false;
      console.log("User logged OUT succesfully");
    }
  }

}

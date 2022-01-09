import { Injectable } from '@angular/core';
import {env} from "./config";

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  constructor() { }

  public async singIn(username:string, password:string){
    return await fetch(env.APIURL + '/vendor/login', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify({
        'username': username,
        'password': password
      })
    }).then((response) => response.json().then(result=> console.log(result)));
  }

}

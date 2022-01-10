import { Injectable } from '@angular/core';
import {env} from "./config";

@Injectable({
  providedIn: 'root'
})

/// This is the service that manages all the API calls for the endpoint {URL}/vendor/*
export class VendorService {

  constructor() { }

  public async logIn(username:string, password:string){
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
    }).then((response) => response.json()/*
      {
      if (response.status === 502){
        return Promise.reject(response);
      }
      else {
        return Promise.resolve(response);
      }
    }*/
    );
  }

}

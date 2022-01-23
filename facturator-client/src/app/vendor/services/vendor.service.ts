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
    }).then((response) => response.json()
    );
  }

  singIn(username:string, password:string) {
  }

  async GetVendorInfo(id:number){
    console.log("Try to get info about Vendor with id: "+id);
    return await fetch(env.APIURL + '/vendor/' + id, {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      }
    }).then(response=>{
      if (response.status !== 200){
        console.log("error while trying to retrieve Data about vendor with id "+id);
        return response.json();
      }
      else {
        console.log("result of api call /vendor/{id} [GET] is:");
        console.log(response);
        return response.json();
      }
    });
  }

  UpdateVendor(param: { firstName: any; lastName: any; companyName: any }) {
    console.log("fetch the api to patch")
    console.log(param)
    fetch(env.APIURL + '/vendor/' + localStorage.getItem("currentUserId"), {
      method: 'PATCH',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify(param)
    }).then(response=>{
      if(response.status !== 200){
        console.log("Error while updating the vendor")
      }
      else {
        response.json().then(result=> {
          console.log("success updating vendor");
          console.log(result);
        })
      }
    })
  }
}

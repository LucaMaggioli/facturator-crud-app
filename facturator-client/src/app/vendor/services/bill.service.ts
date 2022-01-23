import { Injectable } from '@angular/core';
import {env} from "./config";

@Injectable({
  providedIn: 'root'
})
export class BillService {

  constructor() { }

  public getVendorBills(id:number){
    return fetch(env.APIURL + `/vendor/${id}/bills`, {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    }).then((response) =>{
      if (response.ok){
        return response.json();
      }
      else {
        throw new Error(response.statusText);
      }
    });
  }
}

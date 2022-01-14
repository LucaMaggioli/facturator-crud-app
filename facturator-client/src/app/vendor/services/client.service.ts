import { Injectable } from '@angular/core';
import {AuthService} from "./auth.service";
import {env} from "./config";
import {ArticleDto} from "../../shared/models/articleDto";
import {ClientDto} from "../dtos/ClientDto";

@Injectable({
  providedIn: 'root'
})

/// This is the service that manages all the API calls for the endpoint {URL}/client/*
export class ClientService {

  constructor(
    private _authService:AuthService
  ) { }

  public async getClientsForLoggedVendor(){
    return await fetch(env.APIURL + `/vendor/${this._authService.getUserLoggedId()}/clients`, {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    }).then((response) => response.json());
  }

  public async addClientToVendor(client:ClientDto, id:number){
    return await fetch(env.APIURL + `/vendor/${id}/client`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify({
        "firstName": client.firstName,
        "lastName": client.lastName,
        "address": client.address,
        "email": client.email,
      })
    }).then((response) => response.json());
  }
}

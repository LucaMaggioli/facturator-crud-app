import { Injectable } from '@angular/core';
import {AuthService} from "./auth.service";
import {env} from "./config";
import {ArticleDto} from "../../shared/models/articleDto";
import {ClientDto} from "../dtos/ClientDto";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

/// This is the service that manages all the API calls for the endpoint {URL}/client/*
export class ClientService {

  constructor(
    private _authService:AuthService,
    private http:HttpClient
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

  public deleteClient(id:number): Promise<ClientDto>{
    //return new Promise<ClientDto>
    return new Promise<ClientDto>((resolve) => {
      this.http.delete<ClientDto>(env.APIURL + `/client/${id}`)
      .subscribe(
        (result:ClientDto)=> {
        console.log("detele client")
        console.log(result)
        resolve(result);
      }, error=>{
        console.log(error);
      })
    });
  }

  getItems(id:number): Promise<ClientDto> {
    return new Promise<ClientDto>((resolve) => {
      this.http.delete<ClientDto>(env.APIURL + `/client/`+ id).subscribe(
        (result: ClientDto) => {
          // toto = result;
          resolve(result);
        },
        (error) => {
          console.error(error);
        }
      );
    });
  }
}

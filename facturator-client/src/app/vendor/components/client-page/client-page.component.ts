import { Component, OnInit } from '@angular/core';
import {ClientService} from "../../services/client.service";
import {ClientDto} from "../../dtos/ClientDto";
import {FormControl, Validators} from "@angular/forms";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit {

  clients:ClientDto [] = [];

  clientFirstName = new FormControl('', [Validators.required]);
  clientLastName = new FormControl('', [Validators.required]);
  clientAddress = new FormControl('', [Validators.required]);
  clientEmail = new FormControl('', [Validators.required, Validators.email]);

  constructor(
    private _clientService:ClientService,
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
    //Getting clients from api by ClientService
    this._clientService.getClientsForLoggedVendor().then(clients=>{
      console.log(`Clients of vendor logged are ${clients}`)
      this.clients = clients;
    });
  }

  addClient(){
    let clientToAdd = new ClientDto(this.clientFirstName.value, this.clientLastName.value, this.clientAddress.value, this.clientEmail.value)
    this._clientService.addClientToVendor(clientToAdd, this._authService.getUserLoggedId())
      .then(addedClient=>{
        console.log("Added client is: ")
        console.log(addedClient)
        this.clients.push(addedClient);
      })
      .catch(error=>{
        console.log(error);
      });
  }

  deleteClient(id:number){
    console.log("deleting the client with ID: " + id);
    this._clientService.deleteClient(id).then(()=>{
      this.clients.forEach(client=>{
        if(client.id == id){
          this.clients.splice(this.clients.indexOf(client),1);
        }
      });
    })
      .catch((error)=>{
        console.log(error);
      });
  }

  updateClient(client: ClientDto) {
    this._clientService.updateClient(client)
      .then((result)=>{
        console.log("Client successfully updated");
        console.log(result);
      })
      .catch((error)=>console.log(error));
  }
}

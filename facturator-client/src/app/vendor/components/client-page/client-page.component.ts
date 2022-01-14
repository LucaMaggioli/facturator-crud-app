import { Component, OnInit } from '@angular/core';
import {ClientService} from "../../services/client.service";
import {ClientDto} from "../../dtos/ClientDto";
import {EmailValidator, FormControl, Validators} from "@angular/forms";
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
  cliAddress = new FormControl('', [Validators.required]);
  cliEmail = new FormControl('', [Validators.required, Validators.email]);

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
    let clientToAdd = new ClientDto(this.clientFirstName.value, this.clientLastName.value, this.cliAddress.value, this.cliEmail.value)
    this._clientService.addClientToVendor(clientToAdd, parseInt(<string>this._authService.getUserLoggedId()))
  }

}

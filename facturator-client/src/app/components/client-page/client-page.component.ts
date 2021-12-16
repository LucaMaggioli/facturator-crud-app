import { Component, OnInit } from '@angular/core';
import {Client} from "../../shared/models/client";
import {FacturatorApiCallService} from "../../services/facturator-api-call.service";

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit {

  clients:any[] = [];
  constructor(private _dataService: FacturatorApiCallService) { }

  ngOnInit(): void {
    this.getClients();
  }

  addClient(newClient:Client){
    this._dataService.addClient(newClient.name!, newClient.address!, newClient.email!);
    this.clients.push(newClient)
  }

  getClients(){
    this._dataService.getCLients().then(data=>{
      let clientsDto = [];
      for (let client of data){
        console.log(client);
        clientsDto.push(new Client(client['Name'], client['Address'], client['Email'], client['Id']))
      }
      this.clients = clientsDto;
    })
  }

}

import { Component, OnInit } from '@angular/core';
import { ClientDto } from '../../shared/models/ClientDto';
import { FacturatorApiCallService } from '../../services/facturator-api-call.service';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css'],
})
export class ClientPageComponent implements OnInit {
  clients: ClientDto[] = [];
  constructor(
    private _clientService: ClientService,
    private _dataService: FacturatorApiCallService
  ) {}

  ngOnInit(): void {
    this.getClients();
  }

  addClient(clientToAdd: ClientDto) {
    console.log(clientToAdd);
    this._clientService.addClient(clientToAdd).then((client) => {
      this.clients.push(client);
    });
  }

  getClients() {
    this.clients = this._clientService.getClients();
  }
}

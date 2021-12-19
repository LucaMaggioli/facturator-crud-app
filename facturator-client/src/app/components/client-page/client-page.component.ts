import { Component, OnInit } from '@angular/core';
import { ClientDto } from '../../shared/models/ClientDto';
import { FacturatorApiCallService } from '../../services/facturator-api-call.service';

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css'],
})
export class ClientPageComponent implements OnInit {
  clients: ClientDto[] = [];
  constructor(private _dataService: FacturatorApiCallService) {}

  ngOnInit(): void {
    this.getClients();
  }

  addClient(newClient: ClientDto) {
    this._dataService.addClient(
      newClient.name!,
      newClient.address!,
      newClient.email!
    );
    this.clients.push(newClient);
  }

  getClients() {
    this._dataService.getCLients().then((data) => {
      let clientsDto = [];
      for (let client of data) {
        clientsDto.push(
          new ClientDto(client.name, client.address, client.email)
        );
      }
      this.clients = clientsDto;
    });
  }
}

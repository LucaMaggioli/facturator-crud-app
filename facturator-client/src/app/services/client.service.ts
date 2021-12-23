import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ClientDto } from '../shared/models/ClientDto';
import { FacturatorApiCallService } from './facturator-api-call.service';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  backendURL: string = 'https://localhost:44335/api';

  constructor(private _facturatorApiCallService: FacturatorApiCallService) {}

  getClients() {
    let clients: any[] = [];
    fetch(this.backendURL + '/client/all', { method: 'GET' })
      .then((response) => response.json())
      .then((result) => {
        console.log(result);
        for (let clientDto of result) {
          clients.push(clientDto);
        }
      });

    return clients;
  }

  async addClient(clientToAdd: ClientDto) {
    let addedClient;
    let body = JSON.stringify({
      name: clientToAdd.name,
      address: clientToAdd.address,
      email: clientToAdd.email,
    });

    return await fetch(this.backendURL + '/client', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: body,
    }).then((response) => response.json());
  }
}

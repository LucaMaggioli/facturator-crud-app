import { Injectable } from '@angular/core';
import { ClientDto } from '../shared/models/ClientDto';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  backendURL: string = 'https://localhost:44335/api';

  constructor() {}

  getClients() {
    let clients: any[] = [];
    fetch(this.backendURL + '/client/all', { method: 'GET' })
      .then((response) => response.json())
      .then((data) => {
        for (let item of data) {
          clients.push(
            new ClientDto(item['Name'], item['Address'], item['Email'])
          );
        }
      });
    return clients;
  }
}

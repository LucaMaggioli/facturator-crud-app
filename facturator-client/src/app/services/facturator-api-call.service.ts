import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ClientDto } from '../shared/models/ClientDto';

@Injectable({
  providedIn: 'root',
})
export class FacturatorApiCallService {
  backendURL: string = 'https://localhost:44335/api';

  constructor(private http: HttpClient) {}

  async getCLients() {
    return await fetch(this.backendURL + '/client/all', { method: 'GET' }).then(
      (response) => response.json()
    );
  }

  async callApi(url: string, options: {}) {
    return await fetch(url, options).then((response) => response.json());
  }

  async addClient(clientToAdd: ClientDto) {
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

  async getArticles() {
    return await fetch(this.backendURL + '/article/all', {
      method: 'GET',
    }).then((response) => response.json());
  }
}

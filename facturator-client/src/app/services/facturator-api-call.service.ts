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

  async addClient(name: string, address: string, email: string) {
    let body = JSON.stringify({ name: name, address: address, email: email });
    console.log(body);
    return await fetch(this.backendURL + '/client/add', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: body,
    }).then((data) => console.log(data));
  }
  async getArticles() {
    return await fetch(this.backendURL + '/article/', { method: 'GET' }).then(
      (response) => response.json()
    );
  }
}

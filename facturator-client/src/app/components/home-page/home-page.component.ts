import { Component, OnInit } from '@angular/core';
import { FacturatorApiCallService } from '../../services/facturator-api-call.service';
import { Article } from '../../shared/models/article';
import { ClientDto } from '../../shared/models/ClientDto';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit {
  articles: any[] = [];
  clients: any[] = [];

  constructor(private _dataService: FacturatorApiCallService) {}

  ngOnInit(): void {
    this.getArticles();
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

  getArticles() {
    this._dataService.getArticles().then((data) => {
      for (let item of data) {
        // @ts-ignore
        this.articles.push(
          new Article(
            item['Id'],
            item['Name'],
            item['PhotoUrl'],
            item['Price'],
            item['description']
          )
        );
      }
      console.log('articles:');
      console.log(this.articles);
    });
  }

  getClients() {
    this._dataService.getCLients().then((data) => {
      let clientsDto = [];
      for (let client of data) {
        console.log(client);
        clientsDto.push(
          new ClientDto(
            client['Name'],
            client['Address'],
            client['Email'],
            client['Id']
          )
        );
      }
      this.clients = clientsDto;
    });
  }
}

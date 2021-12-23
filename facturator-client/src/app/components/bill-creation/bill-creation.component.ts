import { Component, Input, OnInit } from '@angular/core';
import { ClientDto } from '../../shared/models/ClientDto';
import { Bill } from '../../shared/models/bill';
import { Article } from '../../shared/models/article';
import { auditTime } from 'rxjs/operators';
import { ArticleService } from '../../services/articles-service.service';
import { ClientService } from '../../services/client.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-bill-creation',
  templateUrl: './bill-creation.component.html',
  styleUrls: ['./bill-creation.component.css'],
})
export class BillCreationComponent implements OnInit {
  @Input() clients: any;
  @Input() articles: any;

  bill: Bill = new Bill();

  step = 0;

  articlesSelected: boolean = false;
  clientSelected: boolean = false;
  date = new FormControl(new Date());

  constructor(
    private _ArticleService: ArticleService,
    private _ClientService: ClientService
  ) {}

  ngOnInit() {
    this.clients = this._ClientService.getClients();
    this.articles = this._ArticleService.getArticles();
  }

  setBillClient(client: ClientDto) {
    this.bill.client = client;
    this.clientSelected = true;
    this.nextStep();
  }

  addRemoveArticleToBill(article: Article) {
    let index = this.bill.articles.indexOf(article);
    if (index > -1) {
      this.bill.articles.splice(index, 1);
    } else {
      this.bill.articles.push(article);
    }
    this.articlesSelected = this.bill.articles.length > 0;
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  saveBill() {
    //do here an api call to save the bill in the backend
  }
}

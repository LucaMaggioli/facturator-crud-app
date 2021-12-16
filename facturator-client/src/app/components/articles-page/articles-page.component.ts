import { Component, OnInit } from '@angular/core';
import {FacturatorApiCallService} from "../../services/facturator-api-call.service";
import {ArticlesServiceService} from "../../services/articles-service.service";
import {Article} from "../../shared/models/article";

@Component({
  selector: 'app-articles-page',
  templateUrl: './articles-page.component.html',
  styleUrls: ['./articles-page.component.css']
})
export class ArticlesPageComponent implements OnInit {

  articles:any[] = [];
  dataLoaded:boolean = false;
  constructor(
    private _dataService: FacturatorApiCallService,
    private _articleService: ArticlesServiceService
  ) { }

  ngOnInit(){
    this.articles = this._articleService.getArticles();
    this.dataLoaded = true;
  }

  saveArticle(newArticle:Article){
    this._articleService.saveArticle(newArticle);
    this.articles.push(newArticle);
  }

}

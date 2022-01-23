import { Component, OnInit } from '@angular/core';
import { FacturatorApiCallService } from '../../services/facturator-api-call.service';
import { ArticleService } from '../../services/articles-service.service';
import { ArticleDto } from '../../shared/models/articleDto';

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.css'],
})
export class ArticlesPageComponent implements OnInit {
  articles: any[] = [];
  dataLoaded: boolean = false;
  constructor(
    private _dataService: FacturatorApiCallService,
    private _articleService: ArticleService
  ) {}

  ngOnInit() {
    this.articles = this._articleService.getArticles();
    this.dataLoaded = true;
  }

  saveArticle(newArticle: ArticleDto) {
    this._articleService.saveArticle(newArticle);
    this.articles.push(newArticle);
  }
}

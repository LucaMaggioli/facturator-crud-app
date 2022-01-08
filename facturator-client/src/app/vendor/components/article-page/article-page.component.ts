import { Component, OnInit } from '@angular/core';
import {ArticleService} from "../../services/article.service";

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.css']
})
export class ArticlePageComponent implements OnInit {

  articles:any[] = []
  constructor(private articleService:ArticleService) { }

  ngOnInit(): void {
    this.articleService.getArticles().then(a => {console.log(a); this.articles = a});
  }

}

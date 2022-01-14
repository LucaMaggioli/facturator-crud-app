import { Component, OnInit } from '@angular/core';
import {ArticleService} from "../../services/article.service";
import {FormControl} from "@angular/forms";
import {ArticleDto} from "../../../shared/models/articleDto";

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.css']
})
export class ArticlePageComponent implements OnInit {

  articles:ArticleDto[] = []
  constructor(private articleService:ArticleService) { }

  name = new FormControl('');
  photoUrl = new FormControl('');
  price = new FormControl('');
  description = new FormControl('');

  ngOnInit(): void {
    this.articleService.getArticlesForLoggedVendor().then(a => {console.log(a); this.articles = a});
  }

  addArticle(newArticle:ArticleDto){
    this.articleService.addArticleForVendor(newArticle)
      .then(result => {
        console.log("article added");
        console.log(result);
      }).catch(error=>{
      console.log(error);
    });
  }

}

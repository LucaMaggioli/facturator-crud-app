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
  constructor(private _articleService:ArticleService) { }

  name = new FormControl('');
  photoUrl = new FormControl('');
  price = new FormControl('');
  description = new FormControl('');

  ngOnInit(): void {
    this._articleService.getArticlesForLoggedVendor().then(a => {
      console.log(a);
      this.articles = a;
    });
  }

  addArticle(newArticle:ArticleDto){
    this._articleService.addArticleForVendor(newArticle)
      .then(result => {
        console.log("article added");
        console.log(result);
        this.articles.push(result);
      }).catch(error=>{
        console.log(error);
      });
  }

  removeArticle(id:number){
    this._articleService.removeArticle(id)
      .then(result=>{
        console.log("article deleted with Id: " + result.id);
        this.deleteArticleFromArticles(result.id);
      }).catch(error=>{
      console.log(error);
    });
  }

  deleteArticleFromArticles(_id:number){
    this.articles.forEach(article=>{
      if(article.id == _id){
        this.articles.splice(this.articles.indexOf(article),1);
      }
    });
  }

}

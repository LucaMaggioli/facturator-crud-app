import { Component, OnInit } from '@angular/core';
import {ArticleService} from "../../services/article.service";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.css']
})
export class ArticlePageComponent implements OnInit {

  articles:any[] = []
  constructor(private articleService:ArticleService) { }

  name = new FormControl('');
  photoUrl = new FormControl('');
  price = new FormControl('');
  description = new FormControl('');

  ngOnInit(): void {
    this.articleService.getArticlesForLoggedVendor().then(a => {console.log(a); this.articles = a});
  }

  addArticle(){
    let intPrice = parseInt(<string>this.price.value);
    this.articleService.addArticleForVendor(this.name.value, this.photoUrl.value, intPrice, this.description.value)
      .then(result => {
        console.log("article added");
        console.log(result);
      }).catch(error=>{
      console.log(error);
    });
  }

}

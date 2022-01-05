import { Injectable } from '@angular/core';
import { Article } from '../shared/models/article';
import { FacturatorApiCallService } from './facturator-api-call.service';

@Injectable({
  providedIn: 'root',
})
export class ArticleService {
  backendURL: string = 'https://localhost:44335/api';

  constructor(private _facturatorApiCallService: FacturatorApiCallService) {}

  getArticles() {
    let articles: any[] = [];
    this._facturatorApiCallService.getArticles().then((data) => {
      for (let article of data) {
        console.log(article);
        articles.push(
          new Article(
            article['name'],
            article['price'],
            article['photoUrl'],
            article['description'],
            article['id']
          )
        );
      }
    });

    return articles;
    //return articles;
  }

  saveArticle(newArticle: Article) {
    let updatedArticlesList;
    console.log(`saving new article`);
    let body = JSON.stringify({
      name: newArticle.name,
      photoUrl: newArticle.photo,
      price: newArticle.price,
      description: newArticle.description,
    });
    console.log(body);
    return fetch(this.backendURL + '/article', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: body,
    }).then((data) => {
      console.log(data);
    });
  }
}

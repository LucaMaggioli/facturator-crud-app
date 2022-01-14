import { Injectable } from '@angular/core';
import {ArticleDto} from "../shared/models/articleDto";

@Injectable({
  providedIn: 'root'
})
export class ArticleDtoService {

  constructor() { }

  public dataToArticle(dtoArticle: any):ArticleDto{
    let article = new ArticleDto(dtoArticle['id'],dtoArticle['price'],dtoArticle['name'],dtoArticle['photoUrl'], dtoArticle['description']);
    return article;
  }
}

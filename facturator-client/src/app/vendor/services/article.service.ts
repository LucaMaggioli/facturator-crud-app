import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Article} from "../../shared/models/article";
import {AuthService} from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  backendURL: string = 'https://localhost:44335/api';
  constructor(private _authService:AuthService) { }

  public async getArticlesForLoggedVendor(){
    return await fetch(this.backendURL + `/vendor/${this._authService.getUserLoggedId()}/articles`, {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    }).then((response) => response.json());
  }

  public async addArticleForVendor(article:Article){
    return await fetch(this.backendURL + `/vendor/${this._authService.getUserLoggedId()}/article`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify({
        "name": article.name,
        "photoUrl": article.photoUrl,
        "price": article.price,
        "description": article.description,
      })
    }).then((response) => response.json());
  }
}

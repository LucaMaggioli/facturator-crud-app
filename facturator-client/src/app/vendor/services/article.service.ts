import { Injectable } from '@angular/core';
import {ArticleDto} from "../../shared/models/articleDto";
import {AuthService} from "./auth.service";
import {env} from "./config";

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  constructor(
    private _authService:AuthService
  ) { }

  public async getArticlesForLoggedVendor(){
    return await fetch(env.APIURL + `/vendor/${this._authService.getUserLoggedId()}/articles`, {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    }).then((response) => response.json());
  }

  public async addArticleForVendor(article:ArticleDto){
    return await fetch(env.APIURL + `/vendor/${this._authService.getUserLoggedId()}/article`, {
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
    }).then((response)=>{
      if(response.ok) {
        return response.json()
      }
      else{
        throw new Error(response.statusText);
      }
    });
  }
}

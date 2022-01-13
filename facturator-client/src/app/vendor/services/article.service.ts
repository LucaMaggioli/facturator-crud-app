import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  backendURL: string = 'https://localhost:44335/api';
  currentUserId = parseInt(<string>localStorage.getItem('currentUserId'));
  constructor() { }

  public async getArticlesForLoggedVendor(){
    return await fetch(this.backendURL + `/vendor/${this.currentUserId}/articles`, {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
    }).then((response) => response.json());
  }

  public async addArticleForVendor(name:string, photoUrl:string, price:number, description:string){
    return await fetch(this.backendURL + `/vendor/${this.currentUserId}/article`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body:JSON.stringify({
        "name": name,
        "photoUrl": photoUrl,
        "price": price,
        "description": description,
      })
    }).then((response) => response.json());
  }
}

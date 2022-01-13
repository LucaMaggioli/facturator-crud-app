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
}

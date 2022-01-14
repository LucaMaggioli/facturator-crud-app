import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Article} from "../../../shared/models/article";

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  @Input() articles: any = [];

  //@Output() newArticle = new EventEmitter<Article>();

  constructor() { }

  ngOnInit(): void {
  }

  // addArticle(emittedArticle:Article){
  //   this.newArticle.emit(emittedArticle);
  // }
}

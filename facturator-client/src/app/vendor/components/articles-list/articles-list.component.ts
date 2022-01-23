import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ArticleDto} from "../../../shared/models/articleDto";

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  @Input() readOnlyMode:boolean = false;
  @Input() articles: any = [];
  @Output() removeArticle = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
    console.log("articles are:")
    console.log(this.articles);
  }

  emitRemoveArticleFromList(id:number){
    this.removeArticle.emit(id);
  }
}

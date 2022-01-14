import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ArticleDto} from "../../shared/models/articleDto";

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  @Input() articles: ArticleDto[] = [];
  @Input() selectionMode:boolean = false;
  @Output() selUnselectArticle = new EventEmitter<ArticleDto>();

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges():void{
  }

  selUnselArticle(article:ArticleDto){
    this.selUnselectArticle.emit(article);
  }

}

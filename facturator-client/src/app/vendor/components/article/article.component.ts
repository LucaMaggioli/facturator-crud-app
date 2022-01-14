import {Component, Input, OnInit} from '@angular/core';
import {ArticleDto} from "../../../shared/models/articleDto";

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

  @Input() article:ArticleDto = new ArticleDto();
  seeDescription = false;
  constructor() { }

  ngOnInit(): void {
  }

  toggleDescription() {
    this.seeDescription = !this.seeDescription;
  }
}

import {Component, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  @Input() articles: any = [];

  constructor() { }

  ngOnInit(): void {
  }

}

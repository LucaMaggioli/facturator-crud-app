import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormControl} from "@angular/forms";
import {Article} from "../../../shared/models/article";

@Component({
  selector: 'app-add-article',
  templateUrl: './add-article.component.html',
  styleUrls: ['./add-article.component.css']
})
export class AddArticleComponent implements OnInit {

  name = new FormControl('');
  photoUrl = new FormControl('');
  price = new FormControl('');
  description = new FormControl('');
  @Output() newArticle = new EventEmitter<Article>();

  constructor() { }

  ngOnInit(): void {
  }

  addArticle(){
    let intPrice = parseInt(<string>this.price.value);
    this.newArticle.emit(new Article(this.name.value, this.photoUrl.value, intPrice, this.description.value));
  }

  formHasChanged(){
  }

  formChanged = !this.name.dirty && !this.photoUrl.dirty && !this.price.dirty && !this.description.dirty;

}

import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {Article} from "../../../shared/models/article";

@Component({
  selector: 'app-add-article',
  templateUrl: './add-article.component.html',
  styleUrls: ['./add-article.component.css']
})
export class AddArticleComponent implements OnInit {

  name = new FormControl('', [Validators.required]);
  photoUrl = new FormControl('',[Validators.required]);
  price = new FormControl('', [Validators.required, Validators.pattern("[0-9]*\.[0-9]{2}$")]); //Valide que les nombres entiers ou decimals avec 2 aprés la virgule
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

  isValidForm(): boolean {
    return (
      this.name.valid &&
      this.photoUrl.valid &&
      this.price.valid &&
      this.description.valid
    );
  }

  hasFormChanged = !this.name.dirty && !this.photoUrl.dirty && !this.price.dirty && !this.description.dirty;


}
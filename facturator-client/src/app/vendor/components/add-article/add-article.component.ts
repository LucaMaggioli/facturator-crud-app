import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormControl, NgForm, Validators} from "@angular/forms";
import {ArticleDto} from "../../../shared/models/articleDto";
import {IArticleDto} from "../../dtos/i-article-dto";

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

  @Output() newArticle = new EventEmitter<ArticleDto>();
  //model:IArticleDto ;
    /*new class implements IArticleDto {
      description;
      name: string;
      photoUrl: string;
      price: number;
    };*/

  constructor() { }

  ngOnInit(): void {
  }

  addArticle(){
    let intPrice = parseInt(<string>this.price.value);
    this.newArticle.emit(new ArticleDto(this.name.value, this.photoUrl.value, intPrice, this.description.value));
  }

  isValidForm(): boolean {
    return (
      this.name.valid &&
      this.photoUrl.valid &&
      this.price.valid &&
      this.description.valid
    );
  }

  addArticle2(form: NgForm) {
    console.log(form);
    console.log(form.value);
  }
}

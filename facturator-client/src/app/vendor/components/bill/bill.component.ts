import {Component, Input, OnInit} from '@angular/core';
import {IBillDto} from "../../dtos/IBillDto";

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css', './../../global.styles.css']
})
export class BillComponent implements OnInit {

  @Input() bill = {} as IBillDto;
  showArticles: boolean = false;
  constructor() { }

  ngOnInit(): void {
    console.log("bill received in bill component: ")
    console.log(this.bill);
  }

  toggleArticles() {
    this.showArticles = ! this.showArticles;
  }
}

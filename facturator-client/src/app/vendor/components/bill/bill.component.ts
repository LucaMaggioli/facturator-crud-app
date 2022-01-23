import {Component, Input, OnInit} from '@angular/core';
import {IBillDto} from "../../dtos/IBillDto";

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css', './../../global.styles.css']
})
export class BillComponent implements OnInit {

  @Input() bill = {} as IBillDto;
  constructor() { }

  ngOnInit(): void {
    console.log("bill received in bill component: ")
    console.log(this.bill);
  }

}

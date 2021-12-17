import {Component, Input, OnInit} from '@angular/core';
import {Bill} from "../../shared/models/bill";

@Component({
  selector: 'app-bill-confirmer',
  templateUrl: './bill-confirmer.component.html',
  styleUrls: ['./bill-confirmer.component.css']
})
export class BillConfirmerComponent implements OnInit {
  @Input() bill:Bill = new Bill();

  constructor() { }

  ngOnInit(): void {
  }

}

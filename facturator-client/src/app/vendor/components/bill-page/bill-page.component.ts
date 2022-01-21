import { Component, OnInit } from '@angular/core';
import {IBillDto} from "../../dtos/IBillDto";
import {BillService} from "../../services/bill.service";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-bill-page',
  templateUrl: './bill-page.component.html',
  styleUrls: ['./bill-page.component.css']
})
export class BillPageComponent implements OnInit {

  public bills:IBillDto[] = [];

  constructor(
    private _billService:BillService,
    private _authService:AuthService,
  ) { }

  ngOnInit(): void {
    console.log("billpage init")
    let loggedUserId = this._authService.getUserLoggedId();
    this._billService.getVendorBills(loggedUserId)
      .then(result=>{
        this.bills = result;
        console.log(this.bills);
      })
  }

}

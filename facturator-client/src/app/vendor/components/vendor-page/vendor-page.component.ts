import { Component, OnInit } from '@angular/core';
import {VendorService} from "../../services/vendor.service";
import {AuthService} from "../../services/auth.service";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-vendor-page',
  templateUrl: './vendor-page.component.html',
  styleUrls: ['./vendor-page.component.css']
})
export class VendorPageComponent implements OnInit {

  firstName = new FormControl('');
  lastName = new FormControl('');
  companyName = new FormControl('');
  address = new FormControl('');
  email = new FormControl('');
  iban = new FormControl('');

  constructor(
    private _vendorService:VendorService,
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
    this.fillVendorData();
  }

  ngOnChanges():void{
    this.fillVendorData();
  }

  fillVendorData(){
    console.log(this._authService.currentUser)
    console.log(this._authService.currentUser.firstName)
    console.log(this._authService.currentUser["firstName"])
    this._authService.currentUser.firstName !== null ? this.firstName = this._authService.currentUser.firstName : "";
    this._authService.currentUser.lastName !== null ? this.firstName = this._authService.currentUser.lastName : "";
    this._authService.currentUser.companyName !== null ? this.firstName = this._authService.currentUser.companyName : "";
  }

  saveData(){
    console.log("entering saveData");
    this._vendorService.UpdateVendor({"firstName":this.firstName.value,"lastName":this.lastName.value,"companyName":this.companyName.value});
  }

}

import { Component, OnInit } from '@angular/core';
import {VendorService} from "../../services/vendor.service";
import {AuthService} from "../../services/auth.service";
import {FormControl} from "@angular/forms";
import {VendorDto} from "../../dtos/VendorDto";

@Component({
  selector: 'app-vendor-page',
  templateUrl: './vendor-info.component.html',
  styleUrls: ['./vendor-info.component.css']
})
export class VendorInfoComponent implements OnInit {
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

  async fillVendorData(){
    let vendorData:VendorDto = new VendorDto();
    await this._vendorService.GetVendorInfo(parseInt(<string>localStorage.getItem('currentUserId'))).then(result=>{
      vendorData = result;
    });
    vendorData.firstName != null ? this.firstName.setValue(vendorData.firstName) : this.firstName.setValue('');
    vendorData.lastName != null ? this.lastName.setValue(vendorData.lastName) : this.lastName.setValue('');
    vendorData.companyName != null ? this.companyName.setValue(vendorData.companyName) : this.companyName.setValue('');
  }

  saveData(){
    console.log("entering saveData");
    this._vendorService.UpdateVendor({"firstName":this.firstName.value,"lastName":this.lastName.value,"companyName":this.companyName.value});
  }
}



/*
* console.log("from vendor page");
    let fromAuthService = this._authService.currentUser;
    console.log(fromAuthService);

    if(fromAuthService !== null){
      console.log("user is not null so ")
      this.firstName.setValue("firstname");
      //this.firstName.setValue(fromAuthService.firstName);
      this.lastName.setValue("xxxxx lastname");
      //this.lastName.setValue(fromAuthService.lastName);
      this.companyName.setValue("xxx company");
      //this.companyName.setValue(fromAuthService.companyName);
    }
    /*if (loggedUser != null) {
      this.currentUser = new VendorDto(loggedUser['firstName'], loggedUser['lastName'], loggedUser['companyName'])

//    console.log(this._authService.currentUser["firstName"])
this._authService.currentUser.firstName !== null ? this.firstName = this._authService.currentUser["firstName"] : "";
this._authService.currentUser.lastName !== null ? this.lastName = this._authService.currentUser["lastName"] : "";
this._authService.currentUser.companyName !== null ? this.companyName = this._authService.currentUser["companyName"] : "";
* */

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

  canSave:boolean = false;

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
    this.subrscribeToFormChanges();
    this.canSave = false;
  }

  saveData(){
    console.log("entering saveData");
    this._vendorService.UpdateVendor({"firstName":this.firstName.value,"lastName":this.lastName.value,"companyName":this.companyName.value});
    this.canSave = false;
  }

  subrscribeToFormChanges(){
    this.firstName.valueChanges.subscribe((val)=>{this.canSave = true});
    this.lastName.valueChanges.subscribe((val)=>{this.canSave = true});
    this.companyName.valueChanges.subscribe((val)=>{this.canSave = true});
  }
}

import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-vendor-home-page',
  templateUrl: './vendor-home-page.component.html',
  styleUrls: ['./vendor-home-page.component.css']
})
export class VendorHomePageComponent implements OnInit {

  vendorUrl:string = "/vendor/home";
  constructor(
    public _authService:AuthService,
    private router:Router
  ) { }

  ngOnInit(): void {
  }

  logOut(){
    this._authService.logOut();
  }
}

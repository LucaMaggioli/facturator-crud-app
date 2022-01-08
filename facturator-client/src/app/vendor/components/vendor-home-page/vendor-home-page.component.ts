import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-home-page',
  templateUrl: './vendor-home-page.component.html',
  styleUrls: ['./vendor-home-page.component.css']
})
export class VendorHomePageComponent implements OnInit {

  vendorUrl:string = "/vendor/home";
  constructor() { }

  ngOnInit(): void {
  }
}

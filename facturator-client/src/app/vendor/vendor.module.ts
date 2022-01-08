import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorHomePageComponent } from './components/vendor-home-page/vendor-home-page.component';
import { ArticlePageComponent } from './components/article-page/article-page.component';
import { ClientPageComponent } from './components/client-page/client-page.component';
import { BillPageComponent } from './components/bill-page/bill-page.component';
import {MatButtonModule} from "@angular/material/button";
import { ArticlesListComponent } from './components/articles-list/articles-list.component';


@NgModule({
  declarations: [
    VendorHomePageComponent,
    ArticlePageComponent,
    ClientPageComponent,
    BillPageComponent,
    ArticlesListComponent
  ],
  imports: [
    CommonModule,
    VendorRoutingModule,
    MatButtonModule
  ]
})
export class VendorModule { }

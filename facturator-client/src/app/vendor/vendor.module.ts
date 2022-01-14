import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorHomePageComponent } from './components/vendor-home-page/vendor-home-page.component';
import { ArticlePageComponent } from './components/article-page/article-page.component';
import { ClientPageComponent } from './components/client-page/client-page.component';
import { BillPageComponent } from './components/bill-page/bill-page.component';
import {MatButtonModule} from "@angular/material/button";
import { ArticlesListComponent } from './components/articles-list/articles-list.component';
import { VendorPageComponent } from './components/vendor-page/vendor-page.component';
import { LoginComponent } from './components/login/login.component';
import {ReactiveFormsModule} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {MatInputModule} from "@angular/material/input";
import { AddArticleComponent } from './components/add-article/add-article.component';


@NgModule({
  declarations: [
    VendorHomePageComponent,
    ArticlePageComponent,
    ClientPageComponent,
    BillPageComponent,
    ArticlesListComponent,
    VendorPageComponent,
    LoginComponent,
    AddArticleComponent,
  ],
  imports: [
    CommonModule,
    VendorRoutingModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule
  ]
})
export class VendorModule { }

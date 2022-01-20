import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorComponent } from './components/vendor-page/vendor.component';
import { ArticlePageComponent } from './components/article-page/article-page.component';
import { ClientPageComponent } from './components/client-page/client-page.component';
import { BillPageComponent } from './components/bill-page/bill-page.component';
import {MatButtonModule} from "@angular/material/button";
import { ArticlesListComponent } from './components/articles-list/articles-list.component';
import { VendorInfoComponent } from './components/vendor-info/vendor-info.component';
import { LoginComponent } from './components/login/login.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {MatInputModule} from "@angular/material/input";
import { AddArticleComponent } from './components/add-article/add-article.component';
import { ArticleComponent } from './components/article/article.component';
import { VendorHomeComponent } from './components/vendor-home/vendor-home.component';
import { ClientComponent } from './components/client/client.component';


@NgModule({
  declarations: [
    VendorComponent,
    ArticlePageComponent,
    ClientPageComponent,
    BillPageComponent,
    ArticlesListComponent,
    VendorInfoComponent,
    LoginComponent,
    AddArticleComponent,
    ArticleComponent,
    VendorHomeComponent,
    ClientComponent,
  ],
    imports: [
        CommonModule,
        VendorRoutingModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        FormsModule
    ]
})
export class VendorModule { }

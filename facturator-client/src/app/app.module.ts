import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import {FacturatorApiCallService} from "./services/facturator-api-call.service";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import { ArticlesListComponent } from './components/articles-list/articles-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from "@angular/material/button";
import { AddClientFormComponent } from './components/add-client-form/add-client-form.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from "@angular/forms";
import { ClientListComponent } from './components/client-list/client-list.component';
import { BillCreationComponent } from './components/bill-creation/bill-creation.component';
import {MatExpansionModule} from "@angular/material/expansion";
import { AppRoutingModule } from './app-routing.module';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {MatCheckboxModule} from "@angular/material/checkbox";
import { BillConfirmerComponent } from './components/bill-confirmer/bill-confirmer.component';
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {MatToolbarModule} from "@angular/material/toolbar";
import { ClientPageComponent } from './components/client-page/client-page.component';
import { ArticlesPageComponent } from './components/article-page/article-page.component';
import { AddArticleFormComponent } from './components/add-article-form/add-article-form.component';
import {MatIconModule} from "@angular/material/icon";
import {LoginRoutingModule} from "./login/login-routing.module";
import {LoginModule} from "./login/login.module";


@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ArticlesListComponent,
    AddClientFormComponent,
    ClientListComponent,
    BillCreationComponent,
    BillConfirmerComponent,
    ClientPageComponent,
    ArticlesPageComponent,
    AddArticleFormComponent
  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatCardModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        ReactiveFormsModule,
        MatExpansionModule,
        AppRoutingModule,
        MatProgressSpinnerModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatToolbarModule,
        MatIconModule,
        LoginModule,
    ],
  providers: [FacturatorApiCallService, MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }

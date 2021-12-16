import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Router, RouterModule, Routes} from "@angular/router";
import {BillCreationComponent} from "./components/bill-creation/bill-creation.component";
import {HomePageComponent} from "./components/home-page/home-page.component";
import {ClientPageComponent} from "./components/client-page/client-page.component";
import {ArticlesPageComponent} from "./components/articles-page/articles-page.component";
import {LoginGuard} from "./login/guards/login.guard";


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'bill', component: BillCreationComponent, canActivate: [LoginGuard]},
  { path: 'clients', component: ClientPageComponent },
  { path: 'articles', component: ArticlesPageComponent },
  { path: 'home', component: HomePageComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }

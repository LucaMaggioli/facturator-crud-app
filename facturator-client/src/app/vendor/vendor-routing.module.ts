import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {VendorHomePageComponent} from "./components/vendor-home-page/vendor-home-page.component";
import {ArticlePageComponent} from "./components/article-page/article-page.component";
import {ClientPageComponent} from "./components/client-page/client-page.component";
import {BillPageComponent} from "./components/bill-page/bill-page.component";
import {LoginGuard} from "./guards/login.guard";
import {VendorPageComponent} from "./components/vendor-page/vendor-page.component";
import {LoginComponent} from "./components/login/login.component";

const VENDOR: string = "vendor";
const routes: Routes = [
  { path: `${VENDOR}`, redirectTo: `${VENDOR}/home`, pathMatch: 'full' },
  { path: `${VENDOR}/login`, component: LoginComponent },
  { path: `${VENDOR}/home`,
    component: VendorHomePageComponent,
    children: [
      { path: `login`, component: LoginComponent },
      { path: 'articles', component: ArticlePageComponent, canActivate: [LoginGuard] },
      { path: 'clients', component: ClientPageComponent, canActivate: [LoginGuard] },
      { path: 'bills', component: BillPageComponent, canActivate: [LoginGuard] },
      { path: 'info', component: VendorPageComponent, canActivate: [LoginGuard] },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }

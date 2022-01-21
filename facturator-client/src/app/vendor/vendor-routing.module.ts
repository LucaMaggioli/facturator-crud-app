import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {VendorComponent} from "./components/vendor-page/vendor.component";
import {ArticlePageComponent} from "./components/article-page/article-page.component";
import {ClientPageComponent} from "./components/client-page/client-page.component";
import {BillPageComponent} from "./components/bill-page/bill-page.component";
import {LoginGuard} from "./guards/login.guard";
import {VendorInfoComponent} from "./components/vendor-info/vendor-info.component";
import {LoginComponent} from "./components/login/login.component";
import { VendorHomeComponent } from './components/vendor-home/vendor-home.component';

const VENDOR: string = "vendor";
const routes: Routes = [
  //{ path: `${VENDOR}:isUserLogged`, redirectTo: `${VENDOR}/home:isUserLogged`, pathMatch: 'full' },
  { path: `${VENDOR}`, redirectTo: `${VENDOR}/home`, pathMatch: 'full' },
  { path: `${VENDOR}`,
    component: VendorComponent,
    children: [
      { path: `login`, component: LoginComponent },
      { path: `home`, component: VendorHomeComponent },
      { path: 'info', component: VendorInfoComponent, canActivate: [LoginGuard] },
      { path: 'articles', component: ArticlePageComponent, canActivate: [LoginGuard] },
      { path: 'clients', component: ClientPageComponent, canActivate: [LoginGuard] },
      { path: 'bills', component: BillPageComponent, canActivate: [LoginGuard] },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }

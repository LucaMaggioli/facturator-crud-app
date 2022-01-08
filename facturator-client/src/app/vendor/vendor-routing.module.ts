import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {VendorHomePageComponent} from "./components/vendor-home-page/vendor-home-page.component";
import {ArticlePageComponent} from "./components/article-page/article-page.component";
import {ClientPageComponent} from "./components/client-page/client-page.component";
import {BillPageComponent} from "./components/bill-page/bill-page.component";

const VENDOR: string = "vendor";
const routes: Routes = [
  { path: `${VENDOR}/home`,
    component: VendorHomePageComponent,
    children: [
      { path: 'articles', component: ArticlePageComponent },
      { path: 'clients', component: ClientPageComponent },
      { path: 'bills', component: BillPageComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }

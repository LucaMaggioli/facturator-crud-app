import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LoginRoutingModule} from "./login-routing.module";
import {LoginPageComponent} from "./components/login/loginPage.component";
import {ReactiveFormsModule} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatInputModule} from "@angular/material/input";
import {MatSnackBar} from "@angular/material/snack-bar";
import { LoginRedirectionSnackBarComponent } from './components/login-redirection-snack-bar/login-redirection-snack-bar.component';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";



@NgModule({
  declarations: [
    LoginPageComponent,
    LoginRedirectionSnackBarComponent,
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatProgressSpinnerModule,
  ],
  providers:[
    MatSnackBar,
  ]
})
export class LoginModule { }

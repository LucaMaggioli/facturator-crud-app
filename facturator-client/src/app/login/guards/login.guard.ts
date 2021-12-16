import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {UserService} from "../services/user.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {TimerService} from "../../services/timer.service";
import {LoginRedirectionSnackBarComponent} from "../components/login-redirection-snack-bar/login-redirection-snack-bar.component";

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {

  constructor(
    private router:Router,
    private _userService:UserService,
    private _snackBar: MatSnackBar,
    private _timer: TimerService,
  ) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree
  {
    if(!this._userService.isUserLogged){
      this._snackBar.openFromComponent(LoginRedirectionSnackBarComponent,{data:'login to access bill page', duration:3000});
    }

    this._timer.sleep(3000); //should be await but can't in a guard(ask Yassin)

    return this._userService.isUserLogged || this.router.parseUrl('login');
  }
}

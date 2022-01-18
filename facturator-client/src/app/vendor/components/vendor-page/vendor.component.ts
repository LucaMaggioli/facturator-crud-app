import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-vendor-home-page',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent implements OnInit, OnDestroy {

  vendorUrl:string = "/vendor";
  isUserLogged:boolean = false;
  private routerSub:any; //SHOULD BE :Subscription  --> import {Subscription} from "rxjs";

  constructor(
    public _authService:AuthService,
    private route:ActivatedRoute,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.setIfUserLogged();
    this.routerSub = this.router.events.subscribe((route)=>{
      console.log("in router subscription on VendorComponent");
      this.setIfUserLogged();
      console.log("User Logged: " + this.isUserLogged);
    })
    //HOW TO READ PARAMETERS OF THE URL WITH ANGULAR NAVIGATION SEE: https://angular-training-guide.rangle.io/routing/query_params
    // this.route.queryParams.subscribe((params: Params) => { });
  }

  ngOnDestroy():void{
    this.routerSub.unsubscribe();
  }

  logOut(){
    this._authService.logOut();
    this.setIfUserLogged();
  }

  setIfUserLogged(){
    this.isUserLogged = this._authService.isUserLogged();
  }
}

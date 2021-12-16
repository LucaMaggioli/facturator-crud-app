import {Component, Inject, OnInit} from '@angular/core';
import {MAT_SNACK_BAR_DATA} from "@angular/material/snack-bar";

@Component({
  selector: 'app-login-redirection-snack-bar',
  templateUrl: './login-redirection-snack-bar.component.html',
  styleUrls: ['./login-redirection-snack-bar.component.css']
})
export class LoginRedirectionSnackBarComponent implements OnInit {

  constructor(
    @Inject(MAT_SNACK_BAR_DATA) public data: string
  ) { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import {ClientDto} from "../../../shared/models/ClientDto";

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit {

  clients:ClientDto [] = [];

  constructor() { }

  ngOnInit(): void {
  }

}

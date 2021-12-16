import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Client} from "../../shared/models/client";

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  @Input() clients:any [] = [];
  @Input() selectionMode:boolean = false;
  @Output() selectedClient = new EventEmitter<Client>();

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges():void{
    console.log(this.clients);
  }

  selectClient(client:Client){
    this.selectedClient.emit(client);
  }

}

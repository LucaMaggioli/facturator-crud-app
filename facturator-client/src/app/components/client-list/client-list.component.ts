import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ClientDto } from '../../shared/models/ClientDto';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css'],
})
export class ClientListComponent implements OnInit {
  @Input() clients: any[] = [];
  @Input() selectionMode: boolean = false;
  @Output() selectedClient = new EventEmitter<ClientDto>();

  constructor() {}

  ngOnInit(): void {}

  ngOnChanges(): void {
    console.log(this.clients);
  }

  selectClient(client: ClientDto) {
    this.selectedClient.emit(client);
  }
}

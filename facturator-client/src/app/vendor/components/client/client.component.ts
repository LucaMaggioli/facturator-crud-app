import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ClientDto} from "../../dtos/ClientDto";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  @Input() client:ClientDto = new ClientDto();
  @Output()  removeClient = new EventEmitter<number>();
  @Output()  updateClient = new EventEmitter<ClientDto>();
  editMode: boolean = false;
  clientChanged: boolean = false;

  firstName = new FormControl(this.client.firstName);
  lastName = new FormControl(this.client.lastName);
  address = new FormControl(this.client.address);
  email = new FormControl(this.client.email);


  constructor() { }

  ngOnInit(): void {
    this.fillFormData();
    this.subrscribeToFormChanges();
  }

  deleteClient() {
    this.removeClient.emit(this.client.id)
  }

  toggleEditMode() {
    this.editMode = !this.editMode;
  }

  sendClientUpdate() {
    this.updateClient.emit(this.client)
    this.clientChanged = false;
  }

  saveCLient() {
    if (this.clientChanged){
      this.sendClientUpdate()
    }
    this.toggleEditMode();
  }

  subrscribeToFormChanges(){
    this.firstName.valueChanges.subscribe((val)=>{
      this.clientChanged = true;
      this.client.firstName = val;
    });
    this.lastName.valueChanges.subscribe((val)=>{
      this.clientChanged = true;
      this.client.lastName = val;
    });
    this.address.valueChanges.subscribe((val)=>{
      this.clientChanged = true;
      this.client.address = val;
    });
    this.email.valueChanges.subscribe((val)=>{
      this.clientChanged = true;
      this.client.email = val;
    });
  }

  private fillFormData() {
    this.firstName.setValue(this.client.firstName);
    this.lastName.setValue(this.client.lastName);
    this.address.setValue(this.client.address);
    this.email.setValue(this.client.email);
  }
}

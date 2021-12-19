import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ClientDto } from '../../shared/models/ClientDto';
import { main } from '@angular/compiler-cli/src/main';

@Component({
  selector: 'app-add-client-form',
  templateUrl: './add-client-form.component.html',
  styleUrls: ['./add-client-form.component.css'],
})
export class AddClientFormComponent implements OnInit {
  @Output() newClient = new EventEmitter<ClientDto>();

  email = new FormControl('', [Validators.required, Validators.email]);
  fName = new FormControl('', [Validators.required]);
  lName = new FormControl('', [Validators.required]);
  address = new FormControl('', [Validators.required]);
  tempoMessage: any = null;

  constructor() {}

  ngOnInit(): void {}

  emailInvalidErrorMessage() {
    return this.email.hasError('email')
      ? 'Not a valid email'
      : this.email.hasError('required')
      ? 'You must enter a value'
      : '';
  }

  isValidForm(): boolean {
    return (
      this.lName.valid &&
      this.fName.valid &&
      this.address.valid &&
      this.email.valid
    );
  }

  sendNewClientEvent() {
    let fullName = this.fName.value + ' - ' + this.lName.value;
    let newClient = new ClientDto(
      fullName,
      this.address.value,
      this.email.value
    );
    this.newClient.emit(newClient);
    this.setTemporaryMessage('Client added successfully !', true);
    this.resetForm();
  }

  resetForm(): void {
    this.address.reset();
    this.fName.reset();
    this.lName.reset();
    this.email.reset();
  }

  setTemporaryMessage(tempoMessage: string, succes: boolean) {
    this.tempoMessage = tempoMessage;
    this.sleep(3000).then(() => {
      this.tempoMessage = null;
    });
  }

  sleep(ms: number) {
    return new Promise((resolve) => setTimeout(resolve, ms));
  }
}

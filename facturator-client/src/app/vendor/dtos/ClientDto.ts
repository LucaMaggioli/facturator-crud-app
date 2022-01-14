export class ClientDto {
  id: any;
  firstName: string;
  lastName: string;
  address: string;
  email: string;

  constructor(_name: string, _lastName: string, _address: string, _email: string, _id?: any) {
    this.id = _id;
    this.firstName = _name;
    this.lastName = _lastName;
    this.address = _address;
    this.email = _email;
  }

  public fromDtoToJson() {
    return {
      id: this.id,
      name: this.firstName,
      lastName: this.lastName,
      address: this.address,
      email: this.email,
    };
  }
}

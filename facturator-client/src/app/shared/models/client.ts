export class Client{
  id:any = 0;
  name: string = "";
  address: string = "";
  email: string = "";

  constructor(_name:string, _address:string, _email:string, _id?:any) {
    this.id = _id;
    this.name = _name;
    this.address = _address;
    this.email = _email;
  }

  public fromDtoToJson(){
    return { id:this.id, name:this.name, address:this.address, email:this.email }
  }
}

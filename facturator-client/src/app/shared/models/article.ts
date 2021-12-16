export class Article{
  id: any = "";
  name: string = "";
  photo: string = "";
  price: number = 0;
  description: string = "";

  constructor(_name:string, price:number, _photo:string, description:string, _id?:string ) {
    this.id = _id;
    this.name = _name;
    this.photo = _photo;
    this.price = price;
    this.description = description;
  }
}

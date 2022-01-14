export class ArticleDto{
  id?: any = "";
  name?: string = "";
  photoUrl?: string = "";
  price?: number = 0;
  description?: string = "";

  constructor(_name?:string, _photo?:string, price?:number, description?:string, _id?:string ) {
    this.id = _id;
    this.name = _name;
    this.photoUrl = _photo;
    this.price = price;
    this.description = description;
  }
}

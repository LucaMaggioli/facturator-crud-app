import {Client} from "./client";
import {Article} from "./article";

export class Bill{
  id: string = "";
  date: Date = new Date();
  totalPrice: number = 0;
  validated: boolean = false;

  client: Client = new Client('','','');
  articles: Article[] = [];
}

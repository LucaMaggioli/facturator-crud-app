import {IArticleDto} from "./i-article-dto";
import {VendorDto} from "./Vendor-dto";
import {ClientDto} from "./ClientDto";

export interface IBillDto {
  id:number;
  date:Date;
  total:number;
  isPayed:boolean;
  articles:IArticleDto[];
  client:ClientDto;
  vendor:VendorDto;
}

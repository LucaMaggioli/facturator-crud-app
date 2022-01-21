import {IArticleDto} from "./i-article-dto";
import {IClientDto} from "./iclient-dto";
import {IVendorDto} from "./ivendor-dto";

export interface IBillDto {
  id:number;
  date:Date;
  total:number;
  isPayed:boolean;
  articles:IArticleDto[];
  client:IClientDto;
  vendor:IVendorDto;
}

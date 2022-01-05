import { ClientDto } from './ClientDto';
import { Article } from './article';

export class Bill {
  id: string = '';
  date: Date = new Date();
  totalPrice: number = 0;
  validated: boolean = false;

  client: ClientDto = new ClientDto('', '', '');
  articles: Article[] = [];
}

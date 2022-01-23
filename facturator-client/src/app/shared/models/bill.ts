import { ClientDto } from './ClientDto';
import { ArticleDto } from './articleDto';

export class Bill {
  id: string = '';
  date: Date = new Date();
  totalPrice: number = 0;
  validated: boolean = false;

  client: ClientDto = new ClientDto('', '', '');
  articles: ArticleDto[] = [];
}

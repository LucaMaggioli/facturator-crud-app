import { ArticleDto } from '../shared/models/articleDto';
import { Bill } from '../shared/models/bill';
// @ts-ignore
import { ClientDto } from "../shared/models/clientDto";

export const articles: ArticleDto[] = [
  new ArticleDto('phone',  '/photo/url',55.99, 'description', '0-1'),
  new ArticleDto('phone',  '/photo/url',55.99, 'description', '0-1'),
  new ArticleDto('phone',  '/photo/url',55.99, 'description', '0-1'),
  new ArticleDto('phone',  '/photo/url',55.99, 'description', '0-1'),
];

export const bills: Bill[] = [];

export const clients: ClientDto[] = [
  new ClientDto('0', 'Luca', 'sches 45', 'lucamaggio@gmail.com'),
  new ClientDto('1', 'Jérôme', 'oche 10', 'Jérôme.thb@gmail.com'),
  new ClientDto('2', 'Hiago', 'Bel air 45', 'hiago@gmail.com'),
];

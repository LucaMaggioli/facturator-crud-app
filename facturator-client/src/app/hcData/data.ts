import { Article } from '../shared/models/article';
import { Bill } from '../shared/models/bill';
import { ClientDto } from '../shared/models/client';

export const articles: Article[] = [
  new Article('phone', 55.99, '/photo/url', 'description', '0-1'),
  new Article('laptop', 225.99, '/photo/url', 'description', '0-2'),
  new Article('fridge', 79.99, '/photo/url', 'description', '0-3'),
  new Article('book', 5.99, '/photo/url', 'description', '0-4'),
];

export const bills: Bill[] = [];

export const clients: ClientDto[] = [
  new ClientDto('0', 'Luca', 'sches 45', 'lucamaggio@gmail.com'),
  new ClientDto('1', 'Jérôme', 'oche 10', 'Jérôme.thb@gmail.com'),
  new ClientDto('2', 'Hiago', 'Bel air 45', 'hiago@gmail.com'),
];

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TimerService {

  constructor() { }

  sleep(ms:number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
}

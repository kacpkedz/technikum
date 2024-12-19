import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class KalkulatorekService {

  constructor() { }

  dodawanie(a:number,b:number):number {
    return a+b;
  }
  odejmowanie(a:number,b:number):number{
    return a-b;
  }
  mnozenie(a:number,b:number):number{
    return a*b;
  }
  dzielenie(a:number,b:number):number{
    if(b==0) {
      throw new Error("Dzielenie przez zero!");
    }
    return a/b;
  }
}

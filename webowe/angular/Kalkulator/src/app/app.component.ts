import { Component } from '@angular/core';
import { KalkulatorekService } from './kalkulatorek.service';
import { error } from 'console';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BmiComponent } from './bmi/bmi.component';
import { ObliczanieBMIService } from './obliczanie-bmi.service';
import { KoloService } from './kolo.service';
import { KoloComponent } from './kolo/kolo.component';

@Component({
  selector: 'app-root',
  imports: [FormsModule, CommonModule, BmiComponent, KoloComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [KalkulatorekService, ObliczanieBMIService, KoloService]
})
export class AppComponent {
  title = 'Kalkulator';
  num1:number = 0;
  num2:number = 0;
  wynik:{suma:number, roznica:number, iloczyn:number, iloraz:number} | null = null;
  errorMes:string | null = null;
  constructor(private kalkulatorek: KalkulatorekService){}
    calculate(): void{
      try{
        this.errorMes = null;
        const suma = this.kalkulatorek.dodawanie(this.num1, this.num2);
        const roznica = this.kalkulatorek.odejmowanie(this.num1, this.num2);
        const iloczyn = this.kalkulatorek.mnozenie(this.num1, this.num2);
        const iloraz = this.kalkulatorek.dzielenie(this.num1, this.num2);
        this.wynik = {suma, roznica, iloczyn, iloraz};
      } catch (error:any){
        this.errorMes = error.message;
        this.wynik = null;
      }
    }
  }
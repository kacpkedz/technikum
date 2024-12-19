import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ObliczanieBMIService } from '../obliczanie-bmi.service';

@Component({
  selector: 'app-bmi',
  imports: [FormsModule, CommonModule],
  templateUrl: './bmi.component.html',
  styleUrl: './bmi.component.css'
})
export class BmiComponent {
  masa: number | null = null;
  wzrost: number | null = null;
  bmi: number | null = null;
  kategoria: string = '';
  error: string | null = null; 

  constructor(private bmiService: ObliczanieBMIService) {}

  obliczBMI(): void {
    this.error = null;
    try {
      if (this.masa !== null && this.wzrost !== null) {
        const wynik = this.bmiService.obliczBMI(this.masa, this.wzrost);
        this.bmi = wynik.bmi;
        this.kategoria = wynik.kategoria;
      }
    } catch (err: any) {
      this.error = err.message;
      this.bmi = null;
      this.kategoria = '';
    }
  }
}

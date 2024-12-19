import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ObliczanieBMIService {

  constructor() { }
  obliczBMI(masa: number, wzrost: number): { bmi: number; kategoria: string } {
    if (wzrost <= 0 || masa <= 0) {
      throw new Error('Wzrost i masa muszą być większe od zera.');
    }

    const bmi = masa / (wzrost * wzrost);
    const kategoria = this.okreslKategorie(bmi);

    return { bmi, kategoria };
  }

  private okreslKategorie(bmi: number): string {
    if (bmi < 18.5) {
      return 'Niedowaga';
    } else if (bmi >= 18.5 && bmi < 24.9) {
      return 'Waga prawidłowa';
    } else if (bmi >= 25 && bmi < 29.9) {
      return 'Nadwaga';
    } else {
      return 'Otyłość';
    }
  }
}

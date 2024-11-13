import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-osoby',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './osoby.component.html',
  styleUrl: './osoby.component.css'
})
export class OsobyComponent {
  osoby: (string | number)[][] = [['Jan', 'Kowalski', 18], ['Kacper', 'Kędziora', 18]];
  imie: string = '';
  nazwisko: string = '';
  wiek: number | null = null;
  wynik: string | null = null;

  czyOsobaJestNaLiscie(imie: string, nazwisko: string, wiek: number): boolean { 
    return this.osoby.some(osoba => osoba[0] === imie && 
      osoba[1] === nazwisko && osoba[2] === wiek);
  } 
  
  sprawdzanie() { 
    if (this.wiek !== null) { 
      if (this.czyOsobaJestNaLiscie(this.imie, this.nazwisko, this.wiek)) { 
        this.wynik = 'Osoba jest na liście.'; 
      } else { 
        this.wynik = 'Osoby nie ma na liście.'; 
      } 
    } 
  } 
}
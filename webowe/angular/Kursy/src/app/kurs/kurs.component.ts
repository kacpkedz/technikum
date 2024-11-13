import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-kurs',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './kurs.component.html',
  styleUrl: './kurs.component.css'
})
export class KursComponent {
  // Deklaracja listy kursów
  kursy: string[] = ["Programowanie w C#", "Angular dla początkujących", "Kurs Django"];

  // Zmienna imię i nazwisko dla formularza
  imieNazwisko: string = '';
  // Zmienna dla numerów kursu
  numerKursu: number | null = null;

  zapisDoKursu() {
    console.clear(); // Czyszczenie konsoli
    console.log("Imię i nazwisko: ", this.imieNazwisko); // Wypisanie imienia i nazwiska w konsoli
    if (this.numerKursu !== null && this.numerKursu > 0 && this.numerKursu <= this.kursy.length) {
      console.log("Wybrany numer kursu: ", this.numerKursu); // Wypisanie numeru kursu w konsoli
      const wybranyKurs = this.kursy[this.numerKursu - 1];
      console.log("Wybrany kurs: ", wybranyKurs);
    } else {
      console.log("Nieprawidłowy numer kursu");
    }
  }
}

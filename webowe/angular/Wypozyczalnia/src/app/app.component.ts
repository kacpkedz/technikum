import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
// Definicja formularza reaktywnego, przechowuje dane formularza
formularzRekordu: FormGroup;
// Tablica przechowująca rekordy
rekordy: any[] = [];
// Lista dostępnych kategorii
kategorie = ['Dramat', 'Komedia', 'Horror', 'Sci-Fi', 'Fantasy'];
// Konstruktor, który inicjalizuje formularz reaktywny przy użyciu FormBuildera
constructor(private fb: FormBuilder) {
  // Tworzenie grupy formularza z odpowiednimi polami i walidatorami
  this.formularzRekordu = this.fb.group({
    imie: ['', Validators.required],
    nazwisko: ['', Validators.required],
    pesel: ['', [Validators.required, Validators.pattern(/^\d{11}$/)]],
    kategoria: ['', Validators.required],
    tytul: ['', Validators.required],
  });
}

// Metoda dodająca rekord
dodajRekord(): void {
  if (this.formularzRekordu.valid) {
    // Dodaj rekord do listy
    this.rekordy.push(this.formularzRekordu.value);
    const jsonData = JSON.stringify(this.rekordy, null, 2);
    const blob = new Blob([jsonData], { type: 'application/json' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'rekordy.json'; // Nazwa pliku JSON
    a.click();
    window.URL.revokeObjectURL(url);
    // Reset formularza
    this.formularzRekordu.reset();
  }
}
}
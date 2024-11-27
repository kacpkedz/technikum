import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from '../przekaz.service';

@Component({
  selector: 'app-rejestracja',
  imports: [CommonModule, FormsModule],
  templateUrl: './rejestracja.component.html',
  styleUrls: ['./rejestracja.component.css'],
})
export class RejestracjaComponent {
  // Zmienna przechowująca dane użytkownika, które będą przesyłane przez formularz
  pracownik = {
    imie: '',                 // Imię użytkownika
    nazwisko: '',             // Nazwisko użytkownika
    email: '',                // Email użytkownika
    haslo: '',                // Hasło użytkownika
    potwierdzHaslo: '',       // Potwierdzenie hasła użytkownika
    wiek: null,               // Wiek użytkownika
    zgoda: false,             // Zgoda na przetwarzanie danych osobowych
    stanowisko: '',           // Stanowisko użytkownika
  };

  // Zmienna przechowująca komunikaty błędów
  blad: string = '';

  // Konstruktor klasy, który wstrzykuje usługę EmployeeService
  constructor(private employeeService: EmployeeService) {}

  // Funkcja walidująca poprawność adresu e-mail
  walidacjaEmail(email: string): boolean {
    const wzorzecEmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA0-9]{2,4}$/;
    return wzorzecEmail.test(email);
  }

  // Funkcja walidująca hasło
  walidacjaHasla(haslo: string): boolean {
    const wzorzecHasla = /^(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>]).{8,}$/;
    return wzorzecHasla.test(haslo);
  }

  // Funkcja walidująca wiek użytkownika w zależności od stanowiska
  walidacjaWiek(wiek: number | null, stanowisko: string): boolean {
    if (wiek === null) return false;

    // Sprawdzanie minimalnego wieku w zależności od stanowiska
    if (stanowisko === 'pracownik fizyczny') return wiek >= 16;
    return wiek >= 18;
  }

  // Funkcja wywoływana po wysłaniu formularza
  onSubmit(form: any) {
    this.blad = '';

    // Sprawdzanie, czy wszystkie wymagane pola formularza są wypełnione
    if (!this.pracownik.imie || !this.pracownik.nazwisko || !this.pracownik.email || !this.pracownik.haslo || !this.pracownik.potwierdzHaslo || !this.pracownik.wiek || !this.pracownik.stanowisko || !this.pracownik.zgoda) {
      this.blad = 'Wszystkie pola są wymagane!';
      return;
    }

    // Sprawdzanie poprawności adresu e-mail
    if (!this.walidacjaEmail(this.pracownik.email)) {
      this.blad = 'Podaj poprawny adres e-mail!';
      return;
    }

    // Sprawdzanie, czy hasła są zgodne
    if (this.pracownik.haslo !== this.pracownik.potwierdzHaslo) {
      this.blad = 'Hasła nie są zgodne!';
      return;
    }

    // Sprawdzanie poprawności hasła
    if (!this.walidacjaHasla(this.pracownik.haslo)) {
      this.blad = 'Hasło musi zawierać co najmniej 8 znaków, jedną cyfrę i jeden znak specjalny.';
      return;
    }

    // Sprawdzanie, czy wiek jest prawidłowy dla wybranego stanowiska
    if (!this.walidacjaWiek(this.pracownik.wiek, this.pracownik.stanowisko)) {
      this.blad = 'Wiek jest nieprawidłowy dla tego stanowiska.';
      return;
    }

    // Jeśli wszystkie walidacje przeszły pomyślnie, dodaj pracownika do usługi
    this.employeeService.addEmployee({ ...this.pracownik });

    // Resetowanie danych formularza po pomyślnej rejestracji
    this.pracownik = {
      imie: '',
      nazwisko: '',
      email: '',
      haslo: '',
      potwierdzHaslo: '',
      wiek: null,
      zgoda: false,
      stanowisko: '',
    };

    // Resetowanie formularza i wyświetlanie komunikatu o sukcesie
    form.reset();
    alert('Rejestracja przebiegła pomyślnie!');
  }
}
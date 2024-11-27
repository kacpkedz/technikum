import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListaComponent } from './lista/lista.component';
import { RejestracjaComponent } from './rejestracja/rejestracja.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ListaComponent, RejestracjaComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Rejestracja';
}

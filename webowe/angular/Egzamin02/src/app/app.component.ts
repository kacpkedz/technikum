import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FilmComponent } from './film/film.component';
import { KsiazkiComponent } from './ksiazki/ksiazki.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FilmComponent, KsiazkiComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Egzamin02';
}

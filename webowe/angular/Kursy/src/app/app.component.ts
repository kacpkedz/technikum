import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { KursComponent } from './kurs/kurs.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, KursComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Kursy';
}

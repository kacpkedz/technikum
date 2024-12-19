import { Component } from '@angular/core';
import { KoloService } from '../kolo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-kolo',
  imports: [FormsModule, CommonModule],
  templateUrl: './kolo.component.html',
  styleUrl: './kolo.component.css'
})
export class KoloComponent {
  promien: number | null = null;
  pi: number = 3.14159;
  pole: number | null = null;
  objetosc: number | null = null;
  error: string | null = null;

  constructor(private circleService: KoloService){}

  obliczPoleKuli(): void {
    this.error = null;
    try {
      if (this.promien !== null) {
        this.pole = this.circleService.obliczPoleKuli(this.promien, this.pi);
      }
    } catch (err: any) {
      this.error = err.message;
      this.pole = null;
    }
  }

  obliczObjetoscKuli(): void {
    this.error = null;
    try {
      if (this.promien !== null) {
        this.objetosc = this.circleService.obliczObjetoscKuli(this.promien, this.pi);
      }
    } catch (err: any) {
      this.error = err.message;
      this.objetosc = null;
    }
  }
}
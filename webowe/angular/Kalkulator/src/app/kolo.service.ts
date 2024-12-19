import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class KoloService {

  constructor() { }

  obliczPoleKuli(radius: number, pi: number): number {
    if (radius <= 0 || pi <= 0) {
      throw new Error('Promień i Pi muszą być większe od zera.');
    }
    return 4 * pi * radius * radius;
  }

  obliczObjetoscKuli(radius: number, pi: number): number {
    if (radius <= 0 || pi <= 0) {
      throw new Error('Promień i Pi muszą być większe od zera.');
    }
    return (4 / 3) * pi * radius * radius * radius;
  }
}

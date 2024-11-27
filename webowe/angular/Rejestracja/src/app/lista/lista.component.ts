import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { EmployeeService } from '../przekaz.service';

@Component({
  selector: 'app-lista',
  imports: [CommonModule],
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css'],
})
export class ListaComponent {
  // Zmienna przechowująca listę pracowników
  pracownicy: any[] = [];

  // Konstruktor, w którym wstrzykujemy serwis EmployeeService
  constructor(private employeeService: EmployeeService) {}

  // Metoda ngOnInit, która jest wywoływana po zainicjowaniu komponentu
  ngOnInit() {
    this.employeeService.employees$.subscribe((employees) => {
      this.pracownicy = employees;
    });
  }
}
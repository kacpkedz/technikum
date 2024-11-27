import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  // Stworzenie prywatnej zmiennej, która przechowuje aktualną listę pracowników
  private employeesSource = new BehaviorSubject<any[]>([]);

  // Stworzenie publicznej zmiennej employees$, która jest obserwowalna (Observable) i udostępnia dane pracowników
  employees$ = this.employeesSource.asObservable();

  // Metoda, która umożliwia dodanie nowego pracownika do listy
  addEmployee(employee: any) {
    // Pobranie bieżącej listy pracowników z BehaviorSubject
    const currentEmployees = this.employeesSource.value;
    
    // Dodanie nowego pracownika do listy
    currentEmployees.push(employee);
    this.employeesSource.next(currentEmployees);
  }
}
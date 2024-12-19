import { CommonModule, LocationStrategy } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ksiazki',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './ksiazki.component.html',
  styleUrl: './ksiazki.component.css'
})
export class KsiazkiComponent {
  books: any[] = [];
  booksCategories: string[] =[
    "Fantasy",
    "Science Fiction",
    "Romance",
  ];
  title: string = '';
  autor: string = '';
  category: string = '';
  newCategory: string = '';
  result: string = '';
  addResult: string = '';

  addBook() {
    this.books.push({ title: this.title, category: this.category });
    this.title = '';
    this.category = '';
  }

  addCategory() {
    if (this.newCategory != '') {
      this.booksCategories.push(this.newCategory);
    } else {
      this.addResult = 'Nie dodano kategorii';
    }
    this.newCategory = '';
  }
}

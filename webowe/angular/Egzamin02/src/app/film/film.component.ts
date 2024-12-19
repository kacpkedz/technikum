import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-film',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './film.component.html',
  styleUrl: './film.component.css'
})
export class FilmComponent {
  title: string = '';
  category: string = '';
  newCategory: string = '';
  result: string = '';
  addResult: string = '';
  films: string[] = [
    "Komedia",
    "Obyczajowy",
    "Sensacyjny",
    "Horror"
  ];

  addFilm() {
    console.log({tytuł: this.title, kategoria: this.category});
    
    if (this.title !='' || this.category != '') {
      this.result = "Wybrano " + this.title + " z kategorii " + this.category;
    } else {
      this.result = "Nie wybrano żadnego filmu";
    }
    this.title='';
    this.category='';
  }

  addCategory() {
    if (this.newCategory != '') {
      this.films.push(this.newCategory);
    } else {
      this.addResult = '';
    }
    this.newCategory = '';
  }
}

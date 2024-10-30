"use strict";
let x = 50;
console.log(x);
let y = null;
console.log(y);
let z;
console.log(z);
let ocena;
let typy;
typy = 'Kacper';
let life = { name: 'Kacper', age: 18, city: 'Szlachta', home_number: 1 };
console.log(life);
const person = {
    name: 'Kacper',
    age: 18
};
console.log(person);
let tab = ['a', 'b', 'c'];
console.log(tab);
for (let i = 0; i < tab.length; i++) {
    tab.shift();
    console.log(tab);
}
let srednia;
srednia = (liczby) => {
    let suma = 0;
    liczby.forEach((e) => {
        suma += e;
    });
    return suma / liczby.length;
};
let liczby = [1, 2, 3, 4, 5, 6, 7];
console.log(srednia(liczby));
let abecadlo = ['aaa', 'bbb', 'ccc'];
let znaki = ['xxx', 'yyy', 'zzz'];
let wszystkie = [...abecadlo, ...znaki];
console.log(wszystkie);
let osoba = ['Jan', 12];
console.log(osoba);
osoba.unshift('Pan');
console.log(osoba);
let xyz = [1, 2, 3];
console.log(xyz);
const miesiac = 15;
const sprawdzMiesiacc = miesiac >= 1 && miesiac <= 12 ? true : false;
console.log(sprawdzMiesiacc);
function sprawdzMiesiac(miesiac) {
    if (miesiac >= 1 && miesiac <= 12) {
        return true;
    }
    else {
        return false;
    }
}
console.log(sprawdzMiesiac(12));
console.log(sprawdzMiesiac(13));
const liczba = 2;
const sprawdzParzystoscc = liczba % 2 == 0 ? 'Parzysta' : 'Nieparzysta';
console.log(sprawdzParzystoscc);
function sprawdzParzystosc(liczba) {
    if (liczba % 2 == 0)
        return console.log("Parzysta");
    else
        return console.log("Nieparzysta");
}
sprawdzParzystosc(2);
sprawdzParzystosc(5);
function obliczCeneBiletu(x) {
    let cena;
    if (x <= 15) {
        cena = 3;
    }
    else if (x <= 40) {
        cena = 1.5 + 0.20 * x;
    }
    else {
        cena = 1 + 0.10 * x;
    }
    return cena;
}
let dlugoscTrasy = 25;
let cenaBiletu = obliczCeneBiletu(dlugoscTrasy);
console.log(cenaBiletu);
let owoce = ['jablko', 'arbuz', 'banan', 'gruszka'];
console.log(owoce);
console.log(owoce.length);
console.log(owoce.sort());
owoce.push('ananas');
console.log(owoce);
owoce.shift();
console.log(owoce);
owoce.pop();
console.log(owoce);
owoce.unshift('ananas');
console.log(owoce);
console.log(owoce.reverse());
// stworzyc zmienna funkcyjna ktora podwaja wartosci w liscie
let podwajanie;
podwajanie = (liczby) => {
    for (let i = 0; i < liczby.length; i++)
        liczby[i] *= 2;
};
let tablica = [1, 2, 3];
podwajanie(tablica);
console.log(tablica);

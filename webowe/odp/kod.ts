let x: number = 50
console.log(x)

let y: null = null
console.log(y)

let z: undefined
console.log(z)

let ocena: 1 | 2 | 3 | 4 | 5 | 6

let typy: string | number
typy = 'Kacper'

interface Person {
    name: string
    age: number
}

interface Home {
    city: string
    home_number: number
}

let life: Person & Home = {name:'Kacper', age:18, city:'Szlachta', home_number:1 }
console.log(life)

const person: Person = {
    name: 'Kacper',
    age: 18
}
console.log(person)

let tab: string[] = ['a', 'b', 'c']
console.log(tab)

for(let i = 0; i < tab.length; i++) {
    tab.shift()
    console.log(tab)
}

let srednia: (liczby: number[]) => number

srednia = (liczby:number[]) => {
    let suma: number = 0;
    liczby.forEach((e) => {
        suma += e
    });
    return suma / liczby.length
}

let liczby = [1,2,3,4,5,6,7]
console.log(srednia(liczby))

let abecadlo: string[] = ['aaa', 'bbb', 'ccc']
let znaki: string[] = ['xxx', 'yyy', 'zzz']

let wszystkie = [...abecadlo, ...znaki]
console.log(wszystkie)

let osoba: [string, number] = ['Jan', 12]
console.log(osoba)
osoba.unshift('Pan')
console.log(osoba)

let xyz: [number, number, number] = [1,2,3]
console.log(xyz)

const miesiac: number = 15
const sprawdzMiesiacc = miesiac >= 1 && miesiac <= 12 ? true : false
console.log(sprawdzMiesiacc)

function sprawdzMiesiac(miesiac: number): boolean {
    if (miesiac >= 1 && miesiac <= 12) {
        return true;
    } else {
        return false;
    }
}

console.log(sprawdzMiesiac(12))
console.log(sprawdzMiesiac(13))

const liczba: number = 2
const sprawdzParzystoscc = liczba % 2 == 0 ? 'Parzysta' : 'Nieparzysta'
console.log(sprawdzParzystoscc)

function sprawdzParzystosc(liczba: number) {
    if (liczba % 2 == 0)
        return console.log("Parzysta")
    else
        return console.log("Nieparzysta")
}

sprawdzParzystosc(2)
sprawdzParzystosc(5)

function obliczCeneBiletu(x: number): number {
    let cena: number;

    if (x <= 15) {
        cena = 3;
    } else if (x <= 40) {
        cena = 1.5 + 0.20 * x;
    } else {
        cena = 1 + 0.10 * x;
    }

    return cena;
}

let dlugoscTrasy = 25
let cenaBiletu = obliczCeneBiletu(dlugoscTrasy)
console.log(cenaBiletu)

let owoce: string[] = ['jablko', 'arbuz', 'banan', 'gruszka']
console.log(owoce)
console.log(owoce.length)

console.log(owoce.sort())

owoce.push('ananas')
console.log(owoce)

owoce.shift()
console.log(owoce)

owoce.pop()
console.log(owoce)

owoce.unshift('ananas')
console.log(owoce)

console.log(owoce.reverse())

// stworzyc zmienna funkcyjna ktora podwaja wartosci w liscie

let podwajanie: (liczby: number[]) => void;
podwajanie = (liczby: number[]) => {
    for (let i = 0; i < liczby.length; i++)
        liczby[i] *= 2;
};

let tablica: number[] = [1,2,3];
podwajanie(tablica);
console.log(tablica);
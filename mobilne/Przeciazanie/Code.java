package Przeciazanie;
import java.util.Scanner;

class Kalkulator{
    public int dodaj(int a, int b){
        return a+b;
    }

    public double dodaj(double a, double b){
        return a+b;
    }

    public int dodaj(String a, String b){
        return Integer.parseInt(a) + Integer.parseInt(b);
    }
}

public class Code {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Kalkulator kalkulator = new Kalkulator();

        System.out.println("Wybór typu danych dla kalkulatora");
        System.out.println("1 - liczby całkowite int");
        System.out.println("2 - liczby przecinkowe float");
        System.out.println("3 - liczby całkowite string");
        int wybor = scanner.nextInt();

        switch (wybor) {
            case 1:
                System.out.println("Podaj pierwsza liczbe calkowita: ");
                int int1 = scanner.nextInt();
                System.out.println("Podaj druga liczbe calkowita: ");
                int int2 = scanner.nextInt();
                int wynikInt = kalkulator.dodaj(int1, int2);
                System.out.println("Wynik dodawania: "+wynikInt);
                break;

            case 2:
                System.out.println("Podaj pierwsza liczbe zmiennoprzecinkowa: ");
                int dobule1 = scanner.nextInt();
                System.out.println("Podaj druga liczbe zmiennoprzecinkowa: ");
                int double2 = scanner.nextInt();
                int wynikDouble = kalkulator.dodaj(dobule1, double2);
                System.out.println("Wynik dodawania: "+wynikDouble);
                break;

            case 3:
                System.out.println("Podaj pierwsza liczbe tekstowa: ");
                int str1 = scanner.nextInt();
                System.out.println("Podaj druga liczbe tekstowa: ");
                int str2 = scanner.nextInt();
                int wynikStr = kalkulator.dodaj(str1, str2);
                System.out.println("Wynik dodawania: "+wynikStr);
                break;

            default:
                System.out.println("Błąd, niepoprawny wybór");
                break;
        }
        scanner.close();
    }
}

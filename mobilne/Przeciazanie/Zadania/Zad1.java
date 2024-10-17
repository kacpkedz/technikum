package Przeciazanie.Zadania;
import java.util.InputMismatchException;
import java.util.Scanner;

public class Zad1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = 0, m = 0;

        try {
            // Pobranie wymiarów tablicy od użytkownika
            System.out.print("Podaj liczbę wierszy (n): ");
            n = scanner.nextInt();
            System.out.print("Podaj liczbę kolumn (m): ");
            m = scanner.nextInt();
        } catch (InputMismatchException e) {
            System.out.println("Błąd! Proszę podać prawidłową liczbę całkowitą.");
            return;
        }

        // Sprawdzenie, czy tablica jest kwadratowa
        if (n != m) {
            System.out.println("Błąd! Tablica nie jest kwadratowa.");
            return;
        }

        // Tworzenie tablicy
        int[][] tablica = new int[n][m];

        // Wprowadzanie danych do tablicy
        System.out.println("Podaj elementy tablicy (liczby całkowite): ");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                try {
                    System.out.print("Element [" + i + "][" + j + "]: ");
                    tablica[i][j] = scanner.nextInt();
                } catch (InputMismatchException e) {
                    System.out.println("Błąd! Proszę wprowadzić prawidłową liczbę całkowitą.");
                    return;
                }
            }
        }

        // Obliczenie sumy na przekątnej
        int sumaPrzekatnej = 0;
        for (int i = 0; i < n; i++) {
            sumaPrzekatnej += tablica[i][i];  // Elementy na przekątnej mają indeksy [i][i]
        }
        
        // Wyświetlenie wyniku
        System.out.println("Suma elementów na przekątnej: " + sumaPrzekatnej);

        scanner.close();
    }
}
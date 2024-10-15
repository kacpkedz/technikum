package Przeciazanie.Matematyka;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Matematyka {

    // Przeciążone metody mnożenia
    public int pomnóż(int a, int b) {
        return a * b;
    }

    public int pomnóż(int a, int b, int c) {
        return a * b * c;
    }

    public double pomnóż(double a, double b) {
        return a * b;
    }

    public double pomnóż(double a, double b, double c) {
        return a * b * c;
    }

    public double pomnóż(int a, double b) {
        return a * b;
    }

    public double pomnóż(double a, int b) {
        return a * b;
    }

    // Przeciążone metody dzielenia
    public int dziel(int a, int b) {
        if (b == 0) {
            throw new ArithmeticException("Dzielenie przez zero!");
        }
        return a / b;
    }

    public double dziel(double a, double b) {
        if (b == 0.0) {
            throw new ArithmeticException("Dzielenie przez zero!");
        }
        return a / b;
    }

    public double dziel(int a, double b) {
        if (b == 0.0) {
            throw new ArithmeticException("Dzielenie przez zero!");
        }
        return a / b;
    }

    public double dziel(double a, int b) {
        if (b == 0) {
            throw new ArithmeticException("Dzielenie przez zero!");
        }
        return a / b;
    }

    // Główna metoda
    public static void main(String[] args) {
        Matematyka mat = new Matematyka();
        Scanner scanner = new Scanner(System.in);

        try {
            System.out.println("Wybierz działanie: ");
            System.out.println("1. Mnożenie");
            System.out.println("2. Dzielenie");
            int wybór = scanner.nextInt();

            switch (wybór) {
                case 1: // Mnożenie
                    System.out.println("Wybrałeś mnożenie. Wybierz wersję metody:");
                    System.out.println("1. Mnożenie 2 liczb całkowitych");
                    System.out.println("2. Mnożenie 3 liczb całkowitych");
                    System.out.println("3. Mnożenie 2 liczb zmiennoprzecinkowych");
                    System.out.println("4. Mnożenie 3 liczb zmiennoprzecinkowych");
                    System.out.println("5. Mnożenie liczby całkowitej i zmiennoprzecinkowej");
                    System.out.println("6. Mnożenie liczby zmiennoprzecinkowej i całkowitej");

                    int wybórMnożenie = scanner.nextInt();

                    switch (wybórMnożenie) {
                        case 1:
                            System.out.println("Podaj dwie liczby całkowite:");
                            int a1 = scanner.nextInt();
                            int b1 = scanner.nextInt();
                            System.out.println("Wynik: " + mat.pomnóż(a1, b1));
                            break;

                        case 2:
                            System.out.println("Podaj trzy liczby całkowite:");
                            int a2 = scanner.nextInt();
                            int b2 = scanner.nextInt();
                            int c2 = scanner.nextInt();
                            System.out.println("Wynik: " + mat.pomnóż(a2, b2, c2));
                            break;

                        case 3:
                            System.out.println("Podaj dwie liczby zmiennoprzecinkowe:");
                            double a3 = scanner.nextDouble();
                            double b3 = scanner.nextDouble();
                            System.out.println("Wynik: " + mat.pomnóż(a3, b3));
                            break;

                        case 4:
                            System.out.println("Podaj trzy liczby zmiennoprzecinkowe:");
                            double a4 = scanner.nextDouble();
                            double b4 = scanner.nextDouble();
                            double c4 = scanner.nextDouble();
                            System.out.println("Wynik: " + mat.pomnóż(a4, b4, c4));
                            break;

                        case 5:
                            System.out.println("Podaj liczbę całkowitą i zmiennoprzecinkową:");
                            int a5 = scanner.nextInt();
                            double b5 = scanner.nextDouble();
                            System.out.println("Wynik: " + mat.pomnóż(a5, b5));
                            break;

                        case 6:
                            System.out.println("Podaj liczbę zmiennoprzecinkową i całkowitą:");
                            double a6 = scanner.nextDouble();
                            int b6 = scanner.nextInt();
                            System.out.println("Wynik: " + mat.pomnóż(a6, b6));
                            break;

                        default:
                            System.out.println("Niepoprawny wybór.");
                            break;
                    }
                    break;

                case 2: // Dzielenie
                    System.out.println("Wybrałeś dzielenie. Wybierz wersję metody:");
                    System.out.println("1. Dzielenie 2 liczb całkowitych");
                    System.out.println("2. Dzielenie 2 liczb zmiennoprzecinkowych");
                    System.out.println("3. Dzielenie liczby całkowitej przez zmiennoprzecinkową");
                    System.out.println("4. Dzielenie liczby zmiennoprzecinkowej przez całkowitą");

                    int wybórDzielenie = scanner.nextInt();

                    switch (wybórDzielenie) {
                        case 1:
                            System.out.println("Podaj dwie liczby całkowite:");
                            int a1 = scanner.nextInt();
                            int b1 = scanner.nextInt();
                            System.out.println("Wynik: " + mat.dziel(a1, b1));
                            break;

                        case 2:
                            System.out.println("Podaj dwie liczby zmiennoprzecinkowe:");
                            double a2 = scanner.nextDouble();
                            double b2 = scanner.nextDouble();
                            System.out.println("Wynik: " + mat.dziel(a2, b2));
                            break;

                        case 3:
                            System.out.println("Podaj liczbę całkowitą i zmiennoprzecinkową:");
                            int a3 = scanner.nextInt();
                            double b3 = scanner.nextDouble();
                            System.out.println("Wynik: " + mat.dziel(a3, b3));
                            break;

                        case 4:
                            System.out.println("Podaj liczbę zmiennoprzecinkową i całkowitą:");
                            double a4 = scanner.nextDouble();
                            int b4 = scanner.nextInt();
                            System.out.println("Wynik: " + mat.dziel(a4, b4));
                            break;

                        default:
                            System.out.println("Niepoprawny wybór.");
                            break;
                    }
                    break;

                default:
                    System.out.println("Niepoprawny wybór.");
                    break;
            }

        } catch (ArithmeticException e) {
            System.out.println("Błąd arytmetyczny: " + e.getMessage());
        } catch (InputMismatchException e) {
            System.out.println("Błąd: niepoprawny typ danych. Proszę wprowadzić liczby.");
        } catch (Exception e) {
            System.out.println("Wystąpił błąd: " + e.getMessage());
        } finally {
            scanner.close();
        }
    }
}
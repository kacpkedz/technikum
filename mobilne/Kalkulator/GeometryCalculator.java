package Kalkulator;

/***
 * Klasa GeometryCalculator
 * Wzynaczanie pól koła i kwadratu
 * @author Kacper Kędziora
 * @version 1.0
 */

public class GeometryCalculator {

    /**
     * Oblicza pole kwadratu na podstawie długości boku
     *
     * @param dlugoscBoku długość boku kwadratu (typu double)
     * @return pole kwadratu (typu double)
     * @throws IllegalArgumentException jeśli długość boku jest ujemna

     */
    public double calculateSquareArea(double dlugoscBoku) {
        if (dlugoscBoku > 0) {
            return dlugoscBoku * dlugoscBoku;
        } else {
            throw new IllegalArgumentException("Wartość boku nie może być ujemna");
        }
    }

    /**
     * Oblicza pole koła na podstawie promienia
     *
     * @param promien promień koła (typu double)
     * @return pole koła (typu double)
     * @throws IllegalArgumentException jeśli promień jest ujemny
     */
    public double calculateCircleArea(double promien) {
        if (promien > 0) {
            return Math.PI * promien * promien;
        } else {
            throw new IllegalArgumentException("Wartość promienia nie może być ujemna");
        }
    }

    /**
     * Główna metoda prezentująca działanie kalkulatora
     * @param args lista argumentów
     */
    public static void main(String[] args) {
        GeometryCalculator calculator = new GeometryCalculator();
        
        double poleKwadratu = calculator.calculateSquareArea(5.0);
        System.out.println("Pole kwadratu: " + poleKwadratu);

        double poleKola = calculator.calculateCircleArea(3.0);
        System.out.println("Pole koła: " + poleKola);
    }
}
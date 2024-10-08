package KontoBankowe;
/***
 * Klasa konta bankowego
 * Realizuje wpłaty i wypłaty
 * @author Kacper Kędziora
 * @version 1.0
 */

public class KontoBankowe {
    private String numerKonta;
    private double saldo;

    /**
     * @throws IllegalArgumentsException
     * @param numerKonta
     * @param saldoPoczatkowe
     */
    public KontoBankowe(String numerKonta,  double saldoPoczatkowe) {
        if (numerKonta == null || numerKonta.isEmpty()) {
            throw new IllegalArgumentException("Numer konta nie może być pusty");
        }
        this.numerKonta = numerKonta;
        this.saldo = saldoPoczatkowe;
    }

    public double getSaldo() {
        return saldo;
    }

    public String getNumerKonta() {
        return numerKonta;
    }

    public void wplata(double kwota) {
        if (kwota > 0) {
            saldo += kwota;
            System.out.printf("Wpłacono %.2f PLN. Obecny stan konta to %.2f PLN", kwota, saldo);
        } else {
            System.out.println("Kwota wpłaty nie może być ujemna lub zerem");
        }
    }

    public void wyplata(double kwota) {
        if (kwota > 0 && kwota <= this.saldo) {
            saldo -= kwota;
            System.out.printf("Wypłacono %.2f PLN. Obecny stan konta to: %.2f PLN", kwota, saldo);
        } else {
            System.out.println("Kwota wypłaty nie może być ujemna lub większa od salda");
        }
    }

    public void saldoShow() {
        System.out.printf("Saldo: %.2f \n", getSaldo());
    }

    public static void main(String[] args) {
        KontoBankowe konto1 = new KontoBankowe("PL1231231231231231", 1000);
        
        System.out.println("Numer konta: " + konto1.getNumerKonta());
        System.out.printf("Saldo: \n", konto1.getSaldo());

        konto1.wplata(1000);
        konto1.saldoShow();
        konto1.wyplata(500);
        konto1.saldoShow();
        konto1.wyplata(20000);
        konto1.saldoShow();
    }
}

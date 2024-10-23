package NajwiekszyElement;

public class NajwiekszyElement {

    public static void main(String[] args) {
        int[] numbers = {12, 5, 8, 25, 17, 3, 9};
        int secondLargest = findSecondLargest(numbers);
        System.out.println("Drugi największy element w tablicy to: " + secondLargest);
    }

    public static int findSecondLargest(int[] array) {
        if (array.length < 2) {
            throw new IllegalArgumentException("Tablica musi zawierać co najmniej 2 elementy.");
        }

        int largest = Integer.MIN_VALUE;
        int secondLargest = Integer.MIN_VALUE;

        for (int num : array) {
            if (num > largest) {
                secondLargest = largest;
                largest = num;
            } else if (num > secondLargest && num != largest) {
                secondLargest = num;
            }
        }

        if (secondLargest == Integer.MIN_VALUE) {
            throw new IllegalArgumentException("Nie można znaleźć drugiego największego elementu.");
        }

        return secondLargest;
    }
}
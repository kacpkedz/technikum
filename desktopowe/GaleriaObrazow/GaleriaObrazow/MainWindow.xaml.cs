// Definicja przestrzeni nazw i zaimportowanie odpowiednich bibliotek
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GaleriaObrazow
{
    public partial class MainWindow : Window
    {
        // Ścieżka do katalogu z obrazami
        private readonly string sciezkaObrazow = @"C:\Users\t4\Desktop\PESEL\desktopowa\GaleriaObrazow\GaleriaObrazow\bin\Debug\net8.0-windows\pliki\images";

        // Ścieżka do pliku tekstowego z opisami
        private readonly string sciezkaOpisow = @"C:\Users\t4\Desktop\PESEL\desktopowa\GaleriaObrazow\GaleriaObrazow\bin\Debug\net8.0-windows\pliki\images\opisy.txt";

        // Tablica przechowująca opisy obrazów
        private string[] opisyObrazow;

        public MainWindow()
        {
            InitializeComponent();
            WczytajObrazy(); // Wywołanie metody do wczytania obrazów
        }

        // Metoda wczytująca obrazy z folderu oraz opisy z pliku tekstowego
        private void WczytajObrazy()
        {
            try
            {
                // Pobranie wszystkich plików z rozszerzeniem .jpg w katalogu z obrazami
                var plikiObrazow = Directory.GetFiles(sciezkaObrazow, "*.jpg");

                // Wczytanie wszystkich linii z pliku z opisami do tablicy
                opisyObrazow = File.ReadAllLines(sciezkaOpisow);

                // Zmienna liczbaOpisow przechowuje liczbę wczytanych opisów
                int liczbaOpisow = opisyObrazow.Length;

                // Pętla do przechodzenia przez wszystkie pliki obrazów
                for (int i = 0; i < plikiObrazow.Length; i++)
                {
                    // Tworzenie miniatury obrazu, ustawianie jej szerokości, wysokości i marginesu
                    var miniatura = new Image
                    {
                        Source = new BitmapImage(new Uri(plikiObrazow[i])), // Ładowanie obrazu
                        Width = 100, // Ustawienie szerokości miniatury
                        Height = 100, // Ustawienie wysokości miniatury
                        Margin = new Thickness(5) // Ustawienie marginesu wokół miniatury
                    };

                    int indeks = i; // Zmienna pomocnicza do przechowywania aktualnego indeksu

                    // Dodanie zdarzenia kliknięcia na miniaturę (wyświetlenie pełnego obrazu i opisu)
                    miniatura.MouseLeftButtonUp += (s, e) => WyswietlObraz(plikiObrazow[indeks], indeks < liczbaOpisow ? indeks : -1);

                    // Dodanie miniatury do kontenera, który wyświetla miniatury (ThumbnailPanel)
                    ThumbnailPanel.Children.Add(miniatura);
                }
            }
            catch (Exception ex)
            {
                // W przypadku błędu (np. brak plików lub opisy.txt) wyświetlany jest komunikat
                MessageBox.Show("Błąd podczas wczytywania obrazów lub opisów: " + ex.Message);
            }
        }

        // Metoda wyświetlająca pełny obraz oraz jego opis
        private void WyswietlObraz(string sciezkaObrazu, int indeks)
        {
            try
            {
                // Ładowanie pełnego obrazu do kontrolki Image
                MainImage.Source = new BitmapImage(new Uri(sciezkaObrazu));

                // Ustawianie tekstu w kontrolce TextBlock (do opisu obrazu)
                DescriptionText.Text = indeks >= 0 && indeks < opisyObrazow.Length
                    ? opisyObrazow[indeks] // Jeżeli indeks jest poprawny, wyświetlany opis
                    : "Brak opisu."; // Jeżeli nie ma opisu, wyświetlany tekst "Brak opisu."
            }
            catch (Exception ex)
            {
                // W przypadku błędu (np. problem z wyświetleniem obrazu) wyświetlamy komunikat
                MessageBox.Show("Błąd podczas wyświetlania obrazu: " + ex.Message);
            }
        }
    }
}

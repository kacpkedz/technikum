using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace Rownolegle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WybierzKatalogWejsciowy_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Title = "Wybierz katalog wejściowy",
                ValidateNames = false,
                FileName = "Wybór folderu"
            };

            if (dialog.ShowDialog() == true)
            {
                PoleKataloguWejsciowego.Text = Path.GetDirectoryName(dialog.FileName);
            }
        }

        private void WybierzKatalogWyjsciowy_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Title = "Wybierz katalog wyjściowy",
                ValidateNames = false,
                FileName = "Wybór folderu"
            };

            if (dialog.ShowDialog() == true)
            {
                PoleKataloguWyjsciowego.Text = Path.GetDirectoryName(dialog.FileName);
            }
        }

        private async void RozpocznijPrzetwarzanieFolder1_Click(object sender, RoutedEventArgs e)
        {
            await RozpocznijPrzetwarzanie("Folder 1");
        }

        private async void RozpocznijPrzetwarzanieFolder2_Click(object sender, RoutedEventArgs e)
        {
            await RozpocznijPrzetwarzanie("Folder 2");
        }

        private async Task RozpocznijPrzetwarzanie(string nazwaFolderu)
        {
            string katalogWejsciowy = PoleKataloguWejsciowego.Text;
            string katalogWyjsciowy = PoleKataloguWyjsciowego.Text;

            if (!Directory.Exists(katalogWejsciowy))
            {
                PoleLogu.Text += "Katalog wejściowy nie istnieje.\n";
                return;
            }

            if (!Directory.Exists(katalogWyjsciowy))
            {
                Directory.CreateDirectory(katalogWyjsciowy);
            }

            PoleLogu.Text += "Rozpoczynam przetwarzanie plików...\n";

            var pliki = Directory.GetFiles(katalogWejsciowy);

            var zadanie = PrzetwarzajPlikiAsync(katalogWejsciowy, katalogWyjsciowy, pliki, nazwaFolderu);

            await zadanie;

            PoleLogu.Text += $"Przetwarzanie zakończone dla {nazwaFolderu}.\n";
        }

        private async Task PrzetwarzajPlikiAsync(string katalogWejsciowy, string katalogWyjsciowy, string[] pliki, string nazwaFolderu)
        {
            object lockObject = new object();

            await Task.Run(() =>
            {
                Parallel.ForEach(pliki, (plik) =>
                {
                    lock (lockObject)
                    {
                        try
                        {
                            string nazwaPliku = Path.GetFileName(plik);
                            string zawartosc = File.ReadAllText(plik);
                            string przetworzonaZawartosc = zawartosc.ToUpper();

                            string katalogSpecyficznyDlaWątku = Path.Combine(katalogWyjsciowy, nazwaFolderu);
                            if (!Directory.Exists(katalogSpecyficznyDlaWątku))
                            {
                                Directory.CreateDirectory(katalogSpecyficznyDlaWątku);
                            }

                            string sciezkaPlikuWyjsciowego = Path.Combine(katalogSpecyficznyDlaWątku, nazwaPliku);
                            File.WriteAllText(sciezkaPlikuWyjsciowego, przetworzonaZawartosc);

                            Dispatcher.Invoke(() =>
                            {
                                PoleLogu.Text += $"Przetworzono {nazwaPliku} w {nazwaFolderu}\n";
                            });
                        }
                        catch (Exception ex)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                PoleLogu.Text += $"Błąd podczas przetwarzania pliku w {nazwaFolderu}: {ex.Message}\n";
                            });
                        }
                    }
                });
            });
        }
    }
}
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace ApkaNaĆwiczenie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string sciezka = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRejestruj_Click(object sender, RoutedEventArgs e)
        {
            Regex ptrnEmail = new Regex(@"^[A-Za-z0-9._-]+@[A-Za-z-.]+.[a-z]{2,}$");
            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string email = txtEmail.Text;
            string plec = rdKobieta.IsChecked == true ? "Kobieta" : "Mężczyzna";
            string palacy = rdTak.IsChecked == true ? "Palący" : "Niepalący";

            if (!ptrnEmail.IsMatch(email)) {
                MessageBox.Show("Podaj poprawy email!");
            } else
            {
                Window1 okno = new Window1(imie, nazwisko, email, plec, palacy, sciezka);
                okno.Show();
            }
        }

        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Prześlij obraz (*.png;*.jpg)|*.png;*.jpg",
                Multiselect = false
            };

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    MessageBox.Show("Poprawnie załadowano zdjęcie");
                    imgZdjecie.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    sciezka = openFileDialog.FileName;

                    if (sciezka != "")
                    {
                        btnRejestruj.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex}");
            }
        }
    }
}
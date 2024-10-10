using System.Reflection.Metadata.Ecma335;
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
using static System.Net.WebRequestMethods;

namespace Ćwieczenia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSprawdź_Click(object sender, RoutedEventArgs e)
        {
            string ptrnSprawdz = @"\w{2}-\w{2}-\w{4}";
            string txtSprawdz = txtBoxData.Text;

            Regex regexSprawdz = new Regex(ptrnSprawdz);
            MatchCollection sprawdzanie = regexSprawdz.Matches(txtSprawdz);

            foreach (Match m in sprawdzanie)
            {
                MessageBox.Show($"{m}", "Wypis dat", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnPesel_Click(object sender, RoutedEventArgs e)
        {
            string ptrnPesel = @"^\d{11}$";
            string txtPesel = txtBoxPesel.Text;

            Regex regexPesel = new Regex(ptrnPesel);
            bool pesel = regexPesel.IsMatch(txtPesel);

            if (pesel == true)
            {
                MessageBox.Show("Poprawny pesel", "Sprawdź pesel", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Wprowadź poprawny pesel", "Sprawdź pesel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnWypisz_Click(object sender, RoutedEventArgs e)
        {
            string ptrnLitery = @"\b[A-Z][a-z]*\b";
            string txtLitery = txtBoxLitery.Text;

            Regex regexLitery = new Regex(ptrnLitery);
            MatchCollection litery = regexLitery.Matches(txtLitery);

            foreach (Match match in litery)
            {
                MessageBox.Show($"{match.Value}", "Wielkie litery", MessageBoxButton.OK , MessageBoxImage.Information);
            }
        }

        private void btnUrl_Click(object sender, RoutedEventArgs e)
        {
            string ptrnUrl = @"\bhttps?:\/\/[^\s/$.?#_].[^\s]{2,}";
            string txtUrl = txtBoxUrl.Text;

            Regex regexUrl = new Regex(ptrnUrl);
            MatchCollection url = regexUrl.Matches(txtUrl);

            foreach (Match match in url)
            {
                MessageBox.Show($"{match.Value}", "Url", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
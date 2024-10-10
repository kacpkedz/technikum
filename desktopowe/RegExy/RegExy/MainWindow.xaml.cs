using System.Text;
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
using System.Runtime.CompilerServices;

namespace RegExy
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

        private void btnKodpocztowy_Click_1(object sender, RoutedEventArgs e)
        {
            string ptrnKodpocztowy = @"^\d{2}-\d{3}$";
            string inputKodpocztowy = txtBoxKodpocztowy.Text;

            bool isValidKod = Regex.IsMatch(inputKodpocztowy, ptrnKodpocztowy);

            if (isValidKod)
            {
                MessageBox.Show("Kod jest poprawny", "Sprawdzanie kodu", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Kod jest nie poprawny", "Błąd kodu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            string ptrnEmail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$";
            string ptrnEmail2 = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string inputEmail = txtBoxEmail.Text;

            Regex regex = new Regex(ptrnEmail);
            bool isValidEmail = regex.IsMatch(inputEmail);

            if (isValidEmail)
            {
                MessageBox.Show("Email jest poprawny", "Sprawdzanie maila", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Email jest nie poprawny", "Błąd maila", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnNumer_Click(object sender, RoutedEventArgs e)
        {
            string ptrnNumer = @"\d{3}-\d{3}-\d{3}";
            string numeryTel = txtBoxNumer.Text;

            Regex regexTel = new Regex(ptrnNumer);
            MatchCollection matches = regexTel.Matches(numeryTel);

            foreach (Match m in matches)
            {
                MessageBox.Show($"{m}", "Numer telefonu", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            string ptrnDate = @"(\d{4})-(\d{2})-(\d{2})";
            string replaceDate = "$3-$2-$1";
            string txtData = txtBoxData.Text;
            
            Regex regexData = new Regex(ptrnDate);
            string newData = regexData.Replace(txtData, replaceDate);

            MessageBox.Show($"Nowa data: {newData}", "Format daty", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnUsuwanie_Click(object sender, RoutedEventArgs e)
        {
            string ptrnZdanie = @"\s+";
            string txtZdanie = txtBoxTekst.Text;

            Regex regexZdanie = new Regex(ptrnZdanie);
            string newZdanie = regexZdanie.Replace(txtZdanie, " ");

            MessageBox.Show($"{newZdanie}", "Usuwanie zbędnych spacji", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnPodmien_Click(object sender, RoutedEventArgs e)
        {
            string ptrnZdanie2 = @"tulipan|róża|goździk|hortensja";
            string txtZdanie2 = txtBoxTekst2.Text;

            Regex regexZdanie2 = new Regex(ptrnZdanie2);
            string newZdanie2 = regexZdanie2.Replace(txtZdanie2, "kwiatek");

            MessageBox.Show($"Nowe zdanie: {newZdanie2}", "Zmiana wyrazów", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnWymien_Click(object sender, RoutedEventArgs e)
        {
            string ptrnZdanie3 = @",";
            string txtZdanie3 = txtBoxTekst3.Text;

            Regex regexZdanie3 = new Regex(ptrnZdanie3);
            string[] jezyki = regexZdanie3.Split(txtZdanie3);

            foreach (string jezyk in jezyki)
            {
                MessageBox.Show($"{jezyki}", "Języki", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
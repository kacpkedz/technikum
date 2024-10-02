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
    }
}
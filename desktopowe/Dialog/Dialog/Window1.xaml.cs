using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Dialog
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    { 
        public Contact Contact { get; private set; }
        public Window1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (Sprawdzanie())
            {
                Contact = new Contact
                {
                    imie = txtImie.Text,
                    nazwisko = txtNazwisko.Text,
                    email = txtEmail.Text
                };
                this.DialogResult = true;
            } else
            {
                MessageBox.Show("Podaj poprawne dane!");
            }
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool Sprawdzanie()
        {
            return ImieNazwiskoSieZgadza(txtImie.Text) && ImieNazwiskoSieZgadza(txtNazwisko.Text) && EmailSieZgadza(txtEmail.Text);
        }

        private bool ImieNazwiskoSieZgadza(string nazwa)
        {
            return Regex.IsMatch(nazwa, @"^[a-zA-Z]+$");
        }

        private bool EmailSieZgadza(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
using Microsoft.Win32;
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

namespace Sound
{
    public partial class MainWindow : Window
    {
        private MediaPlayer player = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki dźwiękowe (*.mp3; *.wav) | *.mp3; *.wav";
            if (openFileDialog.ShowDialog() == true) {
                player.Stop();
                player.Open(new Uri(openFileDialog.FileName));
                player.Stop();
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }
    }
}
using System.IO;
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

namespace ZmianaNazwy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private string selectedPath;
        public MainWindow()
        {
            InitializeComponent();
            LoadFolderTree();
        }

        private void LoadFolderTree()
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var driveItem = new TreeViewItem
                {
                    Header = drive,
                    Tag = drive
                };

                driveItem.Expanded += Folder_Expanded;
                FolderTreeView.Items.Add(driveItem);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (item.Items.Count != 0) return;

            item.Items.Clear();

            var fullPath = (string)item.Tag;

            try
            {
                var directories = Directory.GetDirectories(fullPath);
                foreach(var directory in directories)
                {
                    var subItem = new TreeViewItem
                    {
                        Header = System.IO.Path.GetFileName(directory),
                        Tag = directory
                    };
                    subItem.Expanded += Folder_Expanded;
                    item.Items.Add(subItem);
                }
                var files = Directory.GetFiles(fullPath);
                foreach (var file in files)
                {
                    var subItem = new TreeViewItem
                    {
                        Header = System.IO.Path.GetFileName(file),
                        Tag = file
                    };
                    item.Items.Add(subItem);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania katalogu: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void FolderTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = (TreeViewItem)FolderTreeView.SelectedItem;
            if (selectedItem != null) { 
            selectedPath = (string)selectedItem.Tag;
                SelectedPathTextBox.Text = selectedPath;
                RenameTextBox.Text = System.IO.Path.GetFileName(selectedPath);
            }
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedPath) || string.IsNullOrEmpty(RenameTextBox.Text)) 
            {
                MessageBox.Show("Wybierz element do zmiany nazwy");
                return;
            }
            try
            {
                var directoryPath = System.IO.Path.GetDirectoryName(selectedPath);
                var newPath = System.IO.Path.Combine(directoryPath, RenameTextBox.Text);

                if (File.Exists(selectedPath))
                {
                    File.Move(selectedPath, newPath);
                }
                else if (Directory.Exists(selectedPath))
                {
                    Directory.Move(selectedPath, newPath);
                }

                MessageBox.Show("Nazwa została zmieniona");
                SelectedPathTextBox.Text = newPath;
                selectedPath = newPath;
                RefreshTreeView();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Błąd podczas zmiany nazwy" + ex.Message);
            }
        }   
        private void RefreshTreeView()
        {
            FolderTreeView.Items.Clear();
            LoadFolderTree();
        }
    }
}
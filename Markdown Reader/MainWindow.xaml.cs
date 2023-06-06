using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Markdown_Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            Loaded += MainWindow_Loaded1;
            InitializeComponent();

        }

        private void MainWindow_Loaded1(object sender, RoutedEventArgs e)
        {
            FileContents(sender, e);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FileList(sender, e);
        }

        private void FileList(object sender, RoutedEventArgs e)
        {
            string[] fileEntries = Directory.GetFiles(@"C:\Users\dinos\Documents\games\cslol-manager\");
            foreach (string fileName in fileEntries)
            {
                List<string> sPath = fileName.Split('\\').ToList();
                if (sPath.Last() == null) {
                    continue;
                }
                if (sPath.Last().Contains("exe"))
                {
                    continue;
                }
                fileList.Items.Add(sPath.Last());
            }
        }

        private void FileContents(object sender, RoutedEventArgs e)
        {
            fileList.SelectedItem = fileList.Items[0];
            string contents = File.ReadAllText(@"C:\Users\dinos\Documents\games\cslol-manager\" + fileList.SelectedItem);
            fileContents.Text = contents;
        }

        private void fileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string contents = File.ReadAllText(@"C:\Users\dinos\Documents\games\cslol-manager\" + fileList.SelectedItem);
            fileContents.Text = contents;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using Scanner.Model;
using System;
using System.Collections.Generic;
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

namespace Scanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Scan> items = new List<Scan>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartScan(object sender, RoutedEventArgs e)
        {
            items.Add(new Scan() { Ip = "192.168.1.1", Port = 42, IsOpen = "Yes" });
            lvUsers.ItemsSource = items;
        }
    }
}

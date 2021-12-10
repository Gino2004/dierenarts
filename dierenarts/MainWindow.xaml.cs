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

namespace dierenarts
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dieren hetForm = new dieren();
            hetForm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            eigenaar hetForm = new eigenaar();
            hetForm.Show();
        }

        private void btnafspraak_Click(object sender, RoutedEventArgs e)
        {
            Afspraak hetForm = new Afspraak();
            hetForm.Show();
        }

        private void btnbaasdier_Click(object sender, RoutedEventArgs e)
        {
            baasdier hetForm = new baasdier();
            hetForm.Show();
        }
    }
}

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
using System.Windows.Shapes;

namespace dierenarts
{
    /// <summary>
    /// Interaction logic for Dierenwijzigen.xaml
    /// </summary>
    public partial class Dierenwijzigen : Window
    {
        private dier deDieren;

        private dierenartsDataContext db;
        public Dierenwijzigen( dierenartsDataContext db, dier  deDieren)
        {
            InitializeComponent();
            this.db = db;
            this.deDieren = deDieren;
            txtnaam.Text = deDieren.naam;
            txtdiersoort.Text = deDieren.diersoort;
        }

        private void btnopslaan_Click(object sender, RoutedEventArgs e)
        {
            deDieren.naam = txtnaam.Text;
            deDieren.diersoort = txtdiersoort.Text;
            db.SubmitChanges();
            MessageBox.Show("succesvol gewijzigd ");
        }

        private void btnterug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

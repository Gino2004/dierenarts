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
    /// Interaction logic for Afspraakwijzigen.xaml
    /// </summary>
    public partial class Afspraakwijzigen : Window
    {

        private afspraak deAfspraak;

        private dierenartsDataContext db;
        public Afspraakwijzigen(dierenartsDataContext db, afspraak deAfspraak)
        {
            InitializeComponent();
            this.deAfspraak = deAfspraak;
            this.db = db;
            Combodier();
            cbdieren.SelectedItem = deAfspraak.dier;
            txttijd.Text = deAfspraak.tijd;
            dpdatum.SelectedDate = deAfspraak.datum;
            txtafspraaksoort.Text = deAfspraak.afspraaksoort;
            
        }

        public void Combodier()
        {
            var dierentabelrecords = db.diers.ToList();
            cbdieren.ItemsSource = dierentabelrecords;
        }
        private void btnwijzig_Click(object sender, RoutedEventArgs e)
        {
            dier selecteditem = (dier)cbdieren.SelectedItem;
            deAfspraak.dier = selecteditem;
            deAfspraak.tijd = txttijd.Text;
            deAfspraak.datum = dpdatum.SelectedDate.Value;
            deAfspraak.afspraaksoort = txtafspraaksoort.Text;
            db.SubmitChanges();
            MessageBox.Show("succesvol gewijzigd");
           
        }

        private void btnmenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

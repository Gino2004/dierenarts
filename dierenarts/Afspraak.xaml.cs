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
    /// Interaction logic for Afspraak.xaml
    /// </summary>
    public partial class Afspraak : Window
    {
        dierenartsDataContext db = new dierenartsDataContext();
        
        public Afspraak()
        {
            InitializeComponent();
            combodieren();
            dgafspraak.ItemsSource = db.afspraaks.ToList();
        }
        public void combodieren()
        {

            var dierentabelrecords = (from dier in db.diers select dier);
            combodier.ItemsSource = dierentabelrecords;
        }
        private void btnopslaan_Click(object sender, RoutedEventArgs e)
        {
            dier selecteditem = (dier)combodier.SelectedItem;
            DateTime dafspraak = dpafspraak.SelectedDate.Value;
            afspraak ak = new afspraak();
            ak.dier = selecteditem;
            ak.tijd = txttijd.Text;
            ak.datum = Convert.ToDateTime(dafspraak);
            ak.afspraaksoort = txtafspraaksoort.Text;

            db.afspraaks.InsertOnSubmit(ak);
            db.SubmitChanges();

        }

        private void btnfilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime df = (DateTime)dpfilter.SelectedDate;
            var query = (from afspraak in db.afspraaks where df == afspraak.datum select afspraak);
            dgafspraak.ItemsSource = query.ToList();
        }

        private void btnafspraak_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnwijzig_Click(object sender, RoutedEventArgs e)
        {
            afspraak deAfspraak = (afspraak)dgafspraak.SelectedItem;
            Afspraakwijzigen hetForm = new Afspraakwijzigen(db, deAfspraak);
            hetForm.Show();
        }

        private void btnverwijderen_Click(object sender, RoutedEventArgs e)
        {
            afspraak deafspraak = (afspraak)dgafspraak.SelectedItem;
            int id = deafspraak.afspraakid;
            db.afspraaks.DeleteOnSubmit(deafspraak);
            db.SubmitChanges();
            dgafspraak.ItemsSource = db.afspraaks.ToList();
        }
    }
}

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
    /// Interaction logic for dieren.xaml
    /// </summary>
    public partial class dieren : Window
    {
        dierenartsDataContext db = new dierenartsDataContext();
        public dieren()
        {
            InitializeComponent();
            dgdieren.ItemsSource = db.diers.ToList();
        }

        private void btnterug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnopslaan_Click(object sender, RoutedEventArgs e)
        {
            string snaam = txtnaam.Text;
            string sdiersoort= txtdiersoort.Text;


            dier dieren = new dier();

            dieren.naam = snaam;

            dieren.diersoort = sdiersoort;

            db.diers.InsertOnSubmit(dieren);
            db.SubmitChanges();
        }

        private void btnwijzig_Click(object sender, RoutedEventArgs e)
        {
            dier deDieren = (dier)dgdieren.SelectedItem;
            Dierenwijzigen hetForm = new Dierenwijzigen(db, deDieren);
            hetForm.Show();
        }

        private void btnverwijderen_Click(object sender, RoutedEventArgs e)
        {
            dier dieren = (dier)dgdieren.SelectedItem;
            int id = dieren.dierid;
            db.diers.DeleteOnSubmit(dieren);
            db.SubmitChanges();

            dgdieren.ItemsSource = db.diers.ToList();
        }
    }
}

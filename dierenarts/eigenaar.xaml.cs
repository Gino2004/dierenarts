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
    /// Interaction logic for eigenaar.xaml
    /// </summary>
    public partial class eigenaar : Window
    {
        dierenartsDataContext db = new dierenartsDataContext();
        public eigenaar()
        {
            InitializeComponent();
            dgbazen.ItemsSource = db.baas.ToList();
        }

        private void btnterug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnversturen_Click(object sender, RoutedEventArgs e)
        {
            string svoornaam = txtvoornaam.Text;
            string sachternaam = txtachternaam.Text;
            string sadres = txtadres.Text;
            string spostcode = txtpostcode.Text;
            string swoonplaats = txtwoonplaats.Text;
            string stelefoon = txttelefoon.Text;
            string semail = txtemail.Text;

            baa klant = new baa();

            klant.voornaam = svoornaam;

            klant.achternaam = sachternaam;

            klant.adres = sadres;

            klant.postcode = spostcode;

            klant.woonplaats = swoonplaats;


            klant.telefoon = Convert.ToInt32(stelefoon);

            klant.email = semail;



            db.baas.InsertOnSubmit(klant);
            db.SubmitChanges();
        }

        private void btnwijzig_Click(object sender, RoutedEventArgs e)
        {
            baa deBaas = (baa)dgbazen.SelectedItem;
            bazenwijzigen hetForm = new bazenwijzigen(db, deBaas);
            hetForm.Show();
        }

        private void btnverwijderen_Click(object sender, RoutedEventArgs e)
        {
            baa klant = (baa)dgbazen.SelectedItem;
            int id = klant.baasid;
            db.baas.DeleteOnSubmit(klant);
            db.SubmitChanges();

            dgbazen.ItemsSource = db.baas.ToList();
        }
    }
}

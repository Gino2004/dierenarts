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
    /// Interaction logic for bazenwijzigen.xaml
    /// </summary>
    public partial class bazenwijzigen : Window
    {
        private baa deBaas;

        private dierenartsDataContext db;
        public bazenwijzigen(dierenartsDataContext db, baa deBaas)
        {
            InitializeComponent();
            this.db = db;
            this.deBaas = deBaas;
            txtvoornaam.Text = deBaas.voornaam;
            txtachternaam.Text = deBaas.achternaam;
            txtadres.Text = deBaas.adres;
            txtpostcode.Text = deBaas.postcode;
            txtwoonplaats.Text = deBaas.woonplaats;
            txttelefoon.Text = deBaas.telefoon.ToString();
            txtemail.Text = deBaas.email;
           
        }

        private void btnopslaan_Click(object sender, RoutedEventArgs e)
        {
            deBaas.voornaam = txtvoornaam.Text;
            deBaas.achternaam = txtachternaam.Text;
            deBaas.adres = txtadres.Text;
            deBaas.postcode = txtpostcode.Text;
            deBaas.woonplaats = txtwoonplaats.Text;
            deBaas.telefoon = Convert.ToInt32(txttelefoon.Text);
            deBaas.email = txtemail.Text;
            db.SubmitChanges();
            MessageBox.Show("succesvol gewijzigd");
        }

        private void btnterug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for baasdier.xaml
    /// </summary>
    public partial class baasdier : Window
    {
        dierenartsDataContext db = new dierenartsDataContext();
        public baasdier()
        {
            InitializeComponent();
            Combobazen();
            Combodier();
        }
        public void Combobazen()
        {
            var bazentabelrecords = (from baa in db.baas select baa);
            combobaas.ItemsSource = bazentabelrecords;
        }
        public void Combodier()
        {
            var dierentabelrecords = (from dier in db.diers select dier);
            combodier.ItemsSource = dierentabelrecords;
        }
        private void btnopslaandierbaas_Click(object sender, RoutedEventArgs e)
        {
            baa selecteditem = (baa)combobaas.SelectedItem;
            dier selecteeditem = (dier)combodier.SelectedItem;
            baas_dier bd = new baas_dier();
            bd.baa = selecteditem;
            bd.dier = selecteeditem;

            db.baas_diers.InsertOnSubmit(bd);
            db.SubmitChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

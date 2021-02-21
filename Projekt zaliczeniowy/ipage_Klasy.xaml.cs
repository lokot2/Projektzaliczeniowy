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

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy ipage_Klasy.xaml
    /// </summary>
    public partial class ipage_Klasy : Window
    {

        szkolaEntities _db = new szkolaEntities();
        public ipage_Klasy()
        {
            InitializeComponent();
        }

        private void iButton_Click(object sender, RoutedEventArgs e)
        {
            Klasa newclass = new Klasa()
            {

                Klasa1 = answer1.Text


            };

            _db.Klasa.Add(newclass);
            _db.SaveChanges();
            Klasy.datagrid.ItemsSource = _db.Klasa.ToList();
            this.Hide();
        }
    }
}

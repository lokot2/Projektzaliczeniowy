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
    /// Logika interakcji dla klasy ipage.xaml
    /// </summary>
    public partial class ipage_nauczyciele : Window
    {
        szkolaEntities _db = new szkolaEntities();



        public ipage_nauczyciele()
        {
            InitializeComponent();
           
        }
     


        private void iButton_Click(object sender, RoutedEventArgs e)
        {
           
            nauczyciele newTeacher = new nauczyciele()
            {
                imie = answer1.Text,
                nazwisko = answer2.Text,
                płeć = icombobox.Text,


            };

            _db.nauczyciele.Add(newTeacher);
            _db.SaveChanges();
            Nauczyciele.datagrid.ItemsSource = _db.nauczyciele.ToList();
            this.Hide();
        }


    }
}

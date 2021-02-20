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
    public partial class ipage : Window
    {
        szkolaEntities _db = new szkolaEntities();

        

        public ipage()
        {
            InitializeComponent();
            wybor_kalsy();
        }
        public List<Klasa> dostepne_klasy{ get; set; }
        private void wybor_kalsy()
        {
            var item = _db.Klasa.ToList();
            dostepne_klasy = item;
            DataContext = dostepne_klasy;
        }

    
        private void iButton_Click(object sender, RoutedEventArgs e)
        {
            var id_klasy = klasa_icombobox.SelectedItem as Klasa;
            uczniowie newStudent = new uczniowie()
            {
                imie = answer1.Text,
                nazwisko= answer2.Text,
                płeć = icombobox.Text,
                klasa = id_klasy.id


            };

            _db.uczniowie.Add(newStudent);
            _db.SaveChanges();
            StudentsPage.datagrid.ItemsSource = _db.uczniowie.ToList();
            this.Hide();
        }

        
    }
}

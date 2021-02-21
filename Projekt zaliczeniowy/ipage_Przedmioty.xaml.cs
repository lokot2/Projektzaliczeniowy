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
    public partial class ipage_Przedmioty : Window
    {
        szkolaEntities _db = new szkolaEntities();



        public ipage_Przedmioty()
        {
            InitializeComponent();
           
            wybor_nauczyciela();
        }
        public List<Klasa> dostepne_klasy { get; set; }
        private void wybor_kalsy()
        {
            var item = _db.Klasa.ToList();
            dostepne_klasy = item;
            DataContext = dostepne_klasy;
        }

        public List<nauczyciele> dostepny_nauczyciele { get; set; }
        private void wybor_nauczyciela()
        {
            var item = _db.nauczyciele.ToList();
            dostepny_nauczyciele = item;
            DataContext = dostepny_nauczyciele;
        }


        private void iButton_Click(object sender, RoutedEventArgs e)
        {
            var id_klasy = klasa_icombobox.SelectedItem as Klasa;
            var id_nauczyciel= nauczyciel_icombobox.SelectedItem as nauczyciele;
            Przedmiot newsubject = new Przedmiot()
            {
                nazwa = answer1.Text,
                nauczyciel= id_nauczyciel.id,
                klasa = id_klasy.id


            };

            _db.Przedmiot.Add(newsubject);
            _db.SaveChanges();
            StudentsPage.datagrid.ItemsSource = _db.Przedmiot.ToList();
            this.Hide();
        }

        private void nauczyciel_icombobox_MouseMove(object sender, MouseEventArgs e)
        {
            

            wybor_nauczyciela();
        }

        private void klasa_icombobox_MouseMove(object sender, MouseEventArgs e)
        {
            wybor_kalsy();
        }
    }
}

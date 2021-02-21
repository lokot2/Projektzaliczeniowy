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
    public partial class UIPage_Przedmioty : Window
    {
        szkolaEntities _db = new szkolaEntities();
        public int Id;



        public UIPage_Przedmioty(int student_id)
        {
            InitializeComponent();
            Id = student_id;
            autoexample();

        }

        private void autoexample()
        {


            Przedmiot newSubject = new Przedmiot();
            nauczyciele newTeacher = new nauczyciele();
            Klasa newklasa = new Klasa();


            newSubject.id = Id;

            newSubject = _db.Przedmiot.Where(x => x.id == newSubject.id).FirstOrDefault();
            answer1.Text = newSubject.nazwa;
  
            newklasa.id = newSubject.klasa.Value;
            newTeacher.id= newSubject.nauczyciel.Value;
            newklasa = _db.Klasa.Where(z => z.id == newklasa.id).FirstOrDefault();
            newklasa = _db.Klasa.Where(y => y.id == newTeacher.id).FirstOrDefault();
            MessageBox.Show("załądowane dane");
            klasa_icombobox.Text = newklasa.Klasa1;
            nauczyciel_icombobox.Text = newTeacher.nazwisko;



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
            var id_nauczyciel = nauczyciel_icombobox.SelectedItem as nauczyciele;
            Przedmiot newsubject = new Przedmiot()
            {
                nazwa = answer1.Text,
                nauczyciel = id_nauczyciel.id,
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

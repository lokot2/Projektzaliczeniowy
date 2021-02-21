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
    /// Logika interakcji dla klasy UIPage.xaml
    /// </summary>
    public partial class UIPage : Window
    {
        szkolaEntities _db = new szkolaEntities();
        public int Id;

        public UIPage(int student_id)
        {
            Id = student_id;
            InitializeComponent();
            wybor_kalsy();
          autoexample();


        }

        private void autoexample()
        {


            uczniowie newStudent = new uczniowie();
            Klasa newklasa = new Klasa();


            newStudent.id = Id;
           
            newStudent = _db.uczniowie.Where(x => x.id == newStudent.id).FirstOrDefault();
            answer1.Text = newStudent.imie;
            answer2.Text = newStudent.nazwisko;
            icombobox.Text = newStudent.płeć;
             newklasa.id=newStudent.klasa.Value;
            newklasa = _db.Klasa.Where(z => z.id == newklasa.id).FirstOrDefault();
            MessageBox.Show("załądowane dane");
            klasa_icombobox.Text = newklasa.Klasa1;




        }
        public List<Klasa> dostepne_klasy { get; set; }
        private void wybor_kalsy()
        {
            var item = _db.Klasa.ToList();
            dostepne_klasy = item;
            DataContext = dostepne_klasy;
        }

        private void iButton_Click(object sender, RoutedEventArgs e)
        {
            
            var id_klasy = klasa_icombobox.SelectedItem as Klasa;
            uczniowie updatestudent = (from item in _db.uczniowie
                                       where item.id == Id
                                       select item).Single();
          
            updatestudent.imie = answer1.Text;
            updatestudent.nazwisko = answer2.Text;
            updatestudent.płeć = icombobox.Text;
            updatestudent.klasa =id_klasy.id;
            _db.SaveChanges();
            StudentsPage.datagrid.ItemsSource = _db.uczniowie.ToList();
            this.Hide();
        }
    }
}

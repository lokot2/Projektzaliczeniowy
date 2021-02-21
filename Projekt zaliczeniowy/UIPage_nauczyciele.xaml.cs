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
    public partial class UIPage_nauczyciele : Window
    {
        szkolaEntities _db = new szkolaEntities();
        public int Id;

        public UIPage_nauczyciele(int student_id)
        {
            Id = student_id;
            InitializeComponent();
   
            autoexample();


        }

        private void autoexample()
        {


            nauczyciele newTeacher = new nauczyciele();
            Klasa newklasa = new Klasa();


            newTeacher.id = Id;

            newTeacher = _db.nauczyciele.Where(x => x.id == newTeacher.id).FirstOrDefault();
            answer1.Text = newTeacher.imie;
            answer2.Text = newTeacher.nazwisko;
            icombobox.Text = newTeacher.płeć;
           
            MessageBox.Show("załądowane dane");
         




        }
       

        private void iButton_Click(object sender, RoutedEventArgs e)
        {

            
            nauczyciele updatestudent = (from item in _db.nauczyciele
                                       where item.id == Id
                                       select item).Single();

            updatestudent.imie = answer1.Text;
            updatestudent.nazwisko = answer2.Text;
            updatestudent.płeć = icombobox.Text;
    
            _db.SaveChanges();
            Nauczyciele.datagrid.ItemsSource = _db.nauczyciele.ToList();
            this.Hide();
        }
    }
}

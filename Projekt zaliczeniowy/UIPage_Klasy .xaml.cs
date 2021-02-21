
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
    public partial class UIPage_Klasy : Window
    {
        szkolaEntities _db = new szkolaEntities();
        public int Id;

        public UIPage_Klasy(int student_id)
        {
            Id = student_id;
            InitializeComponent();
       
            autoexample();


        }

        private void autoexample()
        {


            Klasa newklasa = new Klasa();

            newklasa.id = Id;

            newklasa = _db.Klasa.Where(z => z.id == newklasa.id).FirstOrDefault();
            MessageBox.Show("załądowane dane");
            answer1.Text = newklasa.Klasa1;
       



        }
   

        private void iButton_Click(object sender, RoutedEventArgs e)
        {

          
            Klasa nowa_Klasa = (from item in _db.Klasa
                                       where item.id == Id
                                       select item).Single();

            nowa_Klasa.Klasa1=answer1.Text;

            _db.SaveChanges();
            Klasy.datagrid.ItemsSource = _db.Klasa.ToList();
            this.Hide();
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace uchebka322mat.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        private List_Student list_student;
        public AddStudentPage(Exemp exemp)
        {
            InitializeComponent();
            list_student = new List_Student();
            list_student.id_Exemp = exemp.id;
            DataContext = list_student;
            Student[] usedStudents = App.db.List_Student.Where(x => x.id_Examen == list_student.id_Examen).Select(x => x.Student).ToArray();
            StudentCb.ItemsSource = App.db.Student.ToArray().Except(usedStudents).ToArray();
        }
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                App.db.List_Student.Add(list_student);
                App.db.SaveChanges();
                App.MainFrame.Navigate(new ExamListPage());
            }
        }

        private bool CheckFields()
        {
            if (list_student.id_student == null)
            {
                MessageBox.Show("Выберите студента");
                return false;
            }
            else
                return true;
        }

        private void OcenkaTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
                list_student.ocenka = int.Parse((sender as TextBox).Text);
            else
                list_student.ocenka = null;
        }

        private void OcenkaTbPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) || int.Parse(e.Text) < 1 || int.Parse(e.Text) > 5)
            {
                e.Handled = true;
            }
        }

        private void StudentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list_student.id_student = ((sender as ComboBox).SelectedItem as Student).RegNomer;
        }
    }
}

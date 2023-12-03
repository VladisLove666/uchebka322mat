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
using uchebka322mat.Pages;

namespace uchebka322mat.Components
{
    /// <summary>
    /// Логика взаимодействия для ExamenUserControl.xaml
    /// </summary>
    public partial class ExamenUserControl : UserControl
    {
        private Exemp exemp;
        public ExamenUserControl()
        {
            InitializeComponent();
            this.exemp = exemp;
            DataContext = exemp;
            List_Student[] list_student = App.db.List_Student.Where(x => x.id_Exemp == exemp.id).ToArray();
            foreach (List_Student e_s in list_student)
            {
                StudentsWp.Children.Add(new StudentUserControl(e_s));
            }
            FamiliaSortCb.SelectedIndex = 0;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddStudentPage(exemp));
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            List_Student[] list_student = App.db.List_Student.Where(x => x.id_Exemp == exemp.Id).ToArray();
            switch (FamiliaSortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    list_student = list_student.OrderBy(x => x.Student.Familia).ToArray();
                    break;
                case 2:
                    list_student = list_student.OrderByDescending(x => x.Student.Familia).ToArray();
                    break;
            }
            if (SearchTb.Text != "")
                list_student = list_student.Where(x => x.Student.Surname.ToLower().Contains(SearchTb.Text.ToLower())).ToArray();
            StudentsWp.Children.Clear();
            foreach (List_Student e_s in list_student)
            {
                StudentsWp.Children.Add(new StudentUserControl(e_s));
            }
        }

        private void FamiliaSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}

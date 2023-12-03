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

namespace uchebka322mat.Components
{
    /// <summary>
    /// Логика взаимодействия для StudentUserControl.xaml
    /// </summary>
    public partial class StudentUserControl : UserControl
    {
        private List_Student list_student;
        public StudentUserControl(List_Student list_student)
        {
            InitializeComponent();
            this.list_student = list_student;
            DataContext = list_student;
        }
        private void OcenkaTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                list_student.ocenka = int.Parse((sender as TextBox).Text);
            }
            else
                list_student.ocenka = null;
            App.db.SaveChanges();
        }

        private void OcenkaTbPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) || int.Parse(e.Text) < 1 || int.Parse(e.Text) > 5)
            {
                e.Handled = true;
            }
        }
    }
}

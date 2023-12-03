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
using uchebka322mat.Components;

namespace uchebka322mat.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamListPage.xaml
    /// </summary>
    public partial class ExamListPage : Page
    {
        public ExamListPage()
        {
            InitializeComponent();
            foreach (Exemp exam in App.db.Exemp.ToArray())
            {
                ExamsWp.Children.Add(new ExamenUserControl(exam));
            }
        }
    }
}

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
    /// Логика взаимодействия для KafedraUserControl.xaml
    /// </summary>
    public partial class KafedraUserControl : UserControl
    {
        private Cafedra kafedra;
        public KafedraUserControl(Cafedra kafedra)
        {
            InitializeComponent();
            this.kafedra = kafedra;
            DataContext = kafedra;
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddEditKafedraPage(kafedra));
        }
    }
}

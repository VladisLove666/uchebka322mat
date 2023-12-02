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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public int[] TabNomers;
        public LoginPage()
        {
            InitializeComponent();
            TabNomers = App.db.Sotrudnik.Select(x => x.TabNomer).ToArray();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            int tabNomer = int.Parse(TabNomerTb.Text);
            if (TabNomers.Contains(tabNomer))
            {
                App.User = App.db.Sotrudnik.First(x => x.TabNomer == tabNomer);
                MessageBox.Show($"Вы вошли как {App.User.Familia}, ваша роль {App.User.Dolgnost}");
                EnterAs(App.User.Dolgnost);
            }
            else
                MessageBox.Show($"Сотрудника с таб. номером {TabNomerTb.Text} не существует");
        }
        private void GustBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CreateQRBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

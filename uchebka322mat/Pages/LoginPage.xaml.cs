using System;
using System.Collections.Generic;
using System.IO;
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
            TabNomers = App.db.Sotrudnik.Select(x => x.Tab_number).ToArray();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            int tabNomer = int.Parse(TabNomerTb.Text);
            if (TabNomers.Contains(tabNomer))
            {
                App.User = App.db.Sotrudnik.First(x => x.Tab_number == tabNomer);
                MessageBox.Show($"Вы вошли как {App.User.Surname}, ваша роль {App.User.Dolshnost}");
                EnterAs(App.User.Dolshnost);
            }
            else
                MessageBox.Show($"Сотрудника с таб. номером {TabNomerTb.Text} не существует");
        }
        private void EnterAs(string role)
        {
            switch (role)
            {
                case "зав. кафедрой":
                    App.MainFrame.Navigate(new KafedraListPage());
                    break;
                case "преподаватель":
                    App.MainFrame.Navigate(new ExamListPage());
                    break;
                case "инженер":
                    App.MainFrame.Navigate(new SotrudnilListPage());
                    break;
                case "гость":
                    App.MainFrame.Navigate(new DisciplinaListPage());
                    break;
                case "":
                    break;
            }
        }
        private void GustBtn_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Вы вошли как гость!");
                App.MainFrame.Navigate(new DisciplinaListPage());
        }

        private void CreateQRBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

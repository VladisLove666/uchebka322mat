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
    /// Логика взаимодействия для AddEditSotrudnikPage.xaml
    /// </summary>
    public partial class AddEditSotrudnikPage : Page
    {
        private Sotrudnik sotrudnik;
        private ZavCafedra zavCafedra;
        private bool isNew;
        public AddEditSotrudnikPage(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            this.sotrudnik = sotrudnik;
            DataContext = this.sotrudnik;
            isNew = !App.db.Sotrudnik.Any(x => x.Tab_number == sotrudnik.Tab_number);
            ShefCb.ItemsSource = App.db.ZavCafedra.ToArray();
            KafedraCb.ItemsSource = App.db.Cafedra.ToArray();
            DolgnostCb.ItemsSource = App.db.Sotrudnik.ToArray().Select(x => x.Dolshnost).Distinct();
            if (!isNew)
            {
                TabNomerTb.IsReadOnly = true;
                KafedraCb.SelectedItem = sotrudnik.Cafedra;
                DolgnostCb.SelectedItem = sotrudnik.Dolshnost;
                ShefCb.SelectedItem = App.db.ZavCafedra.First(x => x.Tab_number == sotrudnik.shef);
            }

        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBlank())
            {
                sotrudnik.shifr = KafedraCb.Text;
                sotrudnik.Surname = FamiliaTb.Text;
                sotrudnik.Dolshnost = DolgnostCb.Text;
                sotrudnik.Zarplata = int.Parse(ZarplataTb.Text);
                sotrudnik.shef = zavCafedra == null ? int.Parse(ShefCb.Text) : sotrudnik.Tab_number;

                if (isNew)
                {
                    if (!App.db.Sotrudnik.Any(x => x.Tab_number == sotrudnik.Tab_number))
                        App.db.Sotrudnik.Add(sotrudnik);
                    else
                    {
                        MessageBox.Show("Сотрудник с таким таб. номером уже существует!");
                        return;
                    }

                }
                if (zavCafedra != null && !App.db.Zav_Kafedra.Any(x => x.Tab_number == zavCafedra.Tab_number))
                {
                    zavCafedra.TabNomer = sotrudnik.TabNomer;
                    App.db.Zav_Kafedra.Add(zavCafedra);
                }

                App.db.SaveChanges();
                App.MainFrame.Navigate(new SotrudnilListPage());
            }
        }
        private bool CheckBlank()
        {
            StringBuilder errors = new StringBuilder();
            if (KafedraCb.SelectedItem == null)
                errors.AppendLine("Выберите кафедру");
            if (FamiliaTb.Text == "")
                errors.AppendLine("Введите фамилию");
            if (DolgnostCb.SelectedItem == null)
                errors.AppendLine("Выберите должность");
            if (ZarplataTb.Text == "")
                errors.AppendLine("Введите зарплату");
            else if (int.Parse(ZarplataTb.Text) == 0)
                errors.AppendLine("Зарплата должна быть больше 0!!!");
            if (ShefCb.SelectedItem == null && zavCafedra == null)
                errors.AppendLine("Выберите шефа");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            else
                return true;
        }

        private void FamiliaTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!char.IsLetter(e.Text[0]) && !char.IsWhiteSpace(e.Text[0]) && e.Text[0] != '.')
                e.Handled = true;
        }

        private void ZarplataTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void DolgnostCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == "зав. кафедрой")
            {
                zavCafedra = new Zav_Kafedra();
                zavCafedra.Tab_number = sotrudnik.Tab_number;
                sotrudnik.shef = sotrudnik.Tab_number;
                ShefCb.IsEnabled = false;
            }
            else
            {
                ShefCb.IsEnabled = true;
                if (App.db.Zav_Kafedra.Any(x => x.Tab_number == sotrudnik.Tab_number))
                {
                    zavCafedra = null;
                    ShefCb.ItemsSource = App.db.Zav_Kafedra.ToArray();
                    ShefCb.SelectedItem = null;
                    sotrudnik.shef = null;
                }
            }
        }
    }
}

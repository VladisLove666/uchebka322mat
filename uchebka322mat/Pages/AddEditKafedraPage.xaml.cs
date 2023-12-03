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
    /// Логика взаимодействия для AddEditKafedraPage.xaml
    /// </summary>
    public partial class AddEditKafedraPage : Page
    {
        private Cafedra kafedra;
        private bool isNew;
        public AddEditKafedraPage(Cafedra kafedra)
        {
            InitializeComponent();
            this.kafedra = kafedra;
            DataContext = kafedra;
            isNew = (kafedra.Shifr == null);
            FakultetCb.ItemsSource = App.db.Fakultet.ToArray();
            if (!isNew)
            {
                ShifrTb.IsReadOnly = true;
                FakultetCb.SelectedItem = kafedra.Fakultet;
            }
        }
        private bool CheckBlank()
        {
            StringBuilder errors = new StringBuilder();
            if (ShifrTb.Text == "")
                errors.AppendLine("Введите шифр");
            if (NazvanieTb.Text == "")
                errors.AppendLine("Введите название");
            if (FakultetCb.SelectedItem == null)
                errors.AppendLine("Выберите факультет");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            else
                return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBlank())
            {
                kafedra.shifr = ShifrTb.Text;
                kafedra.Name = NazvanieTb.Text;
                kafedra.Facultet = FakultetCb.Text;

                if (isNew)
                {
                    if (!App.db.Cafedra.Any(x => x.shifr == kafedra.shifr))
                        App.db.Cafedra.Add(kafedra);
                    else
                    {
                        MessageBox.Show("Кафедра с таким шифром уже существует!");
                        return;
                    }
                }

                App.db.SaveChanges();
                App.MainFrame.Navigate(new KafedraListPage());
            }
        }

        private void ShifrPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text[0]))
                e.Handled = true;
        }
    }
}

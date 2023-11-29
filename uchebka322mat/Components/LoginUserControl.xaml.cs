using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        private readonly string connectionString = "101";
        public LoginUserControl()
        {
            InitializeComponent();
        }
        private void EntryBC(object sender, RoutedEventArgs e)
        {
         string cipher = PasswordPB.Text;
        if (!string.IsNullOrEmpty(cipher))
            {
                bool IsValidCipher = checkCipherDataBase(cipher);
                if (IsValidCipher)
                {
                    MessageBox.Show("Вы вошли!");
                }
                else
                {
                    MessageBox.Show("Неверный Таб.Номер", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
            else
            {
                    MessageBox.Show("Пожалуйста, введите Таб.Номер", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool checkCipherDataBase(string cipher)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select count(*) from Sotrudnik where Tab_number = @Chiher";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Chiher", "Tab_number");
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }

        }
    }
}

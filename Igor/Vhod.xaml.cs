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
using System.Windows.Shapes;

namespace Igor
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            //Получение данных от пользователя
            string loginUser = loginText.Text;
            string pass = passText.Password;

            //Проверка наличия пользователя в базе
            
            Persona persona = null; 

            using (Entities1 user = new Entities1())
            {
                persona = user.Persona.Where(b => b.LoginReg == loginUser && b.ParolReg == pass).FirstOrDefault();
            }

            if (persona != null)
            {
                MessageBox.Show("Вход выполнен успешно!");

                //Переход в кабинет администратора
                if (persona.CodRol == 1)
                {
                    Admin admin = new Admin( loginUser);
                    admin.Show();
                    Close();
                }
                //Переход в кабинет пользователя
                else if (persona.CodRol == 2)
                {
                    Cabinet user = new Cabinet( loginUser);
                    user.Show();
                    Close();
                }
                //Переход в кабинет разработчика
                else
                {
                    Razrab razrab = new Razrab( loginUser);
                    razrab.Show();
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            //Переход на окно регистрации
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}

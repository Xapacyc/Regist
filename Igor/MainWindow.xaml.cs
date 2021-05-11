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
using System.Data.Entity;

namespace Igor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Сохранение данных в таблицах
        public static void RegistrPerson(string LoginUser, string Pass, string Fio, string Phone, string Email, string Gender, int Rol)
        {
            //Таблица Persona
            Entities1 entities = new Entities1();//Строяка подключения к бд
            Persona user = new Persona
            {
                Imia = Fio,
                Telefon = Phone,
                Pochta = Email,
                Pol = Gender,
                CodRol = Rol,
                LoginReg=LoginUser,
                ParolReg=Pass
            };
            entities.Persona.Add(user);//занесение в бд
            entities.SaveChanges();//сохранение в бд

            //Таблица Polzovatel
            Polzovatel authorization = new Polzovatel()
            {
                Login = LoginUser,
                Parol = Pass
            };
            entities.Polzovatel.Add(authorization);
            entities.SaveChanges();
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            //Получение данных от пользователя
            string loginUser = loginText.Text;
            string pass = passText.Password;
            string fio = nameText.Text;
            string phone = phoneText.Text;
            string email = emailText.Text;
            string gender = genderText.Text;
            int rol =2;

            //Вызов функции с сохранением данных
            RegistrPerson(loginUser, pass, fio, phone, email, gender, rol);

            MessageBox.Show("Регистрация прошла успешно!");

            //Очистка полей
            loginText.Clear();
            passText.Clear();
            nameText.Clear();
            phoneText.Clear();
            emailText.Clear();
            genderText.Clear();

        }

        private void crossing_Click(object sender, RoutedEventArgs e)
        {
            //Переход на окно входа
            Vhod vhod = new Vhod();
            vhod.Show();
            Close();
        }
    }
}

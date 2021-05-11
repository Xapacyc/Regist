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
    /// Логика взаимодействия для Razrab.xaml
    /// </summary>
    public partial class Razrab : Window
    {
        public Razrab( string loginUser)
        {
            InitializeComponent();

            //Вывод данных из таблицы
            Entities1 registraciaEntities = new Entities1();

            var Sravnenie = registraciaEntities.Persona.FirstOrDefault(p => p.LoginReg == loginUser);
            if (Sravnenie != null)
            {
                loginText.Text = Sravnenie.LoginReg;
                fioText.Text = Sravnenie.Imia;
                pochtaText.Text = Sravnenie.Pochta;
                telefonText.Text = Sravnenie.Telefon;
                polText.Text = Sravnenie.Pol;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Переход на окно входа
            Vhod vhod = new Vhod();
            vhod.Show();
            Close();
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            //Копирование имеющихся данных
            fioTextRed.Text = fioText.Text;
            pochtaTextRed.Text = pochtaText.Text;
            telefonTextRed.Text = telefonText.Text;

            //Скрытие и открытие элементов
            blokOsnov.Visibility = Visibility.Collapsed;
            blokRed.Visibility = Visibility.Visible;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            //Сохранение новых данных
            Persona persona = null;

            Entities1 user = new Entities1();
            persona = user.Persona.Where(b => b.LoginReg == loginText.Text).FirstOrDefault();
            if (persona != null)
            {
                persona.Imia = fioTextRed.Text;
                persona.Pochta = pochtaTextRed.Text;
                persona.Telefon = telefonTextRed.Text;

                user.Persona.Add(persona);//занесение в бд
                user.SaveChanges();//сохранение в бд
            }

            //Вывод новых данных
            fioText.Text = persona.Imia;
            pochtaText.Text = persona.Pochta;
            telefonText.Text = persona.Telefon;

            //Скрытие и открытие элементов
            blokRed.Visibility = Visibility.Collapsed;
            blokOsnov.Visibility = Visibility.Visible;

        }
    }
}

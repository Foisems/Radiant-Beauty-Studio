using RadiantBeautyStudio.Model;
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

namespace RadiantBeautyStudio.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            using (BeautyStudioDBEntities db = new BeautyStudioDBEntities())                              // подключение бд
            {
                var user = db.User.FirstOrDefault(u => u.Password.Equals(passwordPB.Password)             // присвоение user объект User из бд,                                                                                                        /
                && u.Login.Equals(loginTB.Text)); var users = db.User.ToList();                           // если совпали введенный password и login с данными из бд

                bool isEnter = false;

                if(user != null)                                                                          
                {
                    isEnter = true;
                    AppointmentsWindow appointmentsWindow = new AppointmentsWindow();
                    appointmentsWindow.Show();
                    this.Hide();
                }

                if (!isEnter)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Сonstruction_сompany
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region Initialize
        public Login()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void LoginB_Click(object sender, RoutedEventArgs e)
        {
            LogBar.Visibility = Visibility.Hidden;
            if (LoginText.Text == "" || LoginText.Text == "Login")
            {
                BLogin.Background = Brushes.Red;
                LogBar.Content = "Введіть логін!";
                LogBar.Visibility = Visibility.Visible;
            }
            else if (PasswordText.Password == "" || PasswordText.Password == "Password")
            {
                BPassword.Background = Brushes.Red;
                LogBar.Content = "Введіть пароль!";
                LogBar.Visibility = Visibility.Visible;
            }
            else
            {

                /*switch (user.UserLogin(LoginText.Text, PasswordText.Password))
                {
                    case 0:
                        {
                            LogBar.Content = "Невірний логін, або пароль!";
                            LogBar.Visibility = Visibility.Visible;
                            break;
                        }
                    case 1:
                        {
                            //відкрити потрібне вікно!
                            //new MainManufactore(user).Show(); //!!!!!!!!!!!!!!!!
                            this.Close();
                            break;
                        }
                    case -1:
                        {
                            LogBar.Content = "Відсутнє з'єднання з сервером!";
                            LogBar.Visibility = Visibility.Visible;
                            break;
                        }
                } */
            }
               
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BRegistry_Click(object sender, RoutedEventArgs e)
        {
            //new Registration().Show();
            this.Close();
        }

        private void LoginText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (LoginText.Text == "Login") LoginText.Text = "";
            if (BLogin.Background == Brushes.Red) BLogin.Background = Brushes.White;
        }

        private void PasswordText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (PasswordText.Password == "Password") PasswordText.Password = "";
            if (BPassword.Background == Brushes.Red) BPassword.Background = Brushes.White;
        }

        private void LoginText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (LoginText.Text.Length < 6)
            {
                LogBar.Visibility = Visibility.Visible;
                LogBar.Content = "minimum number of characters - 6!";
                BLogin.Background = Brushes.Red;
            }
            else if (LoginText.Text.Length > 18)
            {
                LogBar.Visibility = Visibility.Visible;
                LogBar.Content = "maximum number of characters - 18!";
                BLogin.Background = Brushes.Red;
            }
            else
            {
                LogBar.Visibility = Visibility.Visible;
                BLogin.Background = Brushes.Green;
            }
                
        }

        private void PasswordText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PasswordText.Password.Length < 6)
            {
                LogBar.Visibility = Visibility.Visible;
                LogBar.Content = "minimum number of characters - 6!";
                BPassword.Background = Brushes.Red;
            }
            else if (PasswordText.Password.Length > 18)
            {
                LogBar.Visibility = Visibility.Visible;
                LogBar.Content = "maximum number of characters - 18!";
                BPassword.Background = Brushes.Red;
            }
            else
            {
                LogBar.Visibility = Visibility.Visible;
                BPassword.Background = Brushes.Green;
            }
        }
        #endregion
    }
}

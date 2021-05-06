using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Сonstruction_сompany.RequestToServer;
using Сonstruction_сompany.Users_classes;
using static Сonstruction_сompany.Auxiliary_classes.CheckLength;
namespace Сonstruction_сompany
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        #region Data fields
        private UserType userType;
        #endregion
        #region Initialize
        public Registration()
        {
            InitializeComponent();
            userType = UserType.Unregistered;
        }
        #endregion
        #region Events
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginB_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show(); //Login Form
            this.Close();
        }

        private void BRegistry_Click(object sender, RoutedEventArgs e)
        {
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
            else if (NameText.Text == "" || NameText.Text == "Name")
            {
                BName.Background = Brushes.Red;
                LogBar.Content = "Введіть ім'я!";
                LogBar.Visibility = Visibility.Visible;
            }
            else if (SurnameText.Text == "" || SurnameText.Text == "Surname")
            {
                BSurname.Background = Brushes.Red;
                LogBar.Content = "Введіть прізвище!";
                LogBar.Visibility = Visibility.Visible;
            }
            else if (EmailText.Text == "" || EmailText.Text == "Email")
            {
                BEmail.Background = Brushes.Red;
                LogBar.Content = "Введіть електронну пошту!";
                LogBar.Visibility = Visibility.Visible;
            }
            else if (PhoneText.Text == "" || PhoneText.Text == "Phone")
            {
                BPhone.Background = Brushes.Red;
                LogBar.Content = "Введіть номер телефону!";
                LogBar.Visibility = Visibility.Visible;
            }
            else if (userType == UserType.Unregistered)
            {
                TypeText.Foreground = Brushes.Red;
                LogBar.Content = "Оберіть тип користувача!";
                LogBar.Visibility = Visibility.Visible;
            }
            else
            {
                TypeText.Foreground = Brushes.White;
                LogBar.Visibility = Visibility.Hidden;

                string data = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}", "registration", userType, NameText.Text, SurnameText.Text, EmailText.Text, PhoneText.Text, LoginText.Text, PasswordText.Password);
                switch (Request.SendData(data))
                {
                    case 0:
                        {
                            LogBar.Content = "Невірний формат даних!";
                            LogBar.Visibility = Visibility.Visible;
                            break;
                        }
                    case 1:
                        {
                            //відкрити потрібне вікно!
                            this.Close();
                            break;
                        }
                    case -1:
                        {
                            LogBar.Content = "Відсутнє з'єднання з сервером!";
                            LogBar.Visibility = Visibility.Visible;
                            break;
                        }
                }

            }
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            Customer.Opacity = 1;
            Worker.Opacity = 0.5;
            userType = UserType.Customer;
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            Customer.Opacity = 0.5;
            Worker.Opacity = 1;
            userType = UserType.Worker;
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

        private void NameText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (NameText.Text == "Name") NameText.Text = "";
            if (BName.Background == Brushes.Red) BName.Background = Brushes.White;
        }

        private void SurnameText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (SurnameText.Text == "Surname") SurnameText.Text = "";
            if (BSurname.Background == Brushes.Red) BSurname.Background = Brushes.White;
        }

        private void EmailText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (EmailText.Text == "Email") EmailText.Text = "";
            if (BEmail.Background == Brushes.Red) BEmail.Background = Brushes.White;
        }

        private void PhoneText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (PhoneText.Text == "Phone") PhoneText.Text = "";
            if (BPhone.Background == Brushes.Red) BPhone.Background = Brushes.White;
        }
        #region LostKeyboard
        //Check the number of characters entered in the login field
        private void LoginText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Check(ref LoginText, ref BLogin, ref LogBar);
        }
        //Check the number of characters entered in the password field
        private void PasswordText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Check(ref PasswordText, ref BPassword, ref LogBar);
        }
        //Check the number of characters entered in the name field
        private void NameText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Check(ref NameText, ref BName, ref LogBar);
        }
        //Check the number of characters entered in the surname field
        private void SurnameText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Check(ref SurnameText, ref BSurname, ref LogBar);
        }
        //Check the number of characters entered in the email field
        private void EmailText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Check(ref EmailText, ref BEmail, ref LogBar);
        }
        //Check the number of characters entered in the phone field
        private void PhoneText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Check(ref PhoneText, ref BPhone, ref LogBar);
        }
        #endregion
        #endregion
    }
}


using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Сonstruction_сompany.RequestToServer;
using Сonstruction_сompany.Users;
using static Сonstruction_сompany.Auxiliary_classes.CheckLength;
namespace Сonstruction_сompany
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region Data fields
        private UserType userType;
        #endregion

        #region Constructors
        public Login(UserType userType)
        {
            InitializeComponent();
            this.userType = userType;
            if(this.userType == UserType.Customer)
            {
                Customer.Opacity = 1;
                Worker.Opacity = 0.5;
            }
            else
            {
                Customer.Opacity = 0.5;
                Worker.Opacity = 1;
            }
            //
            
        }
        public Login()
        {
            InitializeComponent();
            this.userType = UserType.Unregistered;
        }
        #endregion

        #region Events
        //
        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            Customer.Opacity = 1;
            Worker.Opacity = 0.5;
            userType = UserType.Customer;
            TypeText.Foreground = Brushes.Orange;
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            Customer.Opacity = 0.5;
            Worker.Opacity = 1;
            userType = UserType.Worker;
            TypeText.Foreground = Brushes.Orange;
        }
        //allows you to move the lid on the desktop
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        //Logic of checking the entered data for login
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
            else if (userType == UserType.Unregistered)
            {
                TypeText.Foreground = Brushes.Red;
                LogBar.Content = "Оберіть тип користувача!";
                LogBar.Visibility = Visibility.Visible;
            }
            else
            {
                string data = String.Format("{0}:{1}:{2}:{3}", "login", userType, LoginText.Text, PasswordText.Password);
                switch (Request.Get_Instance().RequestWithoutReceivingData(data))
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
                            new MainMenu(userType).Show();
                            LogBar.Content = "Успішно!";
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
        //Closing the window
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Launch the registration window
        private void BRegistry_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            this.Close();
        }
        //Erases the default value in the login field
        private void LoginText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (LoginText.Text == "Login") LoginText.Text = "";
            if (BLogin.Background == Brushes.Red) BLogin.Background = Brushes.White;
        }
        //Erases the default value in the password field
        private void PasswordText_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (PasswordText.Password == "Password") PasswordText.Password = "";
            if (BPassword.Background == Brushes.Red) BPassword.Background = Brushes.White;
        }
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
        #endregion
    }
}

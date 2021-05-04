using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static Сonstruction_сompany.Auxiliary_classes.CheckLength;
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
        //
        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            Customer.Opacity = 1;
            Worker.Opacity = 0.5;
            //user.Set_UserType(UserType.Reseller);
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            Customer.Opacity = 0.5;
            Worker.Opacity = 1;
            //user.Set_UserType(UserType.Manufacture);
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

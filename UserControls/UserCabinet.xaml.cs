using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Сonstruction_сompany.RequestToServer;
using Сonstruction_сompany.Users;

namespace Сonstruction_сompany.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : UserControl
    {
        private User user;
        private int[] age;
        public UserCabinet()
        {
            InitializeComponent();
            age = new int[] { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 
                33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 
                51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
            CAge.ItemsSource = age;

            string data = String.Format("{0}", "getUserData");
            user = new User(Request.Get_Instance().GetUserInfo(data));
            if(user != null)
            InitUserData();
        }
        private void InitUserData()
        {
            if (user != null)
            {
                TName.Text = user.GetName();
                TSurname.Text = user.GetSurname();
                TEmail.Text = user.GetEmail();
                TPhone.Text = user.GetPhone();
              //  CAge.SelectedItem = age[user.GetAge() - 18];
                TRegion.Text = user.GetRegion();
                TSity.Text = user.GetSity();
                if(user.GetUserImage() == null)
                {

                }
                else
                {
                    var imageSource = new BitmapImage();
                    MemoryStream ms = new System.IO.MemoryStream(user.GetUserImage());
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();

                    ImageBrush img = new ImageBrush();
                    img.ImageSource = imageSource;
                    BImg.Background = img;
                }
            }
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            SetVisibleTips();
            SetEditFields();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            SetHiddenTips();
            SetUneditFields();
        }

        private void BImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BImage_MouseEnter(object sender, MouseEventArgs e)
        {
            BImage.Opacity = 0.8;
        }

        private void BImage_MouseLeave(object sender, MouseEventArgs e)
        {
            BImage.Opacity = 0;
        }

        private void SetVisibleTips()
        {
            SName.Visibility = Visibility.Visible;
            SSurname.Visibility = Visibility.Visible;
            SEmail.Visibility = Visibility.Visible;
            SPhone.Visibility = Visibility.Visible;
            SRegion.Visibility = Visibility.Visible;
            SSity.Visibility = Visibility.Visible;
        }
        private void SetHiddenTips()
        {
            SName.Visibility = Visibility.Hidden;
            SSurname.Visibility = Visibility.Hidden;
            SEmail.Visibility = Visibility.Hidden;
            SPhone.Visibility = Visibility.Hidden;
            SRegion.Visibility = Visibility.Hidden;
            SSity.Visibility = Visibility.Hidden;
        }
        private void SetEditFields()
        {
            TName.Focusable = true;
            SSurname.Focusable = true;
            SEmail.Focusable = true;
            SPhone.Focusable = true;
            SRegion.Focusable = true;
            SSity.Focusable = true;
        }
        private void SetUneditFields()
        {
            TName.Focusable = false;
            SSurname.Focusable = false;
            SEmail.Focusable = false;
            SPhone.Focusable = false;
            SRegion.Focusable = false;
            SSity.Focusable = false;
        }
    }
}

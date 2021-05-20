using Microsoft.Win32;
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
        private string imageName, strName;
        public UserCabinet(ref User user)
        {
            InitializeComponent();
            age = new int[] { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32,
                33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
            CAge.ItemsSource = age;
            this.user = user;
            if (user != null)
                InitUserData();
        }
        private void InitUserData()
        {
            if (user != null)
            {
                TName.Text = user.Name;
                TSurname.Text = user.Surname;
                TEmail.Text = user.Email;
                TPhone.Text = user.Phone;
                TRegion.Text = user.Region;
                TSity.Text = user.Sity;

                var imageSource = new BitmapImage();
                MemoryStream ms;
                if (user.UserImage.Length < 20)
                {
                    FileStream fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\User.png", FileMode.Open, FileAccess.Read);
                    byte[] bStream = new byte[fs.Length];
                    fs.Read(bStream, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    ms = new System.IO.MemoryStream(bStream);
                }
                else
                    ms = new System.IO.MemoryStream(user.UserImage);

                imageSource.BeginInit();
                imageSource.StreamSource = ms;
                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                imageSource.EndInit();

                ImageBrush img = new ImageBrush();
                img.ImageSource = imageSource;
                BImg.Background = img;
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
            SendDataAsync();
        }
       
        private async System.Threading.Tasks.Task SendDataAsync()
        {
            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
            byte[] imgByteArr = new byte[fs.Length];
            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            user.Name = TName.Text; user.Surname = TSurname.Text; user.Email = TEmail.Text;
            user.Phone = TPhone.Text; user.Region = TRegion.Text; user.Sity = TSity.Text; user.UserImage = imgByteArr;
            await HttpUserRequest.PostInsertUserAsync(user);
        }
        private void BImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    ImageBrush imgbr = new ImageBrush();
                    imgbr.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Absolute));
                    BImg.Background = imgbr;
                    
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
            TName.BorderThickness = new Thickness(1, 1, 1, 1);
            TSurname.Focusable = true;
            TSurname.BorderThickness = new Thickness(1, 1, 1, 1);
            TEmail.Focusable = true;
            TEmail.BorderThickness = new Thickness(1, 1, 1, 1);
            TPhone.Focusable = true;
            TPhone.BorderThickness = new Thickness(1, 1, 1, 1);
            TRegion.Focusable = true;
            TRegion.BorderThickness = new Thickness(1, 1, 1, 1);
            TSity.Focusable = true;
            TSity.BorderThickness = new Thickness(1, 1, 1, 1);
        }
        private void SetUneditFields()
        {
            TName.Focusable = false;
            TName.BorderThickness = new Thickness(0, 0, 0, 0);
            TSurname.Focusable = false;
            TSurname.BorderThickness = new Thickness(0, 0, 0, 0);
            TEmail.Focusable = false;
            TEmail.BorderThickness = new Thickness(0, 0, 0, 0);
            TPhone.Focusable = false;
            TPhone.BorderThickness = new Thickness(0, 0, 0, 0);
            TRegion.Focusable = false;
            TRegion.BorderThickness = new Thickness(0, 0, 0, 0);
            TSity.Focusable = false;
            TSity.BorderThickness = new Thickness(0, 0, 0, 0);
        }
    }
}

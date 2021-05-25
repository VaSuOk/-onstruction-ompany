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
using Сonstruction_сompany.Auxiliary_classes;
using Сonstruction_сompany.View;

namespace Сonstruction_сompany.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : UserControl
    {
        private string strName, imageName;
        private User user;
        private Regions LRegions;
        private UserAge userAge;

        public CreateOrder(ref User user)
        {
            InitializeComponent();

            this.user = user;
            LRegions = new Regions();
            userAge = new UserAge();

            CAge.ItemsSource = userAge.Age;
            LRegion.ItemsSource = LRegions.regions;

            InitData(user);
        }

        public void InitData(User user)
        {
            if (user != null)
            {
                TName.Text = user.Name;
                TSurname.Text = user.Surname;
                TEmail.Text = user.Email;
                TPhone.Text = user.Phone;
                LRegion.SelectedItem = user.Region;
                TSity.Text = user.Sity;
                CAge.SelectedItem = (int)user.Age;

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
        private void BImage_MouseLeave(object sender, MouseEventArgs e)
        {
            BImage.Opacity = 0;
        }

        private void COrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BImage_MouseEnter(object sender, MouseEventArgs e)
        {
            BImage.Opacity = 0.8;
        }
        
    }
}

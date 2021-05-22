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
    /// Логика взаимодействия для CreateQuestionnaire.xaml
    /// </summary>
    public partial class CreateQuestionnaire : UserControl
    {
        private string strName, imageName, position;
        private int stage;
        private Regions WRegions;
        private Regions LRegions;
        public CreateQuestionnaire(User user = null)
        {
            WRegions = new Regions();
            LRegions = new Regions();

            InitializeComponent();

            WRegions.AddRegionTypeAll();
            WRegion.ItemsSource = WRegions.regions;
            LRegion.ItemsSource = LRegions.regions;
        }
        public void InitData(User user)
        {
            if (user != null)
            {
                TName.Text = user.Name;
                TSurname.Text = user.Surname;
                TEmail.Text = user.Email;
                TPhone.Text = user.Phone;
                //TRegion.Text = user.Region;
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

        private void BVnytr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BVnytr);
            SetUnClik(BDax, BFundament, BStina);
            BMain.Content = "ШТУКАТУР";
            Bsupp.Content = "МАЛЯР";
            BSupp2.Visibility = Visibility.Visible;
            BSupp2.Content = "СТОЛЯР";
            BSupp3.Visibility = Visibility.Visible;
            BSupp3.Content = "ПОМІЧНИК";
        }
        private void SetClik(Border border)
        {
            border.BorderBrush = Brushes.Green;
            border.BorderThickness = new Thickness(1, 1, 1, 1);
            border.Background = Brushes.LightGreen;
        }
        private void SetUnClik(Border border1, Border border2, Border border3)
        {
            SetUnClik(border1);
            SetUnClik(border2);
            SetUnClik(border3);
        }
        private void SetUnClik(Border border)
        {
            border.BorderBrush = Brushes.OrangeRed;
            border.BorderThickness = new Thickness(2,2,2,2);
            border.Background = Brushes.Transparent;
        }

        private void BStina_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BStina);
            SetUnClik(BDax, BFundament, BVnytr);
            BMain.Content = "МУЛЯР";
            Bsupp.Content = "ПІДСОБНИК";
            BSupp3.Visibility = Visibility.Collapsed;
            BSupp2.Visibility = Visibility.Collapsed;
        }

        private void BDax_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BDax);
            SetUnClik(BVnytr, BFundament, BStina);
            BMain.Content = "ПЛОТНИК";
            Bsupp.Content = "ПОКРІВЕЛЬНИК";
            BSupp2.Visibility = Visibility.Visible;
            BSupp2.Content = "ПОМІЧНИК";
            BSupp3.Visibility = Visibility.Collapsed;
        }

        private void BFundament_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BFundament);
            SetUnClik(BDax, BVnytr, BStina);
            BMain.Content = "МОНОЛІДЧИК";
            Bsupp.Content = "ПОМІЧНИК";
            BSupp3.Visibility = Visibility.Collapsed;
            BSupp2.Visibility = Visibility.Collapsed;
        }
        private void SetOpasityButton(Button button, Button button1, Button button2)
        {
            button.Opacity = 0.7;
            button1.Opacity = 0.7;
            button2.Opacity = 0.7;
        }
        private void BMain_Click(object sender, RoutedEventArgs e)
        {
            BMain.Opacity = 1;
            SetOpasityButton(Bsupp, BSupp2, BSupp3);
            position = BMain.Content.ToString();
        }

        private void Bsupp_Click(object sender, RoutedEventArgs e)
        {
            Bsupp.Opacity = 1;
            SetOpasityButton(BMain, BSupp2, BSupp3);
            position = Bsupp.Content.ToString();
        }

        private void BSupp2_Click(object sender, RoutedEventArgs e)
        {
            BSupp2.Opacity = 1;
            SetOpasityButton(BMain, Bsupp, BSupp3);
            position = BSupp2.Content.ToString();
        }

        private void BSupp3_Click(object sender, RoutedEventArgs e)
        {
            BSupp3.Opacity = 1;
            SetOpasityButton(BMain, Bsupp, BSupp2);
            position = BSupp3.Content.ToString();
        }

        private void BImage_MouseLeave(object sender, MouseEventArgs e)
        {
            BImage.Opacity = 0;
        }
    }
}

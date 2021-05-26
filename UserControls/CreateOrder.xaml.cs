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
        #region Data fields
        private string strName, imageName;
        private UserOrder userOrder;
        private Regions LRegions;
        private UserAge userAge;
        #endregion

        #region Constructors
        public CreateOrder(ref User user)
        {
            userOrder = new UserOrder();
            InitializeComponent();

            this.userOrder.user = user;
            LRegions = new Regions();
            userAge = new UserAge();

            CAge.ItemsSource = userAge.Age;
            LRegion.ItemsSource = LRegions.regions;

            InitData(user);
        }
        #endregion

        #region Methods
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

        private void SetClik(Border border)
        {
            border.BorderBrush = Brushes.Green;
            border.BorderThickness = new Thickness(1, 1, 1, 1);
            border.Background = Brushes.LightGreen;
        }
        private void SetUnClik(Border border1 = null, Border border2 = null, Border border3 = null, Border border4 = null, Border border5 = null)
        {
            if(border1 != null)
                SetUnClik(border1);
            if (border2 != null)
                SetUnClik(border2);
            if (border3 != null)
                SetUnClik(border3);
            if (border4 != null)
                SetUnClik(border4);
            if (border5 != null)
                SetUnClik(border5);
        }
        private void SetUnClik(Border border)
        {
            border.BorderBrush = Brushes.Orange;
            border.BorderThickness = new Thickness(2, 2, 2, 2);
            border.Background = Brushes.Transparent;
        }
        #endregion

        #region Events

        #region Event Click

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(UContent.Visibility == Visibility.Visible)
            {
                UContent.Visibility = Visibility.Collapsed;
                BHiVi.Content = "▼";
                BMain.Height = 1790;
            }
            else
            {
                UContent.Visibility = Visibility.Visible;
                BHiVi.Content = "▲";
                BMain.Height = 2120;
            }
            
        }
        private void BImage_MouseEnter(object sender, MouseEventArgs e)
        {
            BImage.Opacity = 0.8;
        }
        #endregion

        #region Event Home_Type
        private void BprivateHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BprivateHome);
            SetUnClik(BOffice, BApartment, BResting, BIndustrial);
            userOrder.type_Building = Type_Building.Приватний;
        }

        private void BApartment_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BApartment);
            SetUnClik(BOffice, BprivateHome, BResting, BIndustrial);
            userOrder.type_Building = Type_Building.Квартирний;
        }

        private void BIndustrial_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BIndustrial);
            SetUnClik(BOffice, BApartment, BResting, BprivateHome);
            userOrder.type_Building = Type_Building.Виробничий;
        }

        private void BOffice_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BOffice);
            SetUnClik(BprivateHome, BApartment, BResting, BIndustrial);
            userOrder.type_Building = Type_Building.Офісний;
        }

        private void BResting_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BResting);
            SetUnClik(BOffice, BApartment, BprivateHome, BIndustrial);
            userOrder.type_Building = Type_Building.Оздоровчий;
        }
        #endregion

        #region Event Type_Foundation
        private void BF1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BF1);
            SetUnClik(BF2, BF3, BF4);
            userOrder.type_Foundation = Type_Foundation.Стовпчастий;
        }

        private void BF2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BF2);
            SetUnClik(BF1, BF3, BF4);
            userOrder.type_Foundation = Type_Foundation.Стрічковий;
        }

        private void BF3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BF3);
            SetUnClik(BF2, BF1, BF4);
            userOrder.type_Foundation = Type_Foundation.Пальовий;
        }

        private void BF4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BF4);
            SetUnClik(BF2, BF3, BF1);
            userOrder.type_Foundation = Type_Foundation.Плитний;
        }
        #endregion

        #region Event Wall_Material
        private void BS1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BS1);
            SetUnClik(BS2, BS3, BS4, BS5, BS6);
            userOrder.wall_Material = Wall_Material.Селікатна_цегла;
        }

        private void BS2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BS2);
            SetUnClik(BS1, BS3, BS4, BS5, BS6);
            userOrder.wall_Material = Wall_Material.Керамічна_цегла;
        }

        private void BS3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BS3);
            SetUnClik(BS2, BS1, BS4, BS5, BS6);
            userOrder.wall_Material = Wall_Material.Керамічний_блок;
        }

        private void BS4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BS4);
            SetUnClik(BS2, BS3, BS1, BS5, BS6);
            userOrder.wall_Material = Wall_Material.Газоблок;
        }

        private void BS5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BS5);
            SetUnClik(BS2, BS3, BS4, BS1, BS6);
            userOrder.wall_Material = Wall_Material.Ракушняк;
        }

        private void BS6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BS6);
            SetUnClik(BS2, BS3, BS4, BS5, BS1);
            userOrder.wall_Material = Wall_Material.Шлакоблок;
        }
        #endregion

        #region Event Type_Roof
        private void BD1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BD1);
            SetUnClik(BD2, BD3, BD4, BD5);
            userOrder.type_Roof = Type_Roof.Плаский;
        }

        private void BD2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BD2);
            SetUnClik(BD1, BD3, BD4, BD5);
            userOrder.type_Roof = Type_Roof.Скатний;
        }

        private void BD3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BD3);
            SetUnClik(BD2, BD1, BD4, BD5);
            userOrder.type_Roof = Type_Roof.Шатровий;
        }

        private void BD4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BD4);
            SetUnClik(BD2, BD3, BD1, BD5);
            userOrder.type_Roof = Type_Roof.Двоскатний;
        }

        private void BD5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BD5);
            SetUnClik(BD2, BD3, BD4, BD1);
            userOrder.type_Roof = Type_Roof.Багатоскатний;
        }



        #endregion

        #region Rofing_Material
        private void BR1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BR1);
            SetUnClik(BR2, BR3, BR4, BR5);
            userOrder.rofing_Material = Rofing_Material.Металочерепиця;
        }

        private void BR2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BR2);
            SetUnClik(BR1, BR3, BR4, BR5);
            userOrder.rofing_Material = Rofing_Material.Металочерепиця;
        }

        private void BR3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BR3);
            SetUnClik(BR2, BR1, BR4, BR5);
            userOrder.rofing_Material = Rofing_Material.Металочерепиця;
        }

        private void BR4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BR4);
            SetUnClik(BR2, BR3, BR1, BR5);
            userOrder.rofing_Material = Rofing_Material.Металочерепиця;
        }

        private void BR5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BR5);
            SetUnClik(BR2, BR3, BR4, BR1);
            userOrder.rofing_Material = Rofing_Material.Металочерепиця;
        }
        #endregion

        #endregion

    }
}

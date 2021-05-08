using System;
using System.Collections.Generic;
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
using Сonstruction_сompany.Auxiliary_classes;

namespace Сonstruction_сompany
{
    /// <summary>
    /// Логика взаимодействия для MainInfo.xaml
    /// </summary>
    public partial class MainInfo : Window
    {
        public int id;
        public ItemSlide [] slids;
        public MainInfo()
        {
            InitializeComponent();
            InitSlider();
            ChangeSlide();
        }
        public void InitSlider()
        {
            id = 2;
            slids = new ItemSlide[]
            {
                new ItemSlide(1, "D:/KPK/ДИПЛОМ/SOFT/Сonstruction сompany/Source/s4.jpg"),
                new ItemSlide(2, "D:/KPK/ДИПЛОМ/SOFT/Сonstruction сompany/Source/s3.jpg"),
                new ItemSlide(3, "D:/KPK/ДИПЛОМ/SOFT/Сonstruction сompany/Source/s2.jpg")
            };

            string imageName = slids[id-1].image;
            ImageSourceConverter isc = new ImageSourceConverter();
            ImageBrush imgbr = new ImageBrush();
            imgbr.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Absolute));
            slide.Background = imgbr;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void BLeft_Click(object sender, RoutedEventArgs e)
        {
            id--;
            if(id == 0)
            {
                id = slids.Length;
            }
            SetSlide();
        }

        private void BRight_Click(object sender, RoutedEventArgs e)
        {
            SlideRight();
            SetSlide();
        }
        private void SlideRight()
        {
            id++;
            if (id == slids.Length + 1)
            {
                id = 1;
            }
            
        }
        private void SetSlide()
        {
            string imageName = slids[id - 1].image;
            ImageSourceConverter isc = new ImageSourceConverter();
            ImageBrush imgbr = new ImageBrush();
            imgbr.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Absolute));
            slide.Background = imgbr;
        }
        private async void ChangeSlide()
        {
            while (true) {
                await Task.Delay(2000);
                SlideRight();
                SetSlide();
            }
        }
    }
}

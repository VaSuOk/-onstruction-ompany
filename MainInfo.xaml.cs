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
        #region Data fields
        Auxiliary_classes.Slider slider;
        #endregion
        #region Constructors
        public MainInfo()
        {
            InitializeComponent();
            slider = new Auxiliary_classes.Slider(ref slide); 

        }
        #endregion
        #region Events
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
            slider.Left_Click(ref slide);
        }

        private void BRight_Click(object sender, RoutedEventArgs e)
        {
            slider.Right_Click(ref slide);
        }
        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            new Login(Users.UserType.Customer).Show();
            this.Close();
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            new Login(Users.UserType.Worker).Show();
            this.Close();
        }
        #endregion
        
    }
}

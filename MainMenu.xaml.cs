using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Сonstruction_сompany.Auxiliary_classes;
using Сonstruction_сompany.UserControls;
using Сonstruction_сompany.Users;

namespace Сonstruction_сompany
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        #region Data fields
        public User user;
        private ListItemMenu listItemMenu;
        #endregion

        #region Constructors
        public MainMenu(UserType userType)
        {
            InitializeComponent();  
            InitComponentsAndResource(userType);

            UserControl usc = new UserCabinet();
            GridMain.Children.Clear();
            GridMain.Children.Add(usc);
        }
        private void InitComponentsAndResource(UserType userType)
        {   
            listItemMenu = new ListItemMenu();
            user = new User();

            if (userType == UserType.Customer) 
                listItemMenu.SetCustomerItemMenu();
            else
                listItemMenu.SetWorkerItemMenu();
            TUserType.Text = "." + userType;
            
            ListViewMenu.ItemsSource = listItemMenu._MenuItems;
        }
        #endregion

        #region Events
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            
            var selectedMenuItem = (Auxiliary_classes.MenuItem)((ListView)sender).SelectedItem;
            if(selectedMenuItem != null)
            {
                //selectedMenuItem.usc; 
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        #endregion

    }
}

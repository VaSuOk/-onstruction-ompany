using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Сonstruction_сompany.Auxiliary_classes;
using Сonstruction_сompany.RequestToServer;
using Сonstruction_сompany.UserControls;
using Сonstruction_сompany.View;

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
        public MainMenu(UserType userType, int ID)
        {
            InitializeComponent();
            user = HttpUserRequest.GetUserByID(ID);
            InitComponentsAndResource(userType);
        }
        private void InitComponentsAndResource(UserType userType)
        {   
            listItemMenu = new ListItemMenu();

            if (userType == UserType.Customer) 
                listItemMenu.SetCustomerItemMenu(ref user);
            else
                listItemMenu.SetWorkerItemMenu(ref user, GridMain);
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
            GridMain.Children.Clear();
            
            var selectedMenuItem = (Auxiliary_classes.MenuItem)((ListView)sender).SelectedItem;
            if(selectedMenuItem != null)
            {
                if (selectedMenuItem.usc != null)
                {
                    GridMain.Children.Add(selectedMenuItem.usc);
                    if(selectedMenuItem.xName == "Cabinet") { BLogout.Visibility = Visibility.Visible; }
                    else if(BLogout.Visibility == Visibility.Visible) { BLogout.Visibility = Visibility.Hidden; }

                    //Обнова даних "тимчасова"
                    if (selectedMenuItem.usc.GetType().Name == "UserCabinet")
                        selectedMenuItem.usc = new UserCabinet(ref user);
                    else if (selectedMenuItem.usc.GetType().Name == "QuestionnairesControl")
                        selectedMenuItem.usc = new QuestionnairesControl(ref GridMain, user);
                    else if (selectedMenuItem.usc.GetType().Name == "CreateQuestionnaire")
                        selectedMenuItem.usc = new CreateQuestionnaire(user);
                }      
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        private void BLogout_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }
        #endregion

        
    }
}

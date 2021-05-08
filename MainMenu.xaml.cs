﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Сonstruction_сompany.Auxiliary_classes;
using Сonstruction_сompany.Users_classes;

namespace Сonstruction_сompany
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public User manufacturer;
        public List<Auxiliary_classes.MenuItem> menuItems;
        public MainMenu()
        {
            InitializeComponent();
            DataContext = new ListItemMenu();
        }
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
            Auxiliary_classes.MenuItem menuItem = ((ListViewItem)((ListView)sender).SelectedItem).Tag as Auxiliary_classes.MenuItem;
            switch (menuItem.xName)
            {
                
                
                case "Home":
                    //usc = new ControlMyProducts(manufacturer.ID_Manufacturer, ref GridMain);
                    GridMain.Children.Add(usc);
                    //menuItem.data = "rfff";
                    break;/*
                case "Account":
                    usc = new UserProfileControl(ref manufacturer);
                    GridMain.Children.Add(usc);
                    break;
                case "CreateProduct":
                    usc = new AddProduct(manufacturer.ID_Manufacturer);
                    GridMain.Children.Add(usc);
                    break;
                case "History":
                    usc = new DateSellProduct(manufacturer.ID_Manufacturer);
                    GridMain.Children.Add(usc);
                    break;
                case "Log_out":
                    new ULogin().Show();
                    this.Close();
                    break;
                */
                default:
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}

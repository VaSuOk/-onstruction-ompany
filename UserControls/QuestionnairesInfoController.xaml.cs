using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для QuestionnairesInfoController.xaml
    /// </summary>
    public partial class QuestionnairesInfoController : UserControl
    {
        private string position;
        private Stage stage;
        private Regions WRegions;
        private Questionnaire questionnaire;

        public QuestionnairesInfoController(Questionnaire questionnaire)
        {
            InitializeComponent();

            this.questionnaire = questionnaire;
            InitDataQuestionnaire();

            WRegions = new Regions();
            WRegion.ItemsSource = WRegions.regions;
        }
        private void InitDataQuestionnaire()
        {
            WRegion.SelectedItem = questionnaire.RegionOfWork;
            TSalary.Text = questionnaire.Salary.ToString();
            switch (questionnaire.stage)
            {
                case Stage.Earthwork:
                    SetClik(BFundament);
                    BFundament_MouseDown(null, null);
                    if (questionnaire.Position == "МОНОЛІДЧИК")
                        BMain_Click(null, null);
                    else
                        Bsupp_Click(null, null);
                    break;

                case Stage.Construction:
                    SetClik(BStina);
                    BStina_MouseDown(null, null);
                    if (questionnaire.Position == "МУЛЯР")
                        BMain_Click(null, null);
                    else
                        Bsupp_Click(null, null);
                    break;

                case Stage.Roofing:
                    SetClik(BDax);
                    BDax_MouseDown(null, null);
                    if (questionnaire.Position == "ПЛОТНИК")
                        BMain_Click(null, null);
                    else if(questionnaire.Position == "ПОКРІВЕЛЬНИК")
                        Bsupp_Click(null, null);
                    else
                        BSupp2_Click(null, null);
                    break;

                case Stage.ProcessingInside:
                    SetClik(BVnytr);
                    BVnytr_MouseDown(null, null);
                    if (questionnaire.Position == "ШТУКАТУР")
                        BMain_Click(null, null);
                    else if (questionnaire.Position == "МАЛЯР")
                        Bsupp_Click(null, null);
                    else if (questionnaire.Position == "СТОЛЯР")
                        BSupp2_Click(null, null);
                    else
                        BSupp3_Click(null, null);
                    break;
            }
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
            stage = Stage.ProcessingInside;
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
            border.BorderThickness = new Thickness(2, 2, 2, 2);
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
            stage = Stage.Construction;
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
            stage = Stage.Roofing;
        }

        private void BFundament_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClik(BFundament);
            SetUnClik(BDax, BVnytr, BStina);
            BMain.Content = "МОНОЛІДЧИК";
            Bsupp.Content = "ПОМІЧНИК";
            BSupp3.Visibility = Visibility.Collapsed;
            BSupp2.Visibility = Visibility.Collapsed;
            stage = Stage.Earthwork;
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

    }
}

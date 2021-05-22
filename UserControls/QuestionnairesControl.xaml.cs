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
using Сonstruction_сompany.View;

namespace Сonstruction_сompany.UserControls
{
    /// <summary>
    /// Логика взаимодействия для QuestionnairesControl.xaml
    /// </summary>
    public partial class QuestionnairesControl : UserControl
    {
        private Grid grid;
        private List<QuestionnaireView> questionnaireViews;
        public QuestionnairesControl( ref Grid grid, User user)
        {
            this.grid = grid;
            questionnaireViews = new List<QuestionnaireView>();
            InitializeComponent();
            InitListByUserID(2);
            ListViewQuest.ItemsSource = questionnaireViews;
        }
        private void InitListByUserID(int ID)
        {
            Questionnaire questionnaire = null; // test
            questionnaireViews.Add(new QuestionnaireView(questionnaire));
        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            grid.Children.Clear();
            grid.Children.Add(new CreateQuestionnaire());
        }
    }
}

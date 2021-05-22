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
using Сonstruction_сompany.RequestToServer;
using Сonstruction_сompany.View;

namespace Сonstruction_сompany.UserControls
{
    /// <summary>
    /// Логика взаимодействия для QuestionnairesControl.xaml
    /// </summary>
    public partial class QuestionnairesControl : UserControl
    {
        private Grid grid;
        User user;
        private List<Questionnaire> questionnaires;
        private List<QuestionnaireView> questionnaireViews;
        public QuestionnairesControl( ref Grid grid, User user)
        {
            this.user = user;
            this.grid = grid;
            questionnaires = new List<Questionnaire>();
            questionnaireViews = new List<QuestionnaireView>();

            InitializeComponent();
            InitListByUserID(2);

            ListViewQuest.ItemsSource = questionnaireViews;
        }
        private void InitListByUserID(int ID)
        {

            Questionnaire questionnaire = null;
            questionnaireViews.Add(new QuestionnaireView(questionnaire));

            questionnaires = HttpQuestionnaireRequest.GetQuestionnaireByUserID((int)user.id);

            foreach (var item in questionnaires)
            {
                questionnaireViews.Add(new QuestionnaireView(item));
            }
        }
        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            grid.Children.Clear();
            grid.Children.Add(new CreateQuestionnaire(user));
        }
    }
}

using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Сonstruction_сompany.UserControls;
using Сonstruction_сompany.View;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public class ListItemMenu
    {
        #region Data fields
        public List<MenuItem> menuItems;
        #endregion
        #region Geters
        public List<MenuItem> _MenuItems
        {
            get
            {
                return menuItems;
            }
        }
        #endregion
        #region Constructors
        public ListItemMenu()
        {
            menuItems = new List<MenuItem>();
        }
        #endregion
        #region Methods
        public void SetWorkerItemMenu(ref User user, Grid grid)
        {
            
            menuItems = new List<MenuItem>()
            {
                new MenuItem("Questionnaire", PackIconKind.QuestionAnswer, "Анкета", new QuestionnairesControl(ref grid, user)),
                new MenuItem("Groups", PackIconKind.Group, "Команда"),
                new MenuItem("Task", PackIconKind.CalendarTask, "Завдання"),
                new MenuItem("Cabinet", PackIconKind.FileCabinet, "Кабінет", new UserCabinet(ref user))
            };
        }
        public void SetCustomerItemMenu(ref User user)
        {
            menuItems = new List<MenuItem>()
            {
                new MenuItem("Order", PackIconKind.QuestionAnswer, "Замовлення"),
                new MenuItem(".....", PackIconKind.Add, "......"),
                new MenuItem("Cabinet", PackIconKind.FileCabinet, "Кабінет", new UserCabinet(ref user))
            };
        }
        #endregion
    }
}

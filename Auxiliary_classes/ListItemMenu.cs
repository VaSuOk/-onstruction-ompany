using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using Сonstruction_сompany.UserControls;

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
            SetWorkerItemMenu();
        }
        #endregion
        #region Methods
        public void SetWorkerItemMenu()
        {
            
            menuItems = new List<MenuItem>()
            {
                new MenuItem("Questionnaire", PackIconKind.QuestionAnswer, "Анкета"),
                new MenuItem("Groups", PackIconKind.Group, "Команда"),
                new MenuItem("Task", PackIconKind.CalendarTask, "Завдання"),
                new MenuItem("Cabinet", PackIconKind.FileCabinet, "Кабінет", new UserCabinet())
            };
        }
        public void SetCustomerItemMenu()
        {
            menuItems = new List<MenuItem>()
            {
                new MenuItem("Order", PackIconKind.QuestionAnswer, "Замовлення"),
                new MenuItem(".....", PackIconKind.Add, "......"),
                new MenuItem("Cabinet", PackIconKind.FileCabinet, "Кабінет", new UserCabinet())
            };
        }
        #endregion
    }
}

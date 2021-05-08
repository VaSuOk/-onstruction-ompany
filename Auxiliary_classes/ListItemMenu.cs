using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

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
        #region Constructions
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
                new MenuItem("Home", PackIconKind.HomePlus, "Головна сторінка"),
                new MenuItem("Home", PackIconKind.HomePlus, "Головна сторінка")
            };
        }
        public void SetCustomerItemMenu()
        {

        }
        #endregion
    }
}

using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public class MenuItem
    {
        #region Data field
        public string xName { get; }
        public PackIconKind icon { get; }
        public string data { get; }
        #endregion
        #region Constructions
        public MenuItem()
        {
            this.xName = "";
            //this.icon = new PackIconKind();
            this.data = "";
        }
        public MenuItem(string xName, PackIconKind icon, string data)
        {
            this.xName = xName;
            this.icon = icon;
            this.data = data;
        }
        #endregion
    }
}

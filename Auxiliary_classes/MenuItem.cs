﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public class MenuItem
    {
        #region Data field
        public string xName { get; }
        public PackIconKind icon { get; }
        public string data { get; set; }
        public UserControl usc { get; set; }
        #endregion

        #region Constructions
        public MenuItem()
        {
            this.xName = "";
            this.icon = PackIconKind.None;
            this.data = "";
            usc = null;
        }
        public MenuItem(string xName = "", PackIconKind icon = PackIconKind.None, string data = "", UserControl  usc = null)
        {
            this.xName = xName;
            this.icon = icon;
            this.data = data;
            this.usc = usc;
        }
        #endregion
    }
}

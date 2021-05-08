using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public class ItemSlide
    {
        #region Data fields
        public int id { get; }
        public string image { get; set; }
        #endregion
        #region Constructors
        public ItemSlide()
        {
            this.id = 0;
            this.image = "";
        }
        public ItemSlide(int id, string image)
        {
            this.id = id;
            this.image = image;
        }
        #endregion
    }
}

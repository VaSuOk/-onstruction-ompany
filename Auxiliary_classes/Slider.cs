using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public class Slider
    {
        #region Data fields
        private List<ItemSlide> slids;
        public List<ItemSlide> Slides
        {
            get
            {
                return slids;
            }
        }
        #endregion
        #region Construction
        public Slider()
        {
            this.slids = new List<ItemSlide>();
        }
        #endregion
        #region Methods
        public ItemSlide AddSlide(string image)
        {
            ItemSlide itemSlide = new ItemSlide(slids.Count + 1, image);
            return(itemSlide);
        }
        public void MainInfoSlids()
        {
            slids = new List<ItemSlide>()
            {
                AddSlide("/Source/s4.jpg"),
                AddSlide("/Source/s3.jpg"),
                AddSlide("/Source/s2.jpg")
            };
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public class Slider
    {
        #region Data fields
        public int id;
        private bool slide_work;
        public ItemSlide[] slids;
        #endregion
        #region Construction
        public Slider(ref Border slide)
        {
            id = 2;
            slids = new ItemSlide[]
            {
                new ItemSlide(1, "D:/KPK/ДИПЛОМ/SOFT/Сonstruction сompany/Source/s4.jpg"),
                new ItemSlide(2, "D:/KPK/ДИПЛОМ/SOFT/Сonstruction сompany/Source/s3.jpg"),
                new ItemSlide(3, "D:/KPK/ДИПЛОМ/SOFT/Сonstruction сompany/Source/s2.jpg")
            };

            string imageName = slids[id - 1].image;
            ImageSourceConverter isc = new ImageSourceConverter();
            ImageBrush imgbr = new ImageBrush();
            imgbr.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Absolute));
            slide.Background = imgbr;
            slide_work = true;
            ChangeSlide(slide);
        }
        #endregion
        #region Methods

        public void Left_Click(ref Border slide)
        {
            id--;
            if (id == 0)
            {
                id = slids.Length;
            }
            SetSlide(ref slide);
        }
        public void Right_Click(ref Border slide)
        {
            SlideRight();
            SetSlide(ref slide);
        }
        private void SlideRight()
        {
            id++;
            if (id == slids.Length + 1)
            {
                id = 1;
            }

        }
        private void SetSlide(ref Border slide)
        {
            string imageName = slids[id - 1].image;
            ImageSourceConverter isc = new ImageSourceConverter();
            ImageBrush imgbr = new ImageBrush();
            imgbr.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Absolute));
            slide.Background = imgbr;
        }
        private async void ChangeSlide(Border slide)
        {
            while (slide_work)
            {
                await Task.Delay(2000);
                SlideRight();
                SetSlide(ref slide);
            }
        }
        #endregion
    }
}

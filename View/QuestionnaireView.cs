using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Сonstruction_сompany.View
{
    public class QuestionnaireView
    {
        public string Position { get; set; }
        public ImageSource image { get; set; }
        private string nimg;
        public System.Windows.Media.Brush brush { get; set; }

        public QuestionnaireView(Questionnaire questionnaire)
        {
            if(questionnaire != null)
            {
                Position = questionnaire.Position;
                if (questionnaire.stage == Stage.Earthwork)
                    nimg = @"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\fundament.png";
                else if (questionnaire.stage == Stage.Construction)
                    nimg = @"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\stina.jpg";
                else if (questionnaire.stage == Stage.Roofing)
                    nimg = @"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\dax.jpg";
                else if (questionnaire.stage == Stage.ProcessingInside)
                    nimg = @"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\vnytrszovns.jpg";
                if (questionnaire.activated)
                    brush = System.Windows.Media.Brushes.Green;
                else
                    brush = System.Windows.Media.Brushes.White;
            }
            else
            {
                Position = "Створити";
                nimg = @"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\додати.jpg";
                brush = System.Windows.Media.Brushes.Red;
            }
            var imageSource = new BitmapImage();
            MemoryStream ms;

            FileStream fs = new FileStream(nimg, FileMode.Open, FileAccess.Read);
            byte[] bStream = new byte[fs.Length];
            fs.Read(bStream, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            ms = new System.IO.MemoryStream(bStream);


            imageSource.BeginInit();
            imageSource.StreamSource = ms;
            imageSource.CacheOption = BitmapCacheOption.OnLoad;
            imageSource.EndInit();

            image = imageSource;
        }
    }
}

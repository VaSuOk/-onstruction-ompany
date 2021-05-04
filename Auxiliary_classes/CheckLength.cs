using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Сonstruction_сompany.Auxiliary_classes
{
    public static class CheckLength
    {
        #region Check
        //Перевірка розміру TextBox полів
        public static void Check(ref TextBox textBox, ref Border border, ref Label label)
        {
            if (textBox.Text.Length < 6)
            {
                label.Visibility = Visibility.Visible;
                label.Content = "minimum number of characters - 6!";
                border.Background = Brushes.Red;
            }
            else if (textBox.Text.Length > 18)
            {
                label.Visibility = Visibility.Visible;
                label.Content = "maximum number of characters - 18!";
                border.Background = Brushes.Red;
            }
            else
            {
                label.Visibility = Visibility.Hidden;
                border.Background = Brushes.Green;
            }
        }
        //Перевірка розміру Password полів
        public static void Check(ref PasswordBox passwordBox, ref Border border, ref Label label)
        {
            if (passwordBox.Password.Length < 6)
            {
                label.Visibility = Visibility.Visible;
                label.Content = "minimum number of characters - 6!";
                border.Background = Brushes.Red;
            }
            else if (passwordBox.Password.Length > 18)
            {
                label.Visibility = Visibility.Visible;
                label.Content = "maximum number of characters - 18!";
                border.Background = Brushes.Red;
            }
            else
            {
                label.Visibility = Visibility.Hidden;
                border.Background = Brushes.Green;
            }
        }
        #endregion
    }
}

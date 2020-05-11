using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationReverse {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      public MainWindow() {
         InitializeComponent();
      }

      public static readonly DependencyProperty AnimationDurationProperty = 
         DependencyProperty.RegisterAttached("AnimationDuration",typeof(Duration),typeof(MainWindow));
      public static void SetAnimationDuration(UIElement element, Duration value) {
         element.SetValue(AnimationDurationProperty, value);
      }
      public static Duration GetAnimationDuration(UIElement element) {
         return (Duration)element.GetValue(AnimationDurationProperty);
      }

      private void button_Click(object sender, RoutedEventArgs e) {
         double currentPosition = (button.ActualWidth - button.MinWidth) / (rootGrid.ActualWidth - button.MinWidth);
         if (button.Tag is bool && (bool)button.Tag)
            button.Tag = false;
         else {
            currentPosition = 1 - currentPosition;
            button.Tag = true;
         }
         SetAnimationDuration(button, new Duration(TimeSpan.FromSeconds(5 * currentPosition)));
      }   
   }

   public class ToWidthConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
         if (values[0] is bool && (bool)values[0])
            return values[2];
         else
            return values[1];
      }

      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
         throw new NotImplementedException();
      }
   }
}

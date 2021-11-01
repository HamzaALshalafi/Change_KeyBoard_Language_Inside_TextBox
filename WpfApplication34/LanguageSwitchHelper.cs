using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication34 {
    public class LanguageSwitchHelper : DependencyObject {




        public static string GetInputLanguageCulture(DependencyObject obj) {
            return (string)obj.GetValue(InputLanguageCultureProperty);
        }

        public static void SetInputLanguageCulture(DependencyObject obj, string value) {
            obj.SetValue(InputLanguageCultureProperty, value);
        }

        // Using a DependencyProperty as the backing store for InputLanguageCulture.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputLanguageCultureProperty =
            DependencyProperty.RegisterAttached("InputLanguageCulture", typeof(string), typeof(LanguageSwitchHelper), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.Inherits, 
                new PropertyChangedCallback((d, e) => {
                    
                    if(d is TextBox)
                        InputLanguageManager.SetInputLanguage(d, CultureInfo.CreateSpecificCulture(e.NewValue.ToString()));
                })));

        
    }
}

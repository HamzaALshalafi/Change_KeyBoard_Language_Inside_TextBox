using System;
using System.Windows;

namespace WpfApplication34
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window {
        DateTime date = DateTime.Now.AddDays(-11432);
        public MainWindow() {
            InitializeComponent();
           
        }

    }
}

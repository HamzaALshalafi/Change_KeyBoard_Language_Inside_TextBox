using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace WpfApplication34
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<MyPicture> MyPictures { get; }
        = new ObservableCollection<MyPicture>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog()
            {
                Title = "Select picture(s)",
                Filter = "All supported graphics|" +
                            "*.jpg;*.jpeg;*.png|" +
                            "JPEG (*.jpg;*.jpeg)|" +
                            "*.jpg;*.jpeg|" +
                            "Portable Network Graphic (*.png)" +
                            "|*.png",
                InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyPictures),
                Multiselect = true
            };
            if (op.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                // byte[] buffer = File.ReadAllBytes(op.FileName);
                // img.Source = buffer;
                // img.EditValue = buffer;
                //paste(op.FileNames.Select(f => new MyPicture
                //{
                //    Url = new Uri(f, UriKind.Absolute),
                //    Title = System.IO.Path.GetFileName(f)
                //}));
                foreach (var item in op.FileNames.ToList())
                {
                    byte[] buffer = File.ReadAllBytes(item);
                    
                    MyPictures.Add(new MyPicture() { Title = System.IO.Path.GetFileName(item), Url = buffer });
                    //paste(op.FileNames.Select(f => new MyPicture
                    //{
                    //    Url = buffer,
                    //    Title = System.IO.Path.GetFileName(f)
                    //}));
                }
             
            }
        }

        private void paste(IEnumerable<MyPicture> newPictures)
        {
            MyPictures.Clear();
            foreach (var item in newPictures)
            {
                MyPictures.Add(item);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in MyPictures)
            {
                System.Windows.MessageBox.Show(item.Url.ToString());
                System.Windows.MessageBox.Show(item.Title.ToString());
            }
        
        }
    }

    public class MyPicture
    {
        public byte[] Url { get; set; } // filename of image
        public string Title { get; set; }
    }
}


using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace MahappsDragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // http://wpftutorial.net/DragAndDrop.html

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsFlyout.IsOpen = true;
        }

        Point startPoint;

        private void List_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);
        }

        private void List_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem != null)
                {
                    // Find the data behind the ListViewItem
                    Image contact = (Image)listView.ItemContainerGenerator.
                        ItemFromContainer(listViewItem);

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", contact);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
            }
        }

        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void DropList_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DropList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Image contact = e.Data.GetData("myFormat") as Image;
                ListView source = contact.Parent as ListView;
                source.Items.Remove(contact);
                source.Items.Refresh();
                
                //// drop into the listview
                //Image listImage = new Image();
                //listImage.Source = contact.Source;
                //listImage.Height = contact.Height;
                //listImage.Width = contact.Width;
                //DropList.Items.Add(listImage);

                // drop into the canvas
                Image canvasImage = new Image();
                canvasImage.Source = contact.Source;
                canvasImage.Height = contact.Height;
                canvasImage.Width = contact.Width;
                int left = 0 + (int)(canvasImage.Width * DropCanvas.Children.Count);
                int top = 0 + (int)(canvasImage.Height * DropCanvas.Children.Count);
                Canvas.SetLeft(canvasImage, left);
                Canvas.SetTop(canvasImage, top);
                DropCanvas.Children.Add(canvasImage);
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DragList.Items.Clear();
            //DropList.Items.Clear();
            DropCanvas.Children.Clear();

            Label note = new Label();
            note.Content = "Left side is a ListView, right side is a Canvas.";
            //DropList.Items.Add(note);

            for (int i = 0; i < 4; i++)
            {
                Image contact = new Image();
                contact.Width = 64;
                contact.Height = 64;
                contact.Margin = new Thickness(10);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/MahappsDragAndDrop;component/mahapps.metro_med.png", UriKind.Relative);
                image.EndInit();
                contact.Source = image;
                DragList.Items.Add(contact);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsFlyout.IsOpen = false;
            MetroWindow_Loaded(sender, e);
        }
    }
}

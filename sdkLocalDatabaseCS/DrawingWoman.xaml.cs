using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using System.Windows.Resources;
using System.IO;
// Directive for the data model.
using LocalDatabaseSample.Model;

namespace sdkLocalDatabaseCS
{
    public partial class DrawingWoman : PhoneApplicationPage
    {
        int i = 1;
        int j = 1;
        public DrawingWoman()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
            changeListBoxBack(1);
        }
        
        public void changeBack(Image image, String url)
        {
            image.Source = new BitmapImage(new Uri(url, UriKind.Relative));
        }

        public void changeBack(Button btn, String url)
        {
            ImageBrush imageBrush = new ImageBrush();
            //imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:" + url, UriKind.RelativeOrAbsolute));
            imageBrush.ImageSource = new BitmapImage(new Uri(url, UriKind.Relative));
            btn.Background = imageBrush;
        }
        public void changeBack(ImageBrush image, String url)
        {
            image.ImageSource = new BitmapImage(new Uri(url, UriKind.Relative));
        }
        public void changeListBoxBack(int i)
        {
            switch (i)
            {
                case 1:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Visible;
                    style4.Visibility = Visibility.Visible;
                    style5.Visibility = Visibility.Visible;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/hair05_03.png");
                    changeBack(style3, "/Images/hair04_03.png");
                    changeBack(style4, "/Images/hair03_03.png");
                    changeBack(style5, "/Images/hair02_03.png");
                    break;
                case 2:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Collapsed;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/hat03_03.png");
                    break;
                case 3:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Visible;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/clothes04_03.png");
                    changeBack(style3, "/Images/clothes02_03.png");
                    break;
                case 4:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Visible;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/shoes01_03.png");
                    changeBack(style3, "/Images/shoes09_03.png");
                    break;
                case 5:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Visible;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/glass_03.png");
                    changeBack(style3, "/Images/glass01_03.png");
                    break;
                case 6:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Collapsed;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/mustache_03.png");
                    break;
                case 7:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Collapsed;
                    style3.Visibility = Visibility.Collapsed;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "/Images/PIC_03.png.png");
                    break;
                case 8:
                    style1.Visibility = Visibility.Visible;
                    style2.Visibility = Visibility.Visible;
                    style3.Visibility = Visibility.Visible;
                    style4.Visibility = Visibility.Collapsed;
                    style5.Visibility = Visibility.Collapsed;
                    style6.Visibility = Visibility.Collapsed;
                    style7.Visibility = Visibility.Collapsed;
                    style8.Visibility = Visibility.Collapsed;
                    changeBack(style1, "Images/clean.png");
                    changeBack(style2, "/Images/pant04_03.png");
                    changeBack(style3, "/Images/pant02_03.png");
                    break;
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveChangesToDB();
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            Microsoft.Devices.VibrateController.Default.Start(
                               TimeSpan.FromSeconds(0.1));
            var bitmap = new System.Windows.Media.Imaging.WriteableBitmap(
                            this.personcanvas, null);
            var stream = new System.IO.MemoryStream();
            System.Windows.Media.Imaging.Extensions.SaveJpeg(bitmap, stream,
                               bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
            stream.Position = 0;
            var mediaLib = new Microsoft.Xna.Framework.Media.MediaLibrary();
            var datetime = System.DateTime.Now;
            var filestring = datetime.Year % 100 + datetime.Month + datetime.Day +
                        datetime.Hour + datetime.Minute + datetime.Second;
            var filename =
                System.String.Format("historyperson" + filestring,
                        datetime.Year % 100, datetime.Month, datetime.Day,
                        datetime.Hour, datetime.Minute, datetime.Second);
            mediaLib.SavePicture(filename, stream);
            string historyperson = "historyperson" + filestring + ".jpg";

            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            using (Stream stream1 = storage.OpenFile(historyperson, FileMode.Create))
            {
                Extensions.SaveJpeg(bitmap, stream1, 300, 300, 0, 100);
            }

            // Create a new to-do item.
            ToDoItem newToDoItem = new ToDoItem
            {
                ItemName = @"historyperson" + filestring + ".jpg",
                //ItemName = img,
                Category = (ToDoCategory)categoriesListPicker.SelectedItem
            };

            // Add the item to the ViewModel.
            App.ViewModel.AddToDoItem(newToDoItem);
        }

        private void per_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
            j = 1;
            changeListBoxBack(i);
        }

        private void hat_Click(object sender, RoutedEventArgs e)
        {

            i = 2;
            j = 2;
            changeListBoxBack(i);
        }

        private void cloth_Click(object sender, RoutedEventArgs e)
        {

            i = 3;
            j = 3;
            changeListBoxBack(i);
        }

        private void love_Click(object sender, RoutedEventArgs e)
        {

            i = 4;
            j = 4;
            changeListBoxBack(i);
        }

        private void glass_Click(object sender, RoutedEventArgs e)
        {

            i = 5;
            j = 5;
            changeListBoxBack(i);
        }

        private void bear_Click(object sender, RoutedEventArgs e)
        {

            i = 6;
            j = 6;
            changeListBoxBack(i);
        }

        private void hairstyle_Click(object sender, RoutedEventArgs e)
        {

            i = 7;
            j = 7;
            changeListBoxBack(i);
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            i = 8;
            j = 8;
            changeListBoxBack(i);
        }

        private void style1_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair01_03.jpg");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat_03.jpg");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/Aclothes04_03.jpg");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes_03.jpg");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass_03.jpg");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.jpg");
                    break;
                case 7:
                    //changeBack(personman, "/Images/PIC_03.jpg");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/kuzi_03.jpg");
                    break;
            }
        }

        private void style2_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair05_03.png");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat03_03.png");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/clothes04_03.png");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes01_03.png");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass_03.png");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.png");
                    break;
                case 7:
                    changeBack(personman, "/Images/PIC_02 (2).png.png");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/pant04_03.png");
                    break;
            }
        }

        private void style3_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair04_03.png");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat02_03.png");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/clothes02_03.png");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes09_03.png");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass01_03.png");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.png");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/pant02_03.png");
                    break;
            }
        }

        private void style4_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair03_03.png");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat_03.png");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/clothes01_03.png");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes02_03.png");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass_03.png");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.png");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/pant01_03.png");
                    break;
            }
        }

        private void style5_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair02_03.png");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat_03.png");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/clothes04_01_03.png");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes_03.png");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass_03.png");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.png");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/pant02_03.png");
                    break;
            }
        }

        private void style6_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair01_03.png");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat_03.png");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/clothes04_03.png");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes_03.png");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass_03.png");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.png");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/pant06_03.png");
                    break;
            }
        }
        private void style7_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    changeBack(personmanhair, "/Images/hair01_03.png");
                    break;
                case 2:
                    changeBack(personhat, "/Images/hat_03.png");
                    break;
                case 3:
                    changeBack(personmancloth, "/Images/Aclothes04_03.png");
                    break;
                case 4:
                    changeBack(personmanshose, "/Images/shoes_03.png");
                    break;
                case 5:
                    changeBack(personmanglass, "/Images/glass_03.png");
                    break;
                case 6:
                    changeBack(personmustache, "/Images/mustache_03.png");
                    break;
                case 8:
                    changeBack(personmanpants, "/Images/pant06_03.png");
                    break;
            }
        }
    }
}
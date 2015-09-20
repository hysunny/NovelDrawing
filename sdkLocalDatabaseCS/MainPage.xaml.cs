/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
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
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
// Directive for the ViewModel.
using LocalDatabaseSample.Model;

namespace sdkLocalDatabaseCS
{
    public partial class MainPage : PhoneApplicationPage
    {
         MediaLibrary mediaL = new MediaLibrary();
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;

            
            //GetPic();
            //GetImg();
            //imghis.Source = @"AppData/{77a80316-384d-40dc-a8c3-c4054676e85c}/Local";
            //imghis.Source = @"historyperson68.jpg";
           // StreamReader sr = new StreamReader(@"C:\Data\Programs\{77A80316-384D-40DC-A8C3-C4054676E85C}\Install\historyperson.jpg");
            //imghis.Source = Utils.GetImage("historyperson68.jpg");
            //GetImage();
            //txtpath.Text=sr.ReadLine();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Drawing.xaml", UriKind.Relative));
        }
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    //var pict = value as Picture;
        //    //if (pict == null) return null;

        //    //var img = new BitmapImage();
        //    //img.SetSource(pict.GetThumbnail());
        //    BitmapImage imgtwo = GetImage(value.ToString());

        //    return imgtwo;
        //}
        //public static BitmapImage GetImage(string file)
        //{
        //    BitmapImage bi = new BitmapImage();
        //    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        //    {
        //        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(file, FileMode.Open, FileAccess.Read))
        //        {
        //            bi.SetSource(fileStream);
        //        }
        //    }
        //    return bi;
        //}
        //BitmapImage GetImg(string filename)
        //{
        //    BitmapImage bi = new BitmapImage();

        //    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        //    {
        //        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(filename, FileMode.Open, FileAccess.Read))
        //        {
        //            bi.SetSource(fileStream);
        //            //this.imghis.Height = bi.PixelHeight;
        //            //this.imghis.Width = bi.PixelWidth;
        //        }
        //    }
        //    return bi;
        //}
        //void GetPic()
        //{

        //    //获得媒体库中所有的图片
        //    PictureCollection pic = mediaL.Pictures;
        //    //PictureAlbumCollection hispic;
        //    BitmapImage bmp = new BitmapImage();
        //    //imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:" + url, UriKind.RelativeOrAbsolute));
        //    bmp.UriSource = new Uri("/Pictures/Saved Pictures/historyperson(4).jpg", UriKind.Relative);
            
        //    //PictureCollection hispic;
        //    if (pic.Count > 1)
        //    {
        //        BitmapImage bi = new BitmapImage();
        //        //知识点②
        //        Picture pc;
        //        int i = 0;
        //        int j = 0;
        //        int leg = pic.Count;
        //        //Image img = new Image();
        //        for (i = 0; i < leg; i++)
        //        {
        //            pc = pic[i];
        //            bi.SetSource(pc.GetImage());

        //            if (pc.Name.Contains("historyperson"))
        //            {
        //                //img.Source = bi;
        //               // hisimg.Source = bi;
        //            }
        //        }
                
        //        Picture pc1 = pic[7];
        //        bi.SetSource(pc1.GetImage());
        //        //txtpath.Text = Microsoft.Xna.Framework.Media.PhoneExtensions.MediaLibraryExtensions.GetPath(imghis.Source );
        //        txtpath.Text = "图片名称：" + pc1.Name + ";\n该图片相集名称：" + pc1.Album.Name + ";\n获取照片摄制时间" + pc1.Date;
        //        //Picture pc3 = pic[8];
        //        //bi.SetSource(pc1.GetImage());
        //        //history2.Source = bi;
        //        ////txtAttr2.Text = "图片名称：" + pc3.Name + ";\n该图片相集名称：" + pc3.Album.Name + ";\n获取照片摄制时间" + pc3.Date;
        //        //Picture pc2 = pic[7];
        //        //bi.SetSource(pc2.GetImage());
        //        //history3.Source = bi;
        //        //txtAttr3.Text = "图片名称：" + pc2.Name + ";\n该图片相集名称：" + pc2.Album.Name + ";\n获取照片摄制时间" + pc2.Date;
        //    }
        //}
        
        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                ToDoItem toDoForDelete = button.DataContext as ToDoItem;

                App.ViewModel.DeleteToDoItem(toDoForDelete);
            }

            // Put the focus back to the main page.
            this.Focus();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveChangesToDB();
        }

        private void singleBoy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Drawing.xaml", UriKind.Relative));
        }

        private void singleWoman_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DrawingWoman.xaml", UriKind.Relative));
        }
    }
}

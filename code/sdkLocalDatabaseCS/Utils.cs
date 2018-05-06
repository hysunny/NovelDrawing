using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDatabaseSample.Model;
using LocalDatabaseSample.ViewModel;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone;

namespace sdkLocalDatabaseCS
{
    class Utils
    {

        public static ImageSource GetImage(string file)
        {
            
            BitmapImage bi = new BitmapImage();
            ImageSource imghistory = null;
            using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                
                    //using {IsolatedStorageFileStream writeFileStream =isolatedStorageFile.OpenFile(file,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite)}
                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(file, FileMode.Open, FileAccess.Read))
                        {
                            if (fileStream != null) 
                            { 
                                imghistory = PictureDecoder.DecodeJpeg(fileStream);
                            }
                            fileStream.Dispose();
                        }
                    }  
            }
            
            return imghistory;
        }
    }
}

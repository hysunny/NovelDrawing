using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Controls;
using Microsoft.Phone;
using System.Windows.Media;
namespace sdkLocalDatabaseCS
{
    public class ImageConvert:IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var pict = value as Picture;
            //if (pict == null) return null;

            //var img = new BitmapImage();
            //img.SetSource(pict.GetThumbnail());
            //BitmapImage picture = new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));
            //Image imgtwo = new Image() ;
            ////imgtwo.SetSource(Utils.GetImage(value.ToString()));
            //imgtwo.Source = Utils.GetImage(value.ToString());
            ImageSource imghistory = null;
            

                //using {IsolatedStorageFileStream writeFileStream =isolatedStorageFile.OpenFile(file,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite)}
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(value.ToString(), FileMode.Open, FileAccess.Read))
                    {
                        if (fileStream != null)
                        {
                            imghistory = PictureDecoder.DecodeJpeg(fileStream);
                        }
                        fileStream.Dispose();
                    }
                }
            

            return imghistory;
            //return imgtwo;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        } 
    }
}

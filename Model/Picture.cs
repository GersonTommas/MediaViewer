using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MediaViewer.Model
{
    /// <summary>
    /// Class to map files as Pictures (Derives from Media), has properties FileInfo _fileInfo and Uri _uri
    /// </summary>
    public class Picture : Media
    {

        #region Private Variables

        // Image as Thumbnail
        private ImageSource _thumbnail;

        #endregion


        #region Public Variables

        /// <summary>
        /// Image as Thumbnail one by one, by calling the "LoadImage" void
        /// </summary>
        public ImageSource Thumbnail
        {
            get
            {
                if (_thumbnail == null)
                {
                    ThreadPool.QueueUserWorkItem(LoadImage);
                }

                return _thumbnail;
            }
        }

        #endregion


        #region Helper

        // Load Imnages one by one
        private void LoadImage(object state)
        {
            byte[] buffer = File.ReadAllBytes(_fileInfo.FullName);
            MemoryStream mem = new MemoryStream(buffer);

            BitmapDecoder decoder = BitmapDecoder.Create(mem, BitmapCreateOptions.None, BitmapCacheOption.None);

            _thumbnail = decoder.Frames[0];

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate { OnPropertyChanged("Thumbnail"); });
        }

        #endregion

    }
}

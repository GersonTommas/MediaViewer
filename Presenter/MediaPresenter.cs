using System.Collections.ObjectModel;
using System.IO;
using MediaViewer.Model;

namespace MediaViewer.Presenter
{
    /// <summary>
    /// Presenter for Media (Images, Videos, Music)
    /// </summary>
    /// <typeparam name="T">Media Files of any type</typeparam>
    public class MediaPresenter<T> where T : Media, new()
    {

        #region Private Variables

        // File extensions for the type of files to search
        private readonly string[] _fileExtensions;
        // The path of the directory to look for the desired formats from _fileExtensions
        private readonly string _mediaPath;
        // True - Includes sub folders on the search : False - Only main folder is searched
        private readonly bool _subFolders = false;

        // List of files founded
        private ObservableCollection<Media> _media;

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor 1/2
        /// </summary>
        /// <param name="mediaPath"> The Path of the directory to look for the desired file formats </param>
        /// <param name="extensions"> The desired formats to look for on the directory </param>
        public MediaPresenter(string mediaPath, params string[] extensions)
        {
            _mediaPath = mediaPath;
            _fileExtensions = extensions;
        }

        /// <summary>
        /// Default Constructor 2/2
        /// </summary>
        /// <param name="mediaPath"> The Path of the directory to look for the desired file formats </param>
        /// <param name="subFolders"> True - Inlcudes sub folders on the search : False - Only main folder is searched </param>
        /// <param name="extensions"> The desired formats to look for on the directory </param>
        public MediaPresenter(string mediaPath, bool subFolders, params string[] extensions)
        {
            _mediaPath = mediaPath;
            _fileExtensions = extensions;
            _subFolders = subFolders;
        }

        #endregion


        #region Public Variables

        /// <summary>
        /// List of files founded
        /// </summary>
        public ObservableCollection<Media> Media
        {
            get
            {
                if (_media == null) LoadMedia();
                return _media;
            }
        }

        #endregion


        #region Helper

        /// <summary>
        /// Executes the required search for the files on the respective directory using the extensions as search filters, and the variable _subFolders to include (or not) the sub folders on the search
        /// </summary>
        private void LoadMedia()
        {
            if (string.IsNullOrEmpty(_mediaPath)) return;

            _media = new ObservableCollection<Media>();
            DirectoryInfo directoryInfo = new DirectoryInfo(_mediaPath);

            foreach(string extension in _fileExtensions)
            {
                FileInfo[] pictureFiles = null;
                if (_subFolders) { pictureFiles = directoryInfo.GetFiles(extension, SearchOption.AllDirectories); }
                else { pictureFiles = directoryInfo.GetFiles(extension, SearchOption.TopDirectoryOnly); }


                foreach (FileInfo fileInfo in pictureFiles)
                {
                    if (_media.Count == 50) break;

                    T media = new T();
                    media.SetFile(fileInfo);
                    _media.Add(media);
                }
            }
        }

        #endregion

    }
}

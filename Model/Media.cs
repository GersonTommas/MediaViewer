using System;
using System.ComponentModel;
using System.IO;

namespace MediaViewer.Model
{
    /// <summary>
    /// Model that maps the Media class.
    /// </summary>
    public class Media : INotifyPropertyChanged
    {

        #region Protected Variables

        // INTERNAL - All the info of the file
        protected FileInfo _fileInfo;
        // INTERNAL - File path
        protected Uri _uri;

        #endregion


        #region Public Variables

        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(_fileInfo.Name); }
        }

        /// <summary>
        /// The Path of the directory of the file
        /// </summary>
        public string Directory
        {
            get { return _fileInfo.Directory.Name; }
        }

        /// <summary>
        /// The Full Path of the file
        /// </summary>
        public Uri Uri
        {
            get { return _uri; }
        }

        /// <summary>
        /// Sets the info of the file on the required variables
        /// </summary>
        /// <param name="fileInfo">FileInfo of the file</param>
        public void SetFile(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            _uri = new Uri(_fileInfo.FullName);

            OnPropertyChanged("Name");
            OnPropertyChanged("Directory");
            OnPropertyChanged("Uri");
        }

        #endregion


        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}

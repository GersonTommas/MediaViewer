using System;
using System.Windows.Controls;
using MediaViewer.Model;
using MediaViewer.Views;

namespace MediaViewer.Presenter
{
    public class MenuPresenter
    {

        #region Private Variables

        // Loads the previous controller for the Main Window
        private readonly ApplicationController _controller;

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="controller"> Main Window Controller </param>
        public MenuPresenter(ApplicationController controller)
        {
            _controller = controller;
            _controller.DisplayInShell(new MenuView(this));
        }

        #endregion


        #region Public Functions
        /// <summary>
        /// Displays the FontViewerView page
        /// </summary>
        public void ShowFonts()
        {
            Display<FontViewerView>();
        }

        /// <summary>
        /// Displays the SimpleContactsView page
        /// </summary>
        public void ShowContacts()
        {
            Display<SimpleContactsView>();
        }


        /// <summary>
        /// Displays the PictureView page loading the required images
        /// </summary>
        public void DisplayPictures()
        {
            string myPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            Display<PictureView, Picture>(myPicturesPath, true, "*.jpg", "*.gif", "*.png", "*.bmp");
        }

        /// <summary>
        /// Loads the MusicView page loading the required music
        /// </summary>
        public void ListenToMusic()
        {
            Display<MusicView, Media>(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), true, "*.wma", "*.mp3");
        }

        /// <summary>
        /// Loads the VideoView page loading the required videos
        /// </summary>
        public void WatchVideo()
        {
            Display<VideoView, Media>(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), true, "*.wmv", "*.avi", "*.mp4");
        }

        //TEST VOID FOR BUTTON PRESS
        public void TEST()
        {
            Display<AuutomaticChhangeNotification>();
        }

        #endregion


        #region Helper

        /// <summary>
        /// Loads the required page with the required files including (or not) subfolders
        /// </summary>
        /// <typeparam name="View"> Page to load </typeparam>
        /// <typeparam name="MediaType"> Type of files (Media for images, music and videos) </typeparam>
        /// <param name="mediaPath"> The path of the directory to look for the desired formats from _fileExtensions </param>
        /// <param name="subFolder"> True - Includes sub folders on the search : False - Only main folder is searched </param>
        /// <param name="extensions"> File extensions for the type of files to search </param>
        private void Display<View, MediaType>(string mediaPath, bool subFolder = true, params string[] extensions)
            where View : UserControl, new()
            where MediaType : Media, new()
        {
            MediaPresenter<MediaType> presenter = new MediaPresenter<MediaType>(mediaPath, subFolder, extensions);

            View view = new View();
            view.DataContext = presenter;

            _controller.DisplayInShell(view);
        }

        /// <summary>
        /// Loads the required View without any DataContext
        /// </summary>
        /// <typeparam name="View"> The page to display </typeparam>
        private void Display<View>()
            where View : UserControl, new()
        {
            View view = new View();

            _controller.DisplayInShell(view);
        }
        #endregion

    }
}

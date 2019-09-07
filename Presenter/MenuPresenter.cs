using System;
using System.Windows.Controls;
using MediaViewer.Model;
using MediaViewer.Views;

namespace MediaViewer.Presenter
{
    public class MenuPresenter
    {
        private readonly ApplicationController _controller;

        public MenuPresenter(ApplicationController controller)
        {
            _controller = controller;
            _controller.DisplayInShell(new MenuView(this));
        }

        public void DisplayPictures()
        {
            string myPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            Display<PictureView, Picture>(myPicturesPath, "*.jpg", "*.gif", "*.png", "*.bmp");
        }

        public void ListenToMusic()
        {
            Display<MusicView, Media>(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "*.wma", "*.mp3");
        }

        public void WatchVideo()
        {
            Display<VideoView, Media>(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "*.wmv", "*.avi", "*.mp4");
        }

        #region Helper

        private void Display<View, MediaType>(string mediaPath, params string[] extensions)
            where View : UserControl, new()
            where MediaType : Media, new()
        {
            MediaPresenter<MediaType> presenter = new MediaPresenter<MediaType>(mediaPath, extensions);

            View view = new View();
            view.DataContext = presenter;

            _controller.DisplayInShell(view);
        }

        #endregion
    }
}

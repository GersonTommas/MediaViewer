using System.Windows;
using System.Windows.Controls;
using MediaViewer.Presenter;

namespace MediaViewer.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView(MenuPresenter presenter)
        {
            InitializeComponent();
            DataContext = presenter;
        }

        public MenuPresenter Presenter
        {
            get { return (MenuPresenter)DataContext; }
        }

        private void Video_Click(object sender, RoutedEventArgs e)
        {
            Presenter.WatchVideo();
        }

        private void Music_Click(object sender, RoutedEventArgs e)
        {
            Presenter.ListenToMusic();
        }

        private void Pictures_Click(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayPictures();
        }
    }
}

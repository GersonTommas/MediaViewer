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
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="presenter"> Menu Presenter </param>
        public MenuView(MenuPresenter presenter)
        {
            InitializeComponent();
            DataContext = presenter;
        }

        /// <summary>
        /// Casts the actual DataContext into a MenuPresenter object
        /// </summary>
        public MenuPresenter Presenter
        {
            get { return (MenuPresenter)DataContext; }
        }

        // Font Viewer Button Click Command
        private void FontViewer_Click(object sender, RoutedEventArgs e)
        {
            Presenter.ShowFonts();
        }


        // Simple Contacts Button Click Command
        private void SimpleContacts_Click(object sender, RoutedEventArgs e)
        {
            Presenter.ShowContacts();
        }


        // Video Button Click Command
        private void Video_Click(object sender, RoutedEventArgs e)
        {
            Presenter.WatchVideo();
        }

        // Music Button Click Command
        private void Music_Click(object sender, RoutedEventArgs e)
        {
            Presenter.ListenToMusic();
        }

        // Pictures Button Click Command
        private void Pictures_Click(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayPictures();
        }


        // TEST BUTTON
        private void TEST_Click(object sender, RoutedEventArgs e)
        {
            Presenter.TEST();
        }
    }
}

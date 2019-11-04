using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaViewer.Views
{
    /// <summary>
    /// Interaction logic for AuutomaticChhangeNotification.xaml
    /// </summary>
    public partial class AuutomaticChhangeNotification : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AuutomaticChhangeNotification()
        {
            InitializeComponent();
            DataContext = new Person();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Person)DataContext).FirstName = "My New Name";
        }
    }
}

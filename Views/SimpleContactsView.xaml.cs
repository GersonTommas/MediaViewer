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
    /// Interaction logic for SimpleContactsView.xaml
    /// </summary>
    public partial class SimpleContactsView : UserControl
    {
        /// <summary>
        /// Defalut constructor
        /// </summary>
        public SimpleContactsView()
        {
            InitializeComponent();
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact saved.", "Save");
        }
    }
}

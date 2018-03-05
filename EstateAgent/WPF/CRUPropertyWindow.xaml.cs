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
using System.Windows.Shapes;

namespace EstateAgent.WPF
{
    /// <summary>
    /// Interaction logic for CRUPropertyWindow.xaml
    /// </summary>
    public partial class CRUPropertyWindow : Window
    {
        public CRUPropertyWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource propertyDTOViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("propertyDTOViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // propertyDTOViewSource.Source = [generic data source]
        }
    }
}

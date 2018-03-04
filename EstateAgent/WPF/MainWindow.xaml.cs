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
using EstateAgent.LinqToSQL;
namespace EstateAgent.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataProvider dataProvider;
        public MainWindow()
        {
            InitializeComponent();
            dataProvider = new DataProvider();

            LandlordsDataGrid.ItemsSource = dataProvider.GetLandLords();

        }

        private void LandlordsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if( !object.ReferenceEquals(sender,LandlordsDataGrid))
            {
                return;
            }

            if(LandlordsDataGrid.SelectedItem is Landlord selectedLandlord)
            {
                PropertiesDataGrid.ItemsSource = dataProvider.GetPropertiesOfLandlord(selectedLandlord.LandlordId);
            }

        }

        private void ButtonCreateLandlord_Click(object sender, RoutedEventArgs e)
        {

            var landLord = new Landlord();
            var window = new CRULandLordWindow(landLord);
            window.ShowDialog();
        }
    }
}

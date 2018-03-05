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

            RefreshData();
        }

        void RefreshData()
        {
            LandlordsDataGrid.ItemsSource = dataProvider.GetLandLords();
        }

        private void LandlordsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if( !object.ReferenceEquals(sender,LandlordsDataGrid))
            {
                return;
            }

            if(LandlordsDataGrid.SelectedItem is LandlordDTO selectedLandlord)
            {
                PropertiesDataGrid.ItemsSource = dataProvider.GetPropertiesOfLandlord(selectedLandlord.Id);
            }

        }

        private void ButtonCreateLandlord_Click(object sender, RoutedEventArgs e)
        {
            var landLord = new LandlordDTO();
            var window = new CRULandLordWindow(landLord);
            window.Title = "Create Landlord";
            window.CRUButton.Content = "Create";
            window.ShowDialog();

            dataProvider.CreateLandLord(landLord);

            RefreshData();
        }

        private void ButtonDeleteLandlord_Click(object sender, RoutedEventArgs e)
        {
            if (LandlordsDataGrid.SelectedItem is LandlordDTO selectedLandlord)
            {
                var msg = $"Deleting this landlord will also delete all properties owned by this landlord.\n" +
                    $" Do you wish to proceed?";
                var result = MessageBox.Show(msg, "Delete Landlord",MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
                {
                    dataProvider.DeleteLandLord(selectedLandlord.Id);
                    RefreshData();
                }
            }
        }
    }
}

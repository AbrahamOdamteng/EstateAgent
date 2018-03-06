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
using EstateAgent.LinqToSQL;
namespace EstateAgent.WPF
{
    /// <summary>
    /// Interaction logic for CRULandLordWindow.xaml
    /// </summary>
    public partial class CRULandLordWindow : Window
    {
        readonly LandlordDTO Landlord;

        public CRULandLordWindow(LandlordDTO landlord, CRUMode cruMode)
        {
            InitializeComponent();
            this.Landlord = landlord;

            if(cruMode == CRUMode.Create)
            {
                this.Title = "Create Landlord";
                this.CRUButton.Content = "Create";
            }
            else
            {
                this.Title = "Update Landlord";
                this.CRUButton.Content = "Update";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource landlordViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("landlordViewSource")));
            // Load data by setting the CollectionViewSource.Source property:

            landlordViewSource.Source = new LandlordDTO[] { this.Landlord };
        }

        private void CRUButton_Click(object sender, RoutedEventArgs e)
        {
            if (Landlord.ContainsEmptyValues())
            {
                MessageBox.Show("Empty Values are not allowed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}

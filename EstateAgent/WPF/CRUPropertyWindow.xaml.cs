﻿using System;
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
    /// Interaction logic for CRUPropertyWindow.xaml
    /// </summary>
    public partial class CRUPropertyWindow : Window
    {
        readonly PropertyDTO propertyDTO;


        public CRUPropertyWindow(PropertyDTO propertyDto, CRUMode cruMode)
        {
            InitializeComponent();
            propertyDTO = propertyDto;


            if (cruMode == CRUMode.Create)
            {
                this.Title = "Create Property";
                this.CRUButton.Content = "Create";
            }
            else
            {
                this.Title = "Update Property";
                this.CRUButton.Content = "Update";
            }

            statusComboBox.ItemsSource = Enum.GetValues(typeof(PropertyStatus));
            if (propertyDTO != null)
            {
                statusComboBox.SelectedItem = propertyDTO.Status;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource propertyDTOViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("propertyDTOViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            if (propertyDTO is null) return;

            propertyDTOViewSource.Source = new PropertyDTO[] { propertyDTO };

        }

        private void CRUButton_Click(object sender, RoutedEventArgs e)
        {
            if (propertyDTO.ContainsEmptyValues())
            {
                MessageBox.Show("Empty Values are not allowed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventPlanner.Pages.Admin
{
    /// <summary>
    /// Interaction logic for PrrofilePage.xaml
    /// </summary>
    public partial class PrrofilePage : Page
    {
        public PrrofilePage()
        {
            InitializeComponent();
        }

        private void tutorialButtonProfilePageAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new EditProfileModal();
            w.ShowDialog();
        }

    }
}

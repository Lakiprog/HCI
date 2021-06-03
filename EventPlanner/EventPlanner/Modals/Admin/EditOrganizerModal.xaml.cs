using EventPlanner.Models;
using EventPlanner.ViewModels;
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

namespace EventPlanner.Modals.Admin
{
    /// <summary>
    /// Interaction logic for EditOrganizerModal.xaml
    /// </summary>
    public partial class EditOrganizerModal : Window
    {
        private Organizer current;
        public EditOrganizerModal()
        {
            InitializeComponent();
            //PasswordEditOrganizerPasswordBox.Password = ((OneOrganizerViewModel)this.DataContext).Organizer.Password;
        }

        public EditOrganizerModal(Organizer o)
        {
            current = o;
            InitializeComponent();
        }

        private void CancelEditOrganizerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

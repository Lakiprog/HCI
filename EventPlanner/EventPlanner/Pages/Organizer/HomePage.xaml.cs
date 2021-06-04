using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EventPlanner.Pages.Organizer
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {

        public HomePage()
        {
            InitializeComponent();
            FreeRequestsListView.ItemsSource = new List<String> { "Resourceful project manager with 10 years of experience", 
            "Engaging high school teacher skilled in ESL and IEPS", "Multi-lingual licensed RN with 5+ years of experience in pediatrics" };

            UpcomingEventsListView.ItemsSource = new List<String> { "Hard-working CNA and Nightingale Award recipient",
            "Personable sales representative who exceeds sales targets by 25%", "Skilled bartender with 4 years’ experience in high-end restaurants",
            "Likable manager and winner of management ABA", "Diplomatic receptionist with deep interpersonal skills"};
        }

        private void AddCollaboratorButton_Click(object sender, RoutedEventArgs e)
        {
            var AddCollaboratorModal = new Modals.AddCollaboratorModal();
            AddCollaboratorModal.ShowDialog();
        }
    }
}

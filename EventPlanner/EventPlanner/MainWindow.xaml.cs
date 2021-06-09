using EventPlanner.Models;
using EventPlanner.Pages;
using EventPlanner.Services;
using EventPlanner.ViewModels;
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

namespace EventPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Services.NavigationService.Singleton().PageChanged += ChangePage;
            Services.NavigationService.Singleton().PageChangedWithModel += ChangePage;
            MainPageFrame.Loaded += MainPageFrame_Loaded;
        }

        private void MainPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            Frame frame = sender as Frame;
            Page page = frame.Content as Page;
            if (currentViewModel == typeof(EventBoardViewModel))
            {
                var vm = page.DataContext as EventBoardViewModel;
                vm.ChangeCurrentEvent(currentModel as Event);
            }
        }

        private void ChangePage(object sender, string pagePath)
        {
            MainPageFrame.Source = new Uri($"pack://application:,,,/{pagePath}");
        }


        private void ChangePage(object sender, dynamic obj)
        {
            string pagePath = obj.page;
            object model = obj.model;
            if (pagePath.Equals("Pages/EventBoardPage.xaml"))
            {
                currentViewModel = typeof(EventBoardViewModel);
                currentModel = model;
            }
            MainPageFrame.Source = new Uri($"pack://application:,,,/{pagePath}");
        }

        private Type currentViewModel;
        private object currentModel;

        private void MainPageFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Forward || e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }
    }
}

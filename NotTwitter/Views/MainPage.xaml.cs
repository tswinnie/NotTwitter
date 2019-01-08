using NotTwitter.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotTwitter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //load home page into frame
            MainContent.Navigate(typeof(Home));
            PageTitle.Text = "Home";
            //hide back button
            BackButton.Visibility = Visibility.Collapsed;
        }
        

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel.IsPaneOpen = !MenuPanel.IsPaneOpen;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainContent.CanGoBack)
            {
                MainContent.GoBack();
            }

        }

        private void BackButton_GettingFocus(UIElement sender, GettingFocusEventArgs args)
        {

        }

        private void BackButton_FocusEngaged(Control sender, FocusEngagedEventArgs args)
        {
            BackButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 46, 204, 113));
        }

        private void BackButton_GettingFocus_1(UIElement sender, GettingFocusEventArgs args)
        {

        }

        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (HomeListItem.IsSelected)
            {
                MainContent.Navigate(typeof(Home));
                PageTitle.Text = "Home";
                BackButton.Visibility = Visibility.Collapsed;

            }
            else if (UserListItem.IsSelected)
            {
                MainContent.Navigate(typeof(Users));
                PageTitle.Text = "Users";
                BackButton.Visibility = Visibility.Visible;

            }
            else if (PhotosListItem.IsSelected)
            {
                MainContent.Navigate(typeof(Photos));
                PageTitle.Text = "Photos";
                BackButton.Visibility = Visibility.Visible;

            }


        }
    }
}

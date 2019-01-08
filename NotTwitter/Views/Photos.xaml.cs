using NotTwitter.Configurations;
using NotTwitter.Models;
using NotTwitter.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NotTwitter.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Photos : Page
    {
        public PhotosPageViewModel ViewModels { get; }

        public Photos()
        {
            ViewModels = ServiceLocator.Current.GetService<PhotosPageViewModel>();
            this.InitializeComponent();
        }

    
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModels.Photos = await ViewModels.LoadPhotosAsync();
        }
    }
}

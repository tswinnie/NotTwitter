using Microsoft.Extensions.DependencyInjection;
using NotTwitter.Services;
using NotTwitter.ViewModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace NotTwitter.Configurations
{
    public class ServiceLocator : IDisposable
    {
        private static IServiceProvider _rootServiceProvider;
        static private readonly ConcurrentDictionary<int, ServiceLocator> _serviceLocators = new ConcurrentDictionary<int, ServiceLocator>();
        static public void Configure(IServiceCollection serviceCollection)
        {

            //register interface and viewmodels
            serviceCollection.AddSingleton<IPostsDataService, PostDataService>();
            serviceCollection.AddTransient<HomePageViewModel>();

            serviceCollection.AddSingleton<IUserDataService, UserDataService>();
            serviceCollection.AddTransient<UsersPageViewModel>();

            serviceCollection.AddSingleton<IPhotoDataService, PhotoDataService>();
            serviceCollection.AddTransient<PhotosPageViewModel>();

            _rootServiceProvider = serviceCollection.BuildServiceProvider();

        }

        static public ServiceLocator Current
        {
            get
            {
                int currentViewID = ApplicationView.GetForCurrentView().Id;
                return _serviceLocators.GetOrAdd(currentViewID, key => new ServiceLocator());
            }
        }

        public T GetService<T>()
        {
            return GetService<T>(true);
        }

        static public void DisposeCurrent()
        {
            int currentViewID = ApplicationView.GetForCurrentView().Id;
            if (_serviceLocators.TryRemove(currentViewID, out ServiceLocator current))
            {
                current.Dispose();
            }
        }

        private IServiceScope _serviceScope = null;
        
        private ServiceLocator()
        {
            _serviceScope = _rootServiceProvider.CreateScope();
        }


        public T GetService<T>(bool isRequired)
        {
            if (isRequired)
            {
                return _serviceScope.ServiceProvider.GetRequiredService<T>();
            }
            return _serviceScope.ServiceProvider.GetService<T>();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_serviceScope != null)
                {
                    _serviceScope.Dispose();
                }
            }
        }

        internal static void Configure(object serviceCollection)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

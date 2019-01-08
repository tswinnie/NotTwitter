using NotTwitter.Models;
using NotTwitter.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTwitter.ViewModels
{
    public class PhotosPageViewModel
    {
        private IPhotoDataService _photoService;
        private ObservableCollection<Photo> _photo;
        public ObservableCollection<Photo> Photos
        {
            get
            {
                return _photo ?? (_photo = new ObservableCollection<Photo>());
            }
            set
            {
                _photo = value;
            }
        }

        public PhotosPageViewModel(IPhotoDataService photoService)
        {
            _photoService = photoService;

        }

        public async Task<ObservableCollection<Photo>> LoadPhotosAsync()
        {
            var myPhotos = await _photoService.GetPhotos();
            //limit photo count to 20
            int counter = 0;
           foreach(var photo in myPhotos)
            {
                if(counter == 20)
                {
                    break;
                }
                Photos.Add(photo);
                counter++;
            }

            return Photos;
        }
    }
}

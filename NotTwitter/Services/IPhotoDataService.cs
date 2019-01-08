using NotTwitter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTwitter.Services
{
    public interface IPhotoDataService
    {
        Task<ObservableCollection<Photo>> GetPhotos();
    }
}

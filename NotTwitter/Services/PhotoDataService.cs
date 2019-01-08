using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using NotTwitter.Models;

namespace NotTwitter.Services
{
    public class PhotoDataService : IPhotoDataService
    {
        private HttpClient http;

        public PhotoDataService()
        {
            http = new HttpClient();
        }

        public async Task<ObservableCollection<Photo>> GetPhotos()
        {
            var response = await http.GetAsync("https://jsonplaceholder.typicode.com/photos");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Photo>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ObservableCollection<Photo>)serializer.ReadObject(ms);
            return data;
        }
    }
}

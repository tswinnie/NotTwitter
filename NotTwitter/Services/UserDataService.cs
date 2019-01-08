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
    public class UserDataService : IUserDataService
    {
        private HttpClient http;

        public UserDataService()
        {
            http = new HttpClient();
        }

        public async Task<ObservableCollection<User>> GetAllUsers()
        {
            var response = await http.GetAsync("https://jsonplaceholder.typicode.com/users");
            var results = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<User>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(results));
            var data = (ObservableCollection<User>)serializer.ReadObject(ms);
            return data;
           
        }

        public async Task<User> GetAUser(int userId)
        {
            var response = await http.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            var results = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(User));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(results));
            var data = (User)serializer.ReadObject(ms);
            return data;

        }
    }
}

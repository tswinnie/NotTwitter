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
    public class PostDataService : IPostsDataService
    {
        private HttpClient _http;

        public PostDataService()
        {
            _http = new HttpClient();

        }

        public async Task<ObservableCollection<Comment>> GetAllCommentsForAllPost()
        {
            var response = await _http.GetAsync("https://jsonplaceholder.typicode.com/comments");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Comment>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ObservableCollection<Comment>)serializer.ReadObject(ms);

            return data;

        }

        public async Task<ObservableCollection<Comment>> GetAllCommentsForAPost(int postId)
        {
            var response = await _http.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Comment>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ObservableCollection<Comment>)serializer.ReadObject(ms);

            return data;
        }

        public async Task<ObservableCollection<Post>> GetAllPostsForUser(int userId)
        {
            var response = await _http.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Post>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ObservableCollection<Post>)serializer.ReadObject(ms);

            return data;
        }

        public async Task<ObservableCollection<Post>> GetPosts()
        {
            var response = await _http.GetAsync("https://jsonplaceholder.typicode.com/posts");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Post>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ObservableCollection<Post>)serializer.ReadObject(ms);

            return data;
        }
    }
}

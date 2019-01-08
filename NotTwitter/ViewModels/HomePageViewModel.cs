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
    public class HomePageViewModel
    {
        //create collection that will hold posts
        private ObservableCollection<Post> _post;
        private IPostsDataService _postService;


        public HomePageViewModel(IPostsDataService postService)
        {
            _postService = postService; 
        }


        public ObservableCollection<Post> Posts
        {
            get
            {
                return  _post ?? (_post = new ObservableCollection<Post>());
            }
            set
            {
                 _post = value;
            }
        }

        public async Task<ObservableCollection<Post>> GetPostsAsync()
        {
            //make call to service to get posts data
            var homePagePosts = await _postService.GetPosts();
         
            //add post to collection
            foreach(var post in homePagePosts)
            {
                Posts.Add(post);

            }
            return Posts;

        }
    }
}

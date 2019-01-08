using NotTwitter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTwitter.Services
{
    public interface IPostsDataService
    {
        Task<ObservableCollection<Post>> GetPosts();
        Task<ObservableCollection<Post>> GetAllPostsForUser(int userId);
        Task<ObservableCollection<Comment>> GetAllCommentsForAllPost();
        Task<ObservableCollection<Comment>> GetAllCommentsForAPost(int postId);
    }
}

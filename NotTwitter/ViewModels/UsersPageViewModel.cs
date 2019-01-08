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
    public class UsersPageViewModel
    {
        private IUserDataService _userService;
        private ObservableCollection<User> _user;
        public ObservableCollection<User> Users
        {
            get
            {
                return _user ?? (_user = new ObservableCollection<User>());
            }
            set
            {
                _user = value;
            }
        }

        public UsersPageViewModel(IUserDataService userService)
        {
            _userService = userService;

        }

        public async Task<ObservableCollection<User>> LoadAllUsersAsync()
        {
            var myUsers = await _userService.GetAllUsers();
            foreach(var user in myUsers)
            {
                Users.Add(user);
            }

            return Users;
        }

        public async Task<ObservableCollection<User>> LoadUserAsync(int userId)
        {
            Users.Clear();
            User myUser = await _userService.GetAUser(userId);
            Users.Add(myUser);
            return Users;
        }
    }
}

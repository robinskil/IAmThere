using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.Models;

namespace IAmThereApi.ViewModels
{
    public class GroupViewModel
    {
        public string GroupName { get; set; }
        public UserViewModel Creator { get; set; }
        public AreaViewModel Area { get; set; }
        public ICollection<UserViewModel> Users { get; set; }
        public GroupViewModel(Group group)
        {
            GroupName = group.GroupName;
            Creator = new UserViewModel()
            {
                LastKnownLocation = group.Creator.LastKnownLocation,
                Email =  group.Creator.Email,
                Firstname = group.Creator.Firstname,
                Lastname = group.Creator.Lastname
            };
            Area = new AreaViewModel()
            {
                Longitude =  group.Area.Longitude,
                Latitude = group.Area.Latitude,
                AreaSize = group.Area.AreaSize
            };
            Users = UserViewModel.UserViewModels(group.Users.Select(u => u.User)).ToList();
        }
    }

    public class UserViewModel
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public LastKnownLocation LastKnownLocation { get; set; }

        public static IEnumerable<UserViewModel> UserViewModels(IEnumerable<User> users)
        {
            if (users == null) yield break;
            foreach (User user in users)
            {
                yield return new UserViewModel()
                {
                    LastKnownLocation = user.LastKnownLocation,
                    Email = user.Email,
                    Lastname = user.Lastname,
                    Firstname = user.Firstname
                };
            }
        }
    }

    public class AreaViewModel
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int AreaSize { get; set; }
    }
}

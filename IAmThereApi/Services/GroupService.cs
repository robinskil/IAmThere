using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Models;
using IAmThereApi.Repository;
using IAmThereApi.RequestModels;
using IAmThereApi.ViewModels;

namespace IAmThereApi.Services
{
    public interface IGroupService
    {
        bool CreateGroup(CreateGroupModel createGroupModel, string email);
        GroupViewModel GetGroup(Guid groupId, Guid accountId);
        ICollection<GroupViewModel> GetGroups(Guid accountId);
    }
    public class GroupService : IGroupService
    {
        private IGroupRepository GroupRepository { get; }
        private IUserRepository UserRepository { get; }
        public GroupService(DataContext dataContext)
        {
            GroupRepository = new GroupRepository(dataContext);
            UserRepository = new UserRepository(dataContext);
        }

        public bool CreateGroup(CreateGroupModel createGroupModel, string email)
        {
            Group group = GroupFromCreateGroupModel(createGroupModel);
            group.CreatorId = UserRepository.GetEntity(u => u.Email == email).UserId;
            GroupRepository.AddEntity(group);
            GroupRepository.SaveChanges();
            return true;
        }

        public GroupViewModel GetGroup(Guid groupId, Guid accountId)
        {
            return new GroupViewModel(GroupRepository.GetGroupInfo(groupId,accountId));
        }

        public ICollection<GroupViewModel> GetGroups(Guid accountId)
        {
            List<GroupViewModel> groupViewModels = new List<GroupViewModel>();
            foreach (Group group in GroupRepository.GetAllGroupsInfo(accountId))
            {
                groupViewModels.Add(new GroupViewModel(group));
            }
            return groupViewModels;
        }

        public ICollection<UserViewModel> GetGroupUsers(Guid groupId, Guid accountId)
        { 
            return new GroupViewModel(GroupRepository.GetGroupInfo(groupId,accountId)).Users;
        }

        private static Group GroupFromCreateGroupModel(CreateGroupModel createGroupModel)
        {
            if (createGroupModel != null)
                return new Group
                {
                    GroupName = createGroupModel.GroupName,
                    Area = new Area
                    {
                        AreaSize = createGroupModel.AreaSize,
                        Latitude = createGroupModel.Latitude,
                        Longitude = createGroupModel.Longitude,
                    }
                };
            throw new ArgumentNullException(nameof(createGroupModel));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Models;
using IAmThereApi.Repository;
using IAmThereApi.RequestModels;

namespace IAmThereApi.Services
{
    public interface IGroupService
    {
        bool CreateGroup(CreateGroupModel createGroupModel, string email);
    }
    public class GroupService
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
            Group group = FromCreateGroupModel(createGroupModel);
            group.CreatorId = UserRepository.GetEntity(u => u.Email == email).UserId;
            GroupRepository.AddEntity(group);
            GroupRepository.SaveChanges();
            return true;
        }

        public static Group FromCreateGroupModel(CreateGroupModel createGroupModel)
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
            throw new ApplicationException("Create group model was null!");
        }
    }
}

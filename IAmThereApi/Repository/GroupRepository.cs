using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IAmThereApi.Repository
{
    interface IGroupRepository : IRepository<Group>
    {
        Group GetGroupInfo(Guid groupId, Guid accountId);
        ICollection<Group> GetAllGroupsInfo(Guid accountId);
    }
    public class GroupRepository : Repository<Group> , IGroupRepository
    {
        public GroupRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Group GetGroupInfo(Guid groupId, Guid accountId)
        {
            return Context.Group
                .Include(u => u.Users).ThenInclude(u => u.User).ThenInclude(u => u.LastKnownLocation)
                .Include(g => g.Creator)
                .Include(g => g.Area)
                .FirstOrDefault(g => g.GroupId == groupId && g.CreatorId == accountId);
        }

        public ICollection<Group> GetAllGroupsInfo(Guid accountId)
        {
            return Context.Group
                .Include(u => u.Users).ThenInclude(u => u.User).ThenInclude(u => u.LastKnownLocation)
                .Include(g => g.Creator)
                .Include(g => g.Area)
                .Where(g => g.CreatorId == accountId)
                .ToList();
        }
    }
}

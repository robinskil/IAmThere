using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Models;

namespace IAmThereApi.Repository
{
    interface IGroupRepository : IRepository<Group>
    {
        
    }
    public class GroupRepository : Repository<Group> , IGroupRepository
    {
        public GroupRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}

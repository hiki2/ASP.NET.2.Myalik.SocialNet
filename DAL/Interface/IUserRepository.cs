using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;

namespace DAL.Interface
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetUserByMobile(string mobile);

        DalUser GetUserByEmail(string email);

        DalUser GetUserByProfileId(int profileId);

        IEnumerable<DalUser> GetUsersByName(string name);

        IEnumerable<DalUser> GetUsersByRoleName(string roleName);

        IEnumerable<DalUser> GetUsersByLastName(string lastName);

        IEnumerable<DalUser> GetUsersByNameAndLastName(string name, string lastName);

        IEnumerable<DalUser> GetTopUsers(int count);

        IEnumerable<DalUser> GetUsersBySearchModel(DalSearch search);
    }
}

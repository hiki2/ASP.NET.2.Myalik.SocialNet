using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using DAL.Interface;
using DAL.Mappers;
using ORM;
using ORM.Models;

namespace DAL.Classes
{
    public class RoleRepository : Repository<DalRole,Role>, IRoleRepository
    {
        private readonly SocialNetDB context;

        public RoleRepository(SocialNetDB uow) : base(uow)
        {
            context = uow;
        }

        public DalRole GetRoleByName(string name)
        {
            var retRole = context.Roles.FirstOrDefault(role => role.Name == name);
            return retRole != null ? Mapper.ToDal(retRole) : null;
        }
    }
}

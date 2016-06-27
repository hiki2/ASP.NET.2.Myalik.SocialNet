using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Services.Interface;
using DAL.DTO.Models;
using DAL.Interface;
using BLL.Mappers;

namespace BLL.Services
{
    public class RoleService : Service<RoleEntity, DalRole>, IRoleService
    {
        private readonly IUnitOfWork uow;
        public RoleService(IUnitOfWork uow) : base(uow, uow.Roles)
        {
            this.uow = uow;
        }

        public RoleEntity GetRoleEntityByName(string name)
        {            
            var role = uow.Roles.GetRoleByName(name);
            return role != null ? Mapper.ToBll(role) : null;
        }
    }
}

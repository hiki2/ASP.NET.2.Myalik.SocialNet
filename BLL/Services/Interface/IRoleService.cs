using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services.Interface
{
    public interface IRoleService : IService<RoleEntity>
    {
        RoleEntity GetRoleEntityByName(string name);
    }
}

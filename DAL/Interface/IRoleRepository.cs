using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;

namespace DAL.Interface
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetRoleByName(string name);
   
    }
}

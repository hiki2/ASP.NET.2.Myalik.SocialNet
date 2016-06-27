using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services.Interface
{
    public interface IProfileService : IService<ProfileEntity>
    {
        IEnumerable<ProfileEntity> GetProfileEntitiesByBirthDate(DateTime birthDate);

        IEnumerable<ProfileEntity> GetProfileEntitiesByCountry(string countryName);

        IEnumerable<ProfileEntity> GetProfileEntitiesBySearchModel(SearchEntity search);

        IEnumerable<ProfileEntity> GetProfileEntitiesBySex(bool sex);
        
        ProfileEntity GetProfileEntityByUserEmail(string email);

        ProfileEntity GetProfileEntityByUserMobile(string mobile);

        ProfileEntity GetProfileEntityByUserId(int userId);
     
    }
}

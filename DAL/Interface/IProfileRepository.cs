using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;

namespace DAL.Interface
{
    public interface IProfileRepository : IRepository<DalProfile>
    {
        IEnumerable<DalProfile> GetProfilesByBirthDate(DateTime birthDate);

        IEnumerable<DalProfile> GetProfilesByCountry(string countryName);

        IEnumerable<DalProfile> GetProfilesBySex(bool sex);

        DalProfile GetProfileByUserEmail(string email);

        DalProfile GetProfileByUserMobile(string mobile);

        DalProfile GetProfileByUserId(int userId);

        IEnumerable<DalProfile> GetProfilesBySearchModel(DalSearch search);

    }
}

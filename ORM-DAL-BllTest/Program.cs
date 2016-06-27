using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.DTO.Models;
using ORM;
using BLL;
using BLL.Services;

namespace ORM_DAL_BllTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var uow = new UnitOfWork(new SocialNetDB());
            var k = 0;
            for (var i = 8; i <= 13; i++)
            {
                k++;
                for (var j = 8 + k; j <= 13; j++)
                {
                    if (i == j) continue;
                    uow.Friends.Create(new DalFriend()
                    {
                        ConfirmDate = DateTime.Now,
                        Confirmed = true,
                        FriendId = j,
                        UserId = i,
                        RequestDate = DateTime.Now,
                    });   
                }
            }   
            Console.ReadKey();  
              
        }
    }
}

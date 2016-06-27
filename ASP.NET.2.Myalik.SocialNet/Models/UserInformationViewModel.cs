using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class UserInformationViewModel
    {
        public int UserId { get; set; }

        
        public string Name { get; set; }

        public string LastName { get; set; }

     
        public string Mobile { get; set; }

        
        public string Email { get; set; }

 
        public RoleViewModel Role { get; set; }
    }
}
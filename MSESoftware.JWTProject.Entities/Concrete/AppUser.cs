using MSESoftware.JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSESoftware.JWTProject.Entities.Concrete
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}

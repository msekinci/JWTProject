using MSESoftware.JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSESoftware.JWTProject.Entities.Concrete
{
    public class AppUserRole : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }
        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}

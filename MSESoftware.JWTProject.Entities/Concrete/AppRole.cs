using MSESoftware.JWTProject.Entities.Interfaces;
using System.Collections.Generic;

namespace MSESoftware.JWTProject.Entities.Concrete
{
    public class AppRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}

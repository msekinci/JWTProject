using MSESoftware.JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSESoftware.JWTProject.Business.Interfaces
{
    public interface IJWTService
    {
        public string GenerateJWT(AppUser appUser, List<AppRole> roles);
    }
}

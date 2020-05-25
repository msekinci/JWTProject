using MSESoftware.JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs
{
    public class AppUserListDTO : IDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}

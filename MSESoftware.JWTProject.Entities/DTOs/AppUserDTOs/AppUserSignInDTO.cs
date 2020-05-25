using MSESoftware.JWTProject.Entities.Interfaces;

namespace MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs
{
    public class AppUserSignInDTO : IDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

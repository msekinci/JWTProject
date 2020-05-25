using MSESoftware.JWTProject.Entities.Interfaces;

namespace MSESoftware.JWTProject.Entities.Token
{
    public class JWTAccessToken : IToken
    {
        public string Token { get; set; }
    }
}

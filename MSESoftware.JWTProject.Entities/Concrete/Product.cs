using MSESoftware.JWTProject.Entities.Interfaces;

namespace MSESoftware.JWTProject.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

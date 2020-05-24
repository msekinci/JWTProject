using MSESoftware.JWTProject.Entities.Interfaces;

namespace MSESoftware.JWTProject.Entities.DTOs.ProductDTOs
{
    public class ProductUpdateDTO : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

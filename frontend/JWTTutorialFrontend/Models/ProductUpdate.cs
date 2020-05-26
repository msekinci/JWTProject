using System.ComponentModel.DataAnnotations;

namespace JWTTutorialFrontend.Models{
    public class ProductUpdate{
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
    }
}
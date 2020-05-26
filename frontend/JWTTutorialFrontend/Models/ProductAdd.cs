using System.ComponentModel.DataAnnotations;

namespace JWTTutorialFrontend.Models
{
    public class ProductAdd
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
    }
}
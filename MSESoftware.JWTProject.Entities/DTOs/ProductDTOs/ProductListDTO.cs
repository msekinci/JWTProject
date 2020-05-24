using MSESoftware.JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSESoftware.JWTProject.Entities.DTOs.ProductDTOs
{
    public class ProductListDTO : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

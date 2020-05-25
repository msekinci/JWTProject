using AutoMapper;
using MSESoftware.JWTProject.Entities.Concrete;
using MSESoftware.JWTProject.Entities.DTOs.ProductDTOs;

namespace MSESoftware.JWTProject.WebAPI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Product Mapping
            CreateMap<ProductAddDTO, Product>();
            CreateMap<Product, ProductAddDTO>();

            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductUpdateDTO>();

            CreateMap<ProductListDTO, Product>();
            CreateMap<Product, ProductListDTO>();
            #endregion
        }
    }
}

using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {

        }
    }
}

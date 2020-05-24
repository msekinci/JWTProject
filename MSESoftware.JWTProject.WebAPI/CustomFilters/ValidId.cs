using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Entities.Interfaces;
using System.Linq;

namespace MSESoftware.JWTProject.WebAPI.CustomFilters
{
    // IActionFilter'dan kalıtmamızın sebebi ActionFilter class'ının bit generic TEntity class'ı kabul etmemesi
    public class ValidId<T> : IActionFilter where T : class, IEntity, new()  
    {
        private readonly IGenericService<T> _genericService;

        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(x => x.Key == "id").FirstOrDefault();
            var checkedId = (int)dictionary.Value;
            var entity = _genericService.GetByIdAsync(checkedId).Result;

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"Not Found Object with ID:{checkedId}");
            }
        }
    }
}

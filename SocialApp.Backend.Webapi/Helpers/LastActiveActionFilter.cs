using Microsoft.AspNetCore.Mvc.Filters;
using SocialApp.Backend.Webapi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Helpers
{
    public class LastActiveActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var id = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var repository =(ISocialRepository)resultContext.HttpContext.RequestServices.GetService(typeof(ISocialRepository));

            var user = await repository.GetUser(id);
            user.LastActive = DateTime.Now;
            await repository.SaveChanges();
        }
    }
}

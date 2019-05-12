using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using TempApi.Models.Db;

namespace TempApi.Controllers
{
    public class BaseController : ApiController
    {
        protected costmanagerdbEntities InitializeDbContext()
        {
            return new costmanagerdbEntities();
        }

        protected int GetUserDbId()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id = identity.Claims.Where(c => c.Type == Consts.useDbId).Select(c => c.Value).SingleOrDefault();
            return Convert.ToInt32(id);
        }

    }
}
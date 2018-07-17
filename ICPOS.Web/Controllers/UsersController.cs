using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICPOS.Web.Common;
using ICPOS.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICPOS.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private EFDbContext DBContext;
        public UsersController(EFDbContext context)
        {
            DBContext = context;
        }

        [HttpGet,Route("getall")]
        public IList<Users> GetAll()
        {
            var list = DBContext.Users.Take(10).ToList();
            return list;
        }

    }
}
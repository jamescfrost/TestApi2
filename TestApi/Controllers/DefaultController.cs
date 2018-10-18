using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class DefaultController : ApiController
    {

        IStringFormatter _formatter;

        public DefaultController(IStringFormatter formatter)
        {
            _formatter = formatter;
        }

        public IHttpActionResult Get()
        {
            return Ok(_formatter.Format("Hello"));
        }
    }
}

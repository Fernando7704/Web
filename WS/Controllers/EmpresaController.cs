using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WS.Controllers
{
    public class EmpresaController : ApiController
    {
        // GET: api/Empresa
        [Route("api/Empresa")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BusnessLayer.Empresa.GetAll();
            if (result.result)
            {
                return Ok(result);
            }else
            {
                return NotFound();
            }
        }

        // GET: api/Empresa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empresa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empresa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empresa/5
        public void Delete(int id)
        {
        }
    }
}

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
        [Route("api/Empresa/{IdDepartamento}")]
        [HttpGet]
        public IHttpActionResult Get(int IdDepartamento)
        {
            ML.Result result = BusnessLayer.Empresa.GetById(IdDepartamento);
            return Ok(result);
        }

        // POST: api/Empresa
        [Route("api/Empresa")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ML.Empresa empresa)
        {
            ML.Result result = BusnessLayer.Empresa.Agregar(empresa);
            return Ok(result);
        }

        // PUT: api/Empresa/5
        [Route("api/Empresa/{IdEmpresa}")]
        [HttpPut]
        public IHttpActionResult Put(int IdEmpresa, [FromBody]ML.Empresa empresa)
        {
            empresa.IdEmpresa = IdEmpresa;
            ML.Result result = BusnessLayer.Empresa.Actualizar(empresa);
            return Ok(result);
        }

        // DELETE: api/Empresa/5
        [Route("api/Empresa/{IdDepartamento}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdDepartamento)
        {
            ML.Result result = BusnessLayer.Empresa.Delete(IdDepartamento);
            return Ok(result);
        }
    }
}

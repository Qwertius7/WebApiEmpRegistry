using System;
using System.Data.Entity.Core;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;

namespace WebApiEmpRegistry.Controllers
{
    [RoutePrefix("api/emp")]
    public class EmpController : ApiController
    {
        private readonly IEmployeeService _empService;

        public EmpController() {}

        public EmpController(IEmployeeService empService)
        {
            _empService = empService;
        }

        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await _empService.GetAllEmployees());
        }

        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _empService.GetEmployeeById(id));
            }
            catch (ObjectNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Create(EmployeeDto emp)
        {
            Guid newId = Guid.NewGuid();
            emp.Id = newId;
            return Request.CreateResponse(HttpStatusCode.OK, await _empService.CreateEmployee(emp));
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> Update(EmployeeDto emp)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _empService.UpdateEmployee(emp));
            }
            catch (InvalidDataException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                return Request.CreateResponse(await _empService.DeleteEmployeeById(id));
            }
            catch (ObjectNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}

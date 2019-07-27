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
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _empService.GetAllEmployees());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid parameter");
            try
            {
                var resultEmployee = await _empService.GetEmployeeById(id);
                return resultEmployee != null 
                    ? Request.CreateResponse(HttpStatusCode.OK, resultEmployee)
                    : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Employee is absent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Create(EmployeeDto emp)
        {
            if (emp == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Employee parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, await _empService.CreateEmployee(emp));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> Update(EmployeeDto emp)
        {
            if (emp == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Employee parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                var updatedEmployee = await _empService.UpdateEmployee(emp);
                return updatedEmployee != null 
                    ? Request.CreateResponse(HttpStatusCode.OK, updatedEmployee)
                    : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Employee is absent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid parameter");
            try
            {
                var deletedEmployee = await _empService.DeleteEmployeeById(id);
                return deletedEmployee != null 
                    ? Request.CreateResponse(HttpStatusCode.OK, deletedEmployee)
                    : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Employee is absent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

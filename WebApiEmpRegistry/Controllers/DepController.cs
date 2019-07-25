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
    [RoutePrefix("api/dep")]
    public class DepController : ApiController
    {
        private IDepartmentService _depService;

        public DepController() {}

        public DepController(IDepartmentService depService)
        {
            _depService = depService;
        }
        
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _depService.GetAllDepartments());
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
                var resultDepartment = await _depService.GetDepartmentById(id);
                return resultDepartment != null 
                    ? Request.CreateResponse(HttpStatusCode.OK, resultDepartment)
                    : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Department is absent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Create(DepartmentDto dep)
        {
            if (dep == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Department parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                dep.Id = Guid.NewGuid();
                return Request.CreateResponse(HttpStatusCode.Created, await _depService.CreateDepartment(dep));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> Update(DepartmentDto dep)
        {
            if (dep == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Department parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                var updatedDepartment = await _depService.UpdateDepartment(dep);
                return updatedDepartment != null 
                    ? Request.CreateResponse(HttpStatusCode.OK, updatedDepartment)
                    : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Department is absent");
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
                var deletedDepartment = await _depService.DeleteDepartmentById(id);
                return deletedDepartment != null 
                    ? Request.CreateResponse(HttpStatusCode.OK, deletedDepartment)
                    : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Department is absent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
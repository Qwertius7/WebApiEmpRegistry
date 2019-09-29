using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;
using ApplicationLayer.validators;
using WebApiEmpRegistry.exceptionHandlers;

namespace WebApiEmpRegistry.Controllers
{
    [RoutePrefix("api/dep")]
    public class DepController : ApiController
    {
        private IDepartmentService _depService;
        private DepartmentValidator _depValidator;

        public DepController() {}

        public DepController(IDepartmentService depService, DepartmentValidator depValidator)
        {
            _depService = depService;
            _depValidator = depValidator;
        }

        [Route("")]
        [InternalServerErrorFilter]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await _depService.GetAllDepartments());
        }
        
        [Route("{id}")]
        [InternalServerErrorFilter]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid parameter");
            var resultDepartment = await _depService.GetDepartmentById(id);
            return resultDepartment != null 
                ? Request.CreateResponse(HttpStatusCode.OK, resultDepartment)
                : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Department is absent");
        }

        [HttpPost]
        [Route("")]
        [InternalServerErrorFilter]
        public async Task<HttpResponseMessage> Create(DepartmentDto dep)
        {
            if (dep == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Department parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            return Request.CreateResponse(HttpStatusCode.Created, await _depService.CreateDepartment(dep));
        }

        [HttpPut]
        [Route("")]
        [InternalServerErrorFilter]
        public async Task<HttpResponseMessage> Update(DepartmentDto dep)
        {
            if (dep == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Department parameter");
            var validationResults = _depValidator.Validate(dep);
            if (!validationResults.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, validationResults);
            }
            var updatedDepartment = await _depService.UpdateDepartment(dep);
            return updatedDepartment != null 
                ? Request.CreateResponse(HttpStatusCode.OK, updatedDepartment)
                : Request.CreateResponse(HttpStatusCode.NotFound, "Selected Department is absent");
        }

        [HttpDelete]
        [Route("{id}")]
        [InternalServerErrorFilter]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid parameter");
            await _depService.DeleteDepartmentById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
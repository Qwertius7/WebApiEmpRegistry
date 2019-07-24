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
            return Request.CreateResponse(HttpStatusCode.OK, await _depService.GetAllDepartments());
        }
        
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _depService.GetDepartmentById(id));
            }
            catch (ObjectNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Create(DepartmentDto dep)
        {
            var newId = Guid.NewGuid();
            dep.Id = newId;
            return Request.CreateResponse(HttpStatusCode.OK, await _depService.CreateDepartment(dep));
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> Update(DepartmentDto dep)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _depService.UpdateDepartment(dep));
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
                return Request.CreateResponse(await _depService.DeleteDepartmentById(id));
            }
            catch (ObjectNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
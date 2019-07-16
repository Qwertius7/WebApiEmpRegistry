using System;
using System.Data.Entity.Core;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Repository.dto;
using Repository.interfaces;

namespace WebApiEmpRegistry.Controllers
{
    [RoutePrefix("api/dep")]
    public class DepController : ApiController
    {
        private readonly IGenericRepository _repo;

        public DepController() {}

        public DepController(IGenericRepository repo)
        {
            _repo = repo;
        }
        
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAllDepartments());
        }
        
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repo.GetDepartmentById(id));
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
            Guid newId = Guid.NewGuid();
            dep.Id = newId;
            return Request.CreateResponse(HttpStatusCode.OK, _repo.CreateDepartment(dep));
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> Update(DepartmentDto dep)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repo.UpdateDepartment(dep));
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
                return Request.CreateResponse(_repo.DeleteDepartmentById(id));
            }
            catch (ObjectNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
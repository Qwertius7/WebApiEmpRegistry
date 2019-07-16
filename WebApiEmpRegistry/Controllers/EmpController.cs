using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/emp")]
    public class EmpController : ApiController
    {
        private readonly IGenericRepository _repo;

        public EmpController() {}

        public EmpController(IGenericRepository repo)
        {
            _repo = repo;
        }

        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAllEmployees());
        }

        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repo.GetEmployeeById(id));
            }
            catch (ObjectNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        
        [HttpGet]
        [Route("full")]
        public async Task<HttpResponseMessage> GetAllExtra()
        {
            var result = new List<EmployeeGetModel>();
            foreach (var employee in _repo.GetAllEmployees())
            {
                var getModel = new EmployeeGetModel(employee)
                {
                    Department = employee.DepartmentId == Guid.Empty ? null
                        : _repo.GetDepartmentById(employee.DepartmentId)
                };
                result.Add(getModel);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        [HttpGet]
        [Route("{id}/full")]
        public async Task<HttpResponseMessage> GetExtra(Guid id)
        {
            try
            {
                var employee = _repo.GetEmployeeById(id);
                var getModel = new EmployeeGetModel(employee)
                {
                    Department = employee.DepartmentId == Guid.Empty ? null
                        : _repo.GetDepartmentById(employee.DepartmentId)
                };
                return Request.CreateResponse(HttpStatusCode.OK, getModel);
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
            return Request.CreateResponse(HttpStatusCode.OK, _repo.CreateEmployee(emp));
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> Update(EmployeeDto emp)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repo.UpdateEmployee(emp));
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

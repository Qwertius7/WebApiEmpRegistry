using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;

namespace WebApiEmpRegistry.Controllers
{
    [RoutePrefix("api/proj")]
    public class ProjController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjController() {}

        public ProjController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [Route("roles")]
        public async Task<HttpResponseMessage> GetRoles()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _projectService.GetAllProjectRoles());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [Route("teams")]
        public async Task<HttpResponseMessage> GetTeams()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _projectService.GetAllProjectTeams());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [Route("members")]
        public async Task<HttpResponseMessage> GetTeamParticipants()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _projectService.GetAllProjectMembers());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        [Route("roles")]
        public async Task<HttpResponseMessage> CreateProjectRole(ProjectRoleDto role)
        {
            if (role == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Project role parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, await _projectService.CreateProjectRole(role));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        [Route("teams")]
        public async Task<HttpResponseMessage> CreateProjectTeam(ProjectTeamDto team)
        {
            if (team == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Project team parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, await _projectService.CreateProjectTeam(team));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        [Route("members")]
        public async Task<HttpResponseMessage> CreateProjectMember(ProjectMemberDto mem)
        {
            if (mem == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input Project member parameter");
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, await _projectService.CreateProjectMember(mem));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
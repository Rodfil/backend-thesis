using Egorventment.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thesis.Business.Logic;
using Thesis.DTO.RequirementDTO;
using Thesis.Models;

namespace Thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly RequirementsLogic _logic;

        public RequirementsController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _logic = new RequirementsLogic(_dbContext);
        }   

        [HttpPost]
        public async Task<ActionResult<Requirements>> PostRequirements(RequirementsPutPostDTO requirementsPutPostDTO, Guid documentId)
        {
       
            var addRequirements = await _logic.CreateRequirements(requirementsPutPostDTO, documentId);
            return Ok(addRequirements);
        }
    }
}

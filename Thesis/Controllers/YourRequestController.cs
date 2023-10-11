using Egorventment.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thesis.Business.Logic;
using Thesis.DTO.YourRequestDTO;
using Thesis.Models;

namespace Thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YourRequestController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly YourRequestLogic _logic;


        public YourRequestController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _logic = new YourRequestLogic(dbContext);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<YourRequestDTO>>> GetDocumentRequest(Guid userId)
        {
            return Ok(await _logic.GetRequest(userId));
        }


        [HttpPost]
        public async Task<ActionResult> RequestDocument(YourRequestPutPostDTO yourRequestPutPostDTO)
        {
            var requestDocument = await _logic.RequestDocument(yourRequestPutPostDTO);
            return requestDocument ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRequestedDocument(YourRequestPutPostDTO yourRequestPutPostDTO, Guid id)
        {
            var updateRequest = await _logic.UpdateRequestedDocument(yourRequestPutPostDTO, id);
            return updateRequest ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteRequestedDocument(Guid id)
        {
            var deleteRequest = await _logic.DeleteRequest(id);
            return deleteRequest ? Ok() : NotFound();
        }

        [HttpPut("Update/{userId}")]

        public async Task<ActionResult> UpdateDocumentStatus(Guid userId)
        {
            var request = await _logic.UpdateDocumentStatus(userId);
            return Ok(request);
        }

    }
}

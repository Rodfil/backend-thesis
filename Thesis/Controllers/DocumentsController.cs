using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkanLogPH_API.API.DataAccess;
using Thesis.Business.Logic;
using Thesis.DTO.DocumentsDTO;
using Thesis.Models;

namespace Thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly DocumentsLogic _logic;

        public DocumentsController (MyDbContext context)
        {
            _dbContext = context;
            _logic = new DocumentsLogic(_dbContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentsDTO>>> GetDocuments()
        {
            return Ok(await _logic.GetDocuments());
        }

        [HttpPost]
        public async Task<ActionResult<Documents>> CreateDocuments(DocumentsPutPostDTO documentsPutPostDTO)
        {
            var createDocuments = await _logic.CreateDocuments(documentsPutPostDTO);
            return Ok(createDocuments);
        }

        [HttpPut("{documentId}")]

        public async Task<ActionResult> UpdateDocuments (DocumentsPutPostDTO documentsDTO, Guid documentId)
        {
            var updateDocuments = await _logic.UpdateDocuments(documentsDTO, documentId);
            return updateDocuments ? Ok() : NotFound();
        }

        [HttpDelete("{documentId}")]
        public async Task<ActionResult> DeleteDocuments (Guid documentId)
        {
            var deleteDocuments = await _logic.DeleteDocuments(documentId);
            return deleteDocuments ? Ok() : NotFound();
        }

    }
}

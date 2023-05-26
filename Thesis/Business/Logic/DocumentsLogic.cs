using Microsoft.EntityFrameworkCore;
using SkanLogPH_API.API.DataAccess;
using System.Reflection.Metadata;
using Thesis.DTO.DocumentsDTO;
using Thesis.Models;

namespace Thesis.Business.Logic
{
    public class DocumentsLogic
    {
        private readonly MyDbContext _dbContext;

        public DocumentsLogic (MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DocumentsDTO>> GetDocuments()
        { 
            var listOfDocuments = await _dbContext.Documents
                .Select(x => Mappers.DocumentsMappers.Map(x))
                .ToListAsync(); 
            return listOfDocuments;
        }

        public async Task <Documents> CreateDocuments (DocumentsPutPostDTO documentsPutPostDTO)
        {
            var newDocuments = Mappers.DocumentsMappers.Map(documentsPutPostDTO);

            await _dbContext.AddAsync(newDocuments);
            await _dbContext.SaveChangesAsync();
            return newDocuments;
        } 

        public async Task<bool> UpdateDocuments (DocumentsPutPostDTO documentsDTO, Guid documentId)
        {
            var documentsMain = _dbContext.Documents.FirstOrDefault(x => x.DocumentId == documentId);

            if (documentsMain == null)
            {
                throw new Exception($"ID: {documentId} not Found");
            }
            Mappers.DocumentsMappers.Map(documentsDTO, documentsMain);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocuments (Guid documentId)
        {
            var documentsMain = await _dbContext.Documents.FirstOrDefaultAsync(x => x.DocumentId == documentId);

            if(documentsMain == null)
            {
                throw new Exception($"ID: {documentId} not Found");
            }

            _dbContext.Documents.Remove(documentsMain);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

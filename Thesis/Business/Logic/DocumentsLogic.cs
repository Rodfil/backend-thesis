using Egorventment.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;
using Thesis.Business.Mappers;
using Thesis.DTO.DocumentsDTO;
using Thesis.DTO.PurposeDTO;
using Thesis.Models;

namespace Thesis.Business.Logic
{
    public class DocumentsLogic
    {
        private readonly MyDbContext _dbContext;

        public DocumentsLogic(MyDbContext dbContext)
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


        public async Task<List<PurposeDescriptionDTO>> GetDocumentWithPurpose(Guid documentId)
        {
            var listOfPurpose = await _dbContext.PurposeDescription
                                .Where(item => item.DocumentId == documentId)
                                .Select(x => Mappers.DocumentsMappers.Map(x))
                                .ToListAsync();

            return listOfPurpose;
        }
        public async Task<bool> PostDocumentsPurpose(DocumentsPurposePutPost documentsPutPostDTO)
        {

            var addPurpose = Mappers.DocumentsMappers.Map(documentsPutPostDTO);

            await _dbContext.PurposeDescription.AddRangeAsync(addPurpose);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> UpdateSpecificPurpose (PurposePutPost purposePutPost, Guid id)
        {
            var updatePurpose = await _dbContext.PurposeDescription.Where(x => x.Id == id).ToListAsync();

            if(updatePurpose.Any())
            {
               foreach(var purposeDescription in updatePurpose)
                {
                    Mappers.DocumentsMappers.Map(purposePutPost, purposeDescription);
                }
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeletePurpose(Guid id)
        {
            var specificPurpose = await _dbContext.PurposeDescription.Where(x => x.Id == id).ToListAsync();

            if(specificPurpose.Any())
            {
                _dbContext.RemoveRange(specificPurpose);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}

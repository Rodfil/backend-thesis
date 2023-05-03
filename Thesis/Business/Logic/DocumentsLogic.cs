using Microsoft.EntityFrameworkCore;
using SkanLogPH_API.API.DataAccess;
using System.Reflection.Metadata;
using Thesis.DTO.DocumentsDTO;
using Thesis.Models;

namespace Thesis.Business.Logic
{
    public class DocumentsLogic
    {
        private readonly MyDbContext _context;

        public DocumentsLogic (MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentsDTO>> GetDocuments()
        {
            var listOfDocuments = await _context.Documents
                .Select(x => Mappers.DocumentsMappers.Map(x))
                .ToListAsync();
           
            return listOfDocuments;
        }

        public async Task <Documents> CreateDocuments (DocumentsDTO documentsDTO)
        {
            var newDocuments = Mappers.DocumentsMappers.Map(documentsDTO);
            newDocuments.IsVoter = true;
            newDocuments.NonVoter = true;
            await _context.AddAsync(newDocuments);
            await _context.SaveChangesAsync();

            return newDocuments;
        } 

        public async Task<bool> UpdateDocuments (DocumentsPutPostDTO documentsDTO, Guid documentId)
        {
            var documentsMain = _context.Documents.FirstOrDefault(x => x.DocumentId == documentId);

            if (documentsMain == null)
            {
                throw new Exception($"ID: {documentId} not Found");
            }
            Mappers.DocumentsMappers.Map(documentsDTO, documentsMain);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocuments (Guid documentId)
        {
            var documentsMain = await _context.Documents.FirstOrDefaultAsync(x => x.DocumentId == documentId);

            if(documentsMain == null)
            {
                throw new Exception($"ID: {documentId} not Found");
            }

             _context.Documents.Remove(documentsMain);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

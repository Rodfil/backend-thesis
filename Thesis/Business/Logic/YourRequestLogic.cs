using Egorventment.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using Thesis.DTO.YourRequestDTO;
using Thesis.Migrations;
using Thesis.Models;

namespace Thesis.Business.Logic
{
    public class YourRequestLogic
    {
        private readonly MyDbContext _dbContext;

        public YourRequestLogic(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<YourRequestDTO>> GetRequest(Guid userId)
        {
            var myRequest = await _dbContext.YourRequests
                                 .Where(x => x.UserId == userId)
                                 .Join(
                                      _dbContext.Documents,
                                      yourRequest => yourRequest.DocumentId,
                                      document => document.DocumentId,
                                      (yourRequest, document) => new { YourRequest = yourRequest, Document = document }
                                  )
                                 .Select(x => Mappers.YourRequestMappers.Map(x.YourRequest, x.Document.DocumentName))
                                 .ToListAsync();

            return myRequest;
        }


        public async Task<bool> RequestDocument(YourRequestPutPostDTO yourRequestPutPostDTO)
        {
            var requestDocument = Mappers.YourRequestMappers.Map(yourRequestPutPostDTO);

            await _dbContext.YourRequests.AddAsync(requestDocument);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateRequestedDocument(YourRequestPutPostDTO yourRequestPutPostDTO, Guid id)
        {
            var updateDocument = _dbContext.YourRequests.FirstOrDefault(x => x.Id == id);

            if(updateDocument == null)
            {
                return false;
            }

            Mappers.YourRequestMappers.Map(yourRequestPutPostDTO, updateDocument);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteRequest(Guid id)
        {
            var deleteRequest = _dbContext.YourRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteRequest== null)
            {
                return false;
            }

            _dbContext.Remove(deleteRequest);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<YourRequest> UpdateDocumentStatus(Guid userId)
        {
            var updateStatus = _dbContext.YourRequests.FirstOrDefault(x => x.UserId == userId);

            if (updateStatus != null)
            {
                updateStatus.DocumentStatus += 1;

                await _dbContext.SaveChangesAsync();

                return updateStatus;
            }

            return null;
        }
    }
}

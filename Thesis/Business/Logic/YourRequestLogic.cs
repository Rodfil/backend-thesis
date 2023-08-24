using Egorventment.DataAccess;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using Thesis.DTO.YourRequestDTO;

namespace Thesis.Business.Logic
{
    public class YourRequestLogic
    {
        private readonly MyDbContext _dbContext;

        public YourRequestLogic(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<List<YourRequestDTO>> GetRequest(Guid userId)
        //{
        //    var myRequest = await _dbContext.YourRequests
        //        .Where(x => x.UserId == userId).To

        //}
    }
}

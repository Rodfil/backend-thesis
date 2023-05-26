using Microsoft.EntityFrameworkCore;
using SkanLogPH_API.API.DataAccess;
using Thesis.DTO.RequirementDTO;
using Thesis.Models;

namespace Thesis.Business.Logic
{
    public class RequirementsLogic
    {
        private readonly MyDbContext _dbContext;
        
        public RequirementsLogic(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RequirementsDTO>> GetRequirements(Guid documentId)
        {
            var listOfRequirements = new List<RequirementsDTO>();
            var checkRequirementsMain = await _dbContext.Requirements.Where(x => x.DocumentId == documentId).ToListAsync();

            foreach (var rquirements in checkRequirementsMain)
            {
                var requirementsDTO = Mappers.RequirementMappers.Map(rquirements);
                listOfRequirements.Add(requirementsDTO);    
            }

            return listOfRequirements;
        }
        public async Task<Requirements> CreateRequirements(RequirementsPutPostDTO requirementsPutPostDTO, Guid documentId)
        {
            var newRequirements = Mappers.RequirementMappers.Map(requirementsPutPostDTO);
            newRequirements.DocumentId = documentId;
            await _dbContext.AddAsync(newRequirements);
            await _dbContext.SaveChangesAsync();
            return newRequirements;
        }
    }
}

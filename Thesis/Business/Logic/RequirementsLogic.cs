using Egorventment.DataAccess;
using Microsoft.EntityFrameworkCore;
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

            foreach (var requirements in checkRequirementsMain)
            {
                var requirementsDTO = Mappers.RequirementMappers.Map(requirements);
                listOfRequirements.Add(requirementsDTO);    
            }

            return listOfRequirements;
        }
        public async Task<Requirements> CreateRequirements(RequirementsPutPostDTO requirementsPutPostDTO, Guid documentId)
        {
            var newRequirements = Mappers.RequirementMappers.Map(requirementsPutPostDTO);
            await _dbContext.AddAsync(newRequirements);
            await _dbContext.SaveChangesAsync();
            return newRequirements;
        }
    }
}

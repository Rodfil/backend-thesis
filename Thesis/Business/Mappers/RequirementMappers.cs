using System.Reflection.Metadata;
using Thesis.DTO.RequirementDTO;
using Thesis.Models;

namespace Thesis.Business.Mappers
{
    public class RequirementMappers
    {
        public static Requirements Map(RequirementsDTO requirementsDTO )
        {
            var requirementsMain = new Requirements
            {
                RequirementId = Guid.NewGuid(),
                DocumentId = requirementsDTO.DocumentId,
                Description = requirementsDTO.Description
            };

            return requirementsMain;
        }

        public static RequirementsDTO Map(Requirements requirements)
        {
            var requirementsDTO = new RequirementsDTO
            {
                RequirementId = Guid.NewGuid(),
                DocumentId = requirements.DocumentId,
                Description = requirements.Description
            };  

            return requirementsDTO;
        }

        public static Requirements Map(RequirementsPutPostDTO requirementsPutPostDTO)
        {
            var requirementsMain = new Requirements
            {
                RequirementId = Guid.NewGuid(),
                DocumentId = requirementsPutPostDTO.DocumentId,
                Description = requirementsPutPostDTO.Description
                
            };

            return requirementsMain;
        }
        public static Requirements Map(RequirementsPutPostDTO requirementsPutPostDTO, Requirements requirements)
        {
            requirements.DocumentId = requirementsPutPostDTO.DocumentId;
            requirements.RequirementId = requirementsPutPostDTO.RequirementId;  
            requirements.Description = requirementsPutPostDTO.Description;

            return requirements;
        }
    }
}

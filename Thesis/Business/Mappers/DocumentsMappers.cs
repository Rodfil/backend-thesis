using Thesis.DTO.DocumentsDTO;
using Thesis.DTO.PurposeDTO;
using Thesis.Models;

namespace Thesis.Business.Mappers
{
    public class DocumentsMappers
    {
        //GetData from the database
        public static Documents Map (DocumentsDTO documentsDTO)
        {
            var documentsMain = new Documents
            {
               DocumentId = Guid.NewGuid(),
               DocumentName = documentsDTO.DocumentName,
               Price= documentsDTO.Price,
               IsVoter = documentsDTO.IsVoter,
               NonVoter = documentsDTO.NonVoter,

            };

            return documentsMain;
        }

        //GetData from the DTO
        public static DocumentsDTO Map(Documents documentsMain)
        {
            var doumentsDTO = new DocumentsDTO
            {
                DocumentId = documentsMain.DocumentId,
                DocumentName = documentsMain.DocumentName,
                Price = documentsMain.Price,
                IsVoter = documentsMain.IsVoter,
                NonVoter = documentsMain.NonVoter,
            };

            return doumentsDTO;
        }

        //Post Data
        public static Documents Map (DocumentsPutPostDTO documentsDTO)
        {
            var documentsMain = new Documents
            {
                DocumentId = Guid.NewGuid(),
                DocumentName = documentsDTO.DocumentName,   
                Price = documentsDTO.Price,
                IsVoter = documentsDTO.IsVoter,
                NonVoter = documentsDTO.NonVoter
            };

            return documentsMain;
        }

        //UpdateData
        public static Documents Map(DocumentsPutPostDTO documentsDTO, Documents documentsMain)
        {
            documentsMain.DocumentName = documentsDTO.DocumentName;
            documentsMain.Price = documentsDTO.Price;
            documentsMain.IsVoter = documentsDTO.IsVoter;
            documentsMain.NonVoter = documentsDTO.NonVoter;

            return documentsMain;
        }

        public static PurposeDescription Map(PurposeDescriptionDTO purposeDescriptionDTO)
        {
            var purposeMain = new PurposeDescription
            {
                Id = Guid.NewGuid(),
                DocumentId = purposeDescriptionDTO.DocumentId,
                Description = purposeDescriptionDTO.Description,
            };

            return purposeMain;
        }

        public static PurposeDescriptionDTO Map(PurposeDescription purposeDescription)
        {
            var purposeDto = new PurposeDescriptionDTO
            {
                Id = purposeDescription.Id,
                DocumentId = purposeDescription.DocumentId,
                Description = purposeDescription.Description,
            };

            return purposeDto;
        }

        public static List<PurposeDescription> Map(DocumentsPurposePutPost documentsPurpose)
        {
           var listOfPurpose = new List<PurposeDescription>();

            foreach (var list in documentsPurpose.Description)
            {
                var postPurpose = new PurposeDescription
                {
                    Id = Guid.NewGuid(),
                    DocumentId = documentsPurpose.DocumentId,
                    Description = list.Description,
                    
                };
                listOfPurpose.Add(postPurpose); // Add the newly created object to the list
            }

            return listOfPurpose; // Return the list containing all the PurposeDescription objects
        }

        public static PurposeDescription Map(PurposePutPost purposePutPost, PurposeDescription purposeDescription)
        {
            purposeDescription.Description = purposePutPost.Description;

            return purposeDescription;
        }
    }
}

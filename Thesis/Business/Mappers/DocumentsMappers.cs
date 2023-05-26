using Thesis.DTO.DocumentsDTO;
using Thesis.Models;

namespace Thesis.Business.Mappers
{
    public class DocumentsMappers
    {
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

        public static DocumentsDTO Map (Documents documentsMain)
        {
            var doumentsDTO = new DocumentsDTO
            {
               DocumentId= documentsMain.DocumentId,
               DocumentName= documentsMain.DocumentName,
               Price= documentsMain.Price,
                IsVoter = documentsMain.IsVoter,
                NonVoter = documentsMain.NonVoter,
            };

            return doumentsDTO; 
        }

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

        public static Documents Map(DocumentsPutPostDTO documentsDTO, Documents documentsMain)
        {
            documentsMain.DocumentName = documentsDTO.DocumentName;
            documentsMain.Price = documentsDTO.Price;
            documentsMain.IsVoter = documentsDTO.IsVoter;
            documentsMain.NonVoter = documentsDTO.NonVoter;

            return documentsMain;
        }
    }
}

using Thesis.DTO.YourRequestDTO;
using Thesis.Models;

namespace Thesis.Business.Mappers
{
    public class YourRequestMappers
    {
        //GetData from the database
        public static YourRequest Map(YourRequestDTO yourRequestDT0)
        {
            var yourRequestMain = new YourRequest
            { 
                Id = Guid.NewGuid(),
                UserId = yourRequestDT0.UserId,
                DocumentId= yourRequestDT0.DocumentId,
                Purpose = yourRequestDT0.Purpose,
                DocumentStatus= yourRequestDT0.DocumentStatus,
                DateRequested= yourRequestDT0.DateRequested,
            };
            return yourRequestMain;
        }

        //GetData from the DTO
        public static YourRequestDTO Map(YourRequest yourRequest, string documentName)
        {
            var yourRequestDto = new YourRequestDTO
            {
                Id = yourRequest.Id,
                UserId = yourRequest.UserId,
                DocumentId = yourRequest.DocumentId,
                Purpose= yourRequest.Purpose,
                DocumentStatus= yourRequest.DocumentStatus,
                DateRequested= yourRequest.DateRequested,
                DocumentName = documentName
            };

            return yourRequestDto;
        }

        public static YourRequest Map(YourRequestPutPostDTO yourRequestPutPostDTO)
        {
            var requestDocument = new YourRequest
            {
                Id = yourRequestPutPostDTO.Id,
                UserId = yourRequestPutPostDTO.UserId,
                DocumentId= yourRequestPutPostDTO.DocumentId,
                Purpose= yourRequestPutPostDTO.Purpose,
                DocumentStatus= yourRequestPutPostDTO.DocumentStatus,
                DateRequested = yourRequestPutPostDTO.DateRequested,
            };

            return requestDocument;
        }
        //Update Data
        public static YourRequest Map(YourRequestPutPostDTO yourRequestPutPostDTO, YourRequest yourRequest)
        {
            yourRequest.Id = yourRequestPutPostDTO.Id;

            return yourRequest;
        }

    }
}

using Thesis.DTO.YourRequestDTO;
using Thesis.Models;

namespace Thesis.Business.Mappers
{
    public class YourRequestMappers
    {
        //GetData from the database
        public static YourRequest Map(YourRequestDTO yourRequestDTO)
        {
            var yourRequestMain = new YourRequest
            { 
                Id = Guid.NewGuid(),
                UserId = yourRequestDTO.UserId,
                DocumentId= yourRequestDTO.DocumentId,
                Purpose= yourRequestDTO.Purpose,
                DocumentStatus= yourRequestDTO.DocumentStatus,
                DateRequested= yourRequestDTO.DateRequested,
            };
            return yourRequestMain;
        }

        //GetData from the DTO
        public static YourRequestDTO Map(YourRequest yourRequest)
        {
            var yourRequestDto = new YourRequestDTO
            {
                Id = yourRequest.Id,
                UserId = yourRequest.UserId,
                DocumentId = yourRequest.DocumentId,
                Purpose= yourRequest.Purpose,
                DocumentStatus= yourRequest.DocumentStatus,
                DateRequested= yourRequest.DateRequested,
            };

            return yourRequestDto;
        }

        //Update Data
        public static YourRequest Map(YourRequestPutPostDTO yourRequestPutPostDTO, YourRequest yourRequest)
        {
            yourRequest.DocumentId = yourRequestPutPostDTO.DocumentId;

            return yourRequest;
        }

    }
}

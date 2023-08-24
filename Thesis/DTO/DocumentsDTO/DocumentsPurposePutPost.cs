using Thesis.DTO.PurposeDTO;

namespace Thesis.DTO.DocumentsDTO
{
    public class DocumentsPurposePutPost
    {
        public Guid DocumentId { get; set; }
        public List<PurposeDescriptionDTO> Description { get; set; }
    }
}

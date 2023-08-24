using Thesis.DTO.PurposeDTO;
using Thesis.Models;

namespace Thesis.DTO.DocumentsDTO
{
    public class DocumentsDTO
    {
        public Guid DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? Price { get; set; }
        public bool IsVoter { get; set; }
        public bool NonVoter { get; set; }
    }
}

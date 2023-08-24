using System.ComponentModel.DataAnnotations;
using Thesis.DTO.PurposeDTO;

namespace Thesis.Models
{
    public class Documents
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? Price { get; set; }
        public bool IsVoter { get; set; }
        public bool NonVoter {  get; set; }

        //public List<PurposeDescriptionDTO> PurposeDescriptions { get; set; }
    }
}

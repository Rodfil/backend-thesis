using System.ComponentModel.DataAnnotations;

namespace Thesis.Models
{
    public class Documents
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? Price { get; set; }
        public bool IsVoter { get; set; }
        public bool NonVoter { get; set; }

    }
}

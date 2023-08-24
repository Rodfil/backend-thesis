using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class Requirements
    {
        [Key]
        public Guid RequirementId { get; set; }
        [ForeignKey("DocumentId")]
        public Guid DocumentId { get; set; }
        public string? Description { get; set; }

    }
}

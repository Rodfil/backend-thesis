using System.ComponentModel.DataAnnotations;

namespace Thesis.Models
{
    public class PurposeDescription
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Thesis.Models
{
    public class YourRequest
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DocumentId { get; set; }
        public string Purpose { get; set; }
        public int DocumentStatus { get; set; }
        public DateTime DateRequested { get; set; }
    }
}

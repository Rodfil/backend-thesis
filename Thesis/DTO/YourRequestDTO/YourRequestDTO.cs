namespace Thesis.DTO.YourRequestDTO
{
    public class YourRequestDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DocumentId { get; set; }
        public string Purpose { get; set; }
        public int DocumentStatus { get; set; }
        public DateTime DateRequested { get; set; }

        public string DocumentName { get; set; }
    }
}

namespace Thesis.DTO.YourRequestDTO
{
    public class YourRequestPutPostDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DocumentId { get; set; }
        public string Purpose { get; set; }
        public int DocumentStatus { get; set; }
        public string DateRequested { get; set; }
    }
}

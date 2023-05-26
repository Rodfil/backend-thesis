namespace Thesis.DTO.RequirementDTO
{
    public class RequirementsPutPostDTO
    {
        public Guid RequirementId { get; set; }
        public Guid DocumentId { get; set; }
        public string? Description { get; set; }
        
    }
}

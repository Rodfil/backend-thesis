namespace Thesis.DTO.DocumentsDTO
{
    public class DocumentsPutPostDTO
    {
        public string? DocumentName { get; set; }
        public string? Price { get; set; }
        public bool IsVoter { get; set; }
        public bool NonVoter { get; set; }
    }
}

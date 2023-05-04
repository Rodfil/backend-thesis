namespace Thesis.DTO.CreateAccountDTO
{
    public class CreateAccountPutPostDTO
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string? VoterStatus { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
        //public bool RegistrationStatus { get; set; }
    }
}

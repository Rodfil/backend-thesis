using System.ComponentModel.DataAnnotations;

namespace Thesis.Models
{
    public class CreateAccount
    {
        [Key]
        public Guid UserId { get; set; }
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

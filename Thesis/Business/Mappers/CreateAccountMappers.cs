using Thesis.DTO.CreateAccountDTO;
using Thesis.Models;

namespace Thesis.Business.Mappers
{
    public class CreateAccountMappers
    {
        public static CreateAccount Map (CreateAccountDTO createAccountDTO)
        {
            var createAccountMain = new CreateAccount
            {
                UserId = Guid.NewGuid(),
                Firstname = createAccountDTO.Firstname,
                Lastname = createAccountDTO.Lastname,
                Gender = createAccountDTO.Gender,
                Birthdate = createAccountDTO.Birthdate,
                VoterStatus = createAccountDTO.VoterStatus,
                Address = createAccountDTO.Address,
                ContactNumber = createAccountDTO.ContactNumber,
                Email = createAccountDTO.Email,
                Password = createAccountDTO.Password,
                UserType = createAccountDTO.UserType,
                RegistrationStatus = createAccountDTO.RegistrationStatus,
            };

            return createAccountMain;
        }

        public static CreateAccountDTO Map (CreateAccount createAccountMain)
        {
            var createAccountDto = new CreateAccountDTO
            {
                UserId = createAccountMain.UserId,  
                Firstname = createAccountMain.Firstname,
                Lastname = createAccountMain.Lastname,
                Gender = createAccountMain.Gender,
                Birthdate = createAccountMain.Birthdate,
                VoterStatus = createAccountMain.VoterStatus,
                Address = createAccountMain.Address,
                ContactNumber = createAccountMain.ContactNumber,
                Email = createAccountMain.Email,
                Password = createAccountMain.Password,
                UserType = createAccountMain.UserType,
                RegistrationStatus = createAccountMain.RegistrationStatus,
            };

            return createAccountDto;
        }

        public static CreateAccount Map (CreateAccountPutPostDTO createAccountPutPostDTO)
        {
            var createAccountMain = new CreateAccount
            {
                UserId = Guid.NewGuid(),
                Firstname = createAccountPutPostDTO.Firstname,
                Lastname = createAccountPutPostDTO.Lastname,
                Gender = createAccountPutPostDTO.Gender,
                Birthdate = createAccountPutPostDTO.Birthdate,
                VoterStatus = createAccountPutPostDTO.VoterStatus,
                Address = createAccountPutPostDTO.Address,
                ContactNumber = createAccountPutPostDTO.ContactNumber,
                Email = createAccountPutPostDTO.Email,
                Password = createAccountPutPostDTO.Password,
                UserType = createAccountPutPostDTO.UserType,
                RegistrationStatus = createAccountPutPostDTO.RegistrationStatus,
            };

            return createAccountMain;
        }

        public static CreateAccount Map (CreateAccountPutPostDTO createAccountPutPostDTO, CreateAccount createAccountMain)
        {
            createAccountMain.Firstname = createAccountPutPostDTO.Firstname;
            createAccountMain.Lastname = createAccountPutPostDTO.Lastname;
            createAccountMain.Gender = createAccountPutPostDTO.Gender;
            createAccountMain.Birthdate = createAccountPutPostDTO.Birthdate;
            createAccountMain.VoterStatus = createAccountPutPostDTO.VoterStatus;
            createAccountMain.Address = createAccountPutPostDTO.Address;
            createAccountMain.ContactNumber = createAccountPutPostDTO.ContactNumber;
            createAccountMain.Email = createAccountPutPostDTO.Email;
            createAccountMain.Password = createAccountPutPostDTO.Password;
            createAccountMain.UserType = createAccountPutPostDTO.UserType;
            createAccountMain.RegistrationStatus = createAccountPutPostDTO.RegistrationStatus;

            return createAccountMain;
        }
    }
}

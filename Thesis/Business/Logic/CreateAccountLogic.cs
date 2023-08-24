using Microsoft.EntityFrameworkCore;
using Thesis.DTO.CreateAccountDTO;
using Thesis.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Egorventment.DataAccess;

namespace Thesis.Business.Logic
{
    public class CreateAccountLogic
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration Configuration;

        public CreateAccountLogic(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public async Task<List<CreateAccountDTO>> GetUsers()
        {
            var listOfUsers = await _context.CreateAccounts
                            .Select(u => Mappers.CreateAccountMappers.Map(u))
                            .ToListAsync();
            return listOfUsers;
        }

        public async Task<List<CreateAccountDTO>> GetUsersById(Guid userId)
        {
            var query = await _context.CreateAccounts
                        .Where(u => u.UserId == userId)
                        .Select(u => Mappers.CreateAccountMappers.Map(u))
                        .ToListAsync();
            return query;
        }
        public async Task<CreateAccount> CreateUser(CreateAccountDTO createAccountDTO)
        {
            var createAccount = Mappers.CreateAccountMappers.Map(createAccountDTO);

            createAccount.Password = BCrypt.Net.BCrypt.HashPassword(createAccountDTO.Password);

            await _context.AddAsync(createAccount);
            await _context.SaveChangesAsync();

            return createAccount;
        }

        public async Task<bool> UpdateUser(CreateAccountPutPostDTO createAccountPutPostDTO, Guid userId)
        {
            var updateAccount = await _context.CreateAccounts.FirstOrDefaultAsync(u => u.UserId == userId); 
            if (updateAccount == null)
            {
                return false;
            }
            Mappers.CreateAccountMappers.Map(createAccountPutPostDTO, updateAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var deleteUser = _context.CreateAccounts.FirstOrDefault(u => u.UserId == userId);
            if (deleteUser == null)
            {
                return false;
            }
            _context.CreateAccounts.Remove(deleteUser);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CreateAccountDTO> AuthenticateUser(LoginDTO loginDTO)
        {

            var user = await _context.CreateAccounts.FirstOrDefaultAsync(u => u.Email == loginDTO.Email && u.RegistrationStatus == true);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
            {
                return null;
            }

            var loginUser = Mappers.CreateAccountMappers.Map(user);
            return loginUser; 
        }

        public async Task<bool> ApproveDisapproveUser(Guid userId, bool registrationStatus)
        {
            var approvedUser = await _context.CreateAccounts
                                             .Where(u => u.UserId == userId)
                                             .FirstOrDefaultAsync();

            if (approvedUser == null)
            {
                return false; // or handle the case when there is no unapproved user
            }

            var mailSettings = Configuration.GetSection("SmtpSettings").Get<MailSettings>();
            var message = new MailMessage();
            message.From = new MailAddress(mailSettings.Username, mailSettings.Username);
            message.To.Add(new MailAddress(approvedUser.Email, approvedUser.Email)); // Ensure approvedUser.Email is a valid email address
            message.Subject = "Registration Status";

            if (approvedUser.RegistrationStatus)
            {
                // Update to false and send disapproval regret email
                approvedUser.RegistrationStatus = registrationStatus;
                message.Body = "Hello, " + approvedUser.Firstname + "! We regret to inform you that your registration has been disapproved.";
            }
            else
            {
                // If the current registration status is false
                if (registrationStatus)
                {
                    // Update to true and send approval message
                    approvedUser.RegistrationStatus = registrationStatus;   
                    message.Body = "Hello, " + approvedUser.Firstname + "! Your Account was successfully approved.";
                }
                else
                {
                    // No change in status, send already disapproved message
                    message.Body = "Hello, " + approvedUser.Firstname + "! Your accout is disapproved.";
                }
            }

            // Configure the SMTP client
            var smtpClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(mailSettings.Username, mailSettings.Password);
            smtpClient.EnableSsl = true;

            // Send the email
            await smtpClient.SendMailAsync(message);

            _context.CreateAccounts.Update(approvedUser);
            await _context.SaveChangesAsync();

            return true;

        }

    }
}

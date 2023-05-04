using Microsoft.EntityFrameworkCore;
using SkanLogPH_API.API.DataAccess;
using Thesis.DTO.CreateAccountDTO;
using Thesis.Models;

namespace Thesis.Business.Logic
{
    public class CreateAccountLogic
    {
        private readonly MyDbContext _context;

        public CreateAccountLogic(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<CreateAccountDTO>> GetUsers()
        {
            var listOfUsers = await _context.CreateAccounts
                .Select(u => Mappers.CreateAccountMappers.Map(u))
                .ToListAsync();
            return listOfUsers;
        }

        public async Task<CreateAccount> CreateUser(CreateAccountDTO createAccountDTO)
        {
            var createAccount = Mappers.CreateAccountMappers.Map(createAccountDTO);

            createAccount.Password = BCrypt.Net.BCrypt.HashPassword(createAccountDTO.Password);

            await _context.AddAsync(createAccount);
            await _context.SaveChangesAsync();

            return createAccount;
        }

        public async Task<CreateAccountDTO> AuthenticateUser(CreateAccountDTO createAccountDTO)
        {

            var user = await _context.CreateAccounts.FirstOrDefaultAsync(u => u.Email == createAccountDTO.Email && u.Password == createAccountDTO.Password);

            if (user == null || !BCrypt.Net.BCrypt.Verify(createAccountDTO.Password, user.Password))
            {
                return null;
            }

            return Mappers.CreateAccountMappers.Map(user);
        }

    }
}

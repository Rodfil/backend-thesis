using Egorventment.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thesis.Business.Logic;
using Thesis.DTO.CreateAccountDTO;

namespace Thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAccountController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly CreateAccountLogic _logic;
        private readonly IConfiguration Configuration;
        public CreateAccountController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _logic = new CreateAccountLogic(context, configuration);
        }

        [HttpGet]
        public async Task<ActionResult<List<CreateAccountDTO>>> GetUsers()
        {
            return Ok(await _logic.GetUsers());
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<CreateAccountDTO>>> GetUsersId(Guid userId)
        {
            return Ok(await _logic.GetUsersById(userId));
        }

        [HttpPost]
        public async Task<ActionResult<CreateAccountDTO>> CreateUsers(CreateAccountDTO createAccountDTO)
        {
            var createUser = await _logic.CreateUser(createAccountDTO);
            return Ok(createUser);
        }


        [HttpPost("authenticate")]

        public async Task<ActionResult<LoginDTO>> AuthenticateUser(LoginDTO loginDTO)
        {
            var authenticateUser = await _logic.AuthenticateUser(loginDTO);
            if (authenticateUser == null)
            {
                return null;
            }

            return Ok(authenticateUser);   
        }
        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateAccount(CreateAccountPutPostDTO createAccountPutPostDTO,Guid userId)
        {
            var result = await _logic.UpdateUser(createAccountPutPostDTO, userId);
            if (result == null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            var result = await _logic.DeleteUser(userId);
            if (result == null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPut("{userId}/ApproveDisapproved/{registrationStatus}")]
        public async Task<ActionResult<CreateAccountDTO>> ApproveDisapproveUser(Guid userId, bool registrationStatus)
            {
            var sentEmailUser = await _logic.ApproveDisapproveUser(userId, registrationStatus);
            if (sentEmailUser == null)
            {
                return NotFound(); // or handle the case when there is no approved user
            }

            return Ok(sentEmailUser);
        }

    }
}

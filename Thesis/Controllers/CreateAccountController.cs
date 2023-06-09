﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkanLogPH_API.API.DataAccess;
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

        public CreateAccountController(MyDbContext context)
        {
            _context = context;
            _logic = new CreateAccountLogic(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<CreateAccountDTO>>> GetUsers()
        {
            return Ok(await _logic.GetUsers());
        }

        [HttpPost]
        public async Task<ActionResult<CreateAccountDTO>> CreateUsers(CreateAccountDTO createAccountDTO)
        {
            var createUser = await _logic.CreateUser(createAccountDTO);
            return Ok(createUser);
        }


        [HttpPost("authenticate")]

        public async Task<ActionResult<CreateAccountDTO>> AuthenticateUser(CreateAccountDTO createAccountDTO)
        {
            var authenticateUser = await _logic.AuthenticateUser(createAccountDTO);
            if (authenticateUser == null)
            {
                return null;
            }

            return Ok(authenticateUser);   
        }

    }
}

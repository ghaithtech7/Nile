using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nile.Application.Command.UserCommand;
using Nile.Application.DtoModels;
using Nile.Application.Query.ForUser;
using Nile.Domain.EntityModel;

namespace Nile.Application.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediatR;
        public UserController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        #region Get
        [HttpGet("LoginCredintials/{email}/{password}")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCredintials(string email, string password)
        {
            LoginCredentialQuery query = new LoginCredentialQuery(email, password);
            var result = _mediatR.Send(query);
            if(result == null)
            {
                return NotFound(email);
            }
            return Ok(result);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            GetUsersQuery query = new GetUsersQuery();
            List<User> result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            GetUserByIdQuery query = new GetUserByIdQuery(userId);
            UserBasicDto? result = await _mediatR.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("GetWindowsUserName")]
        public IActionResult GetWindowsUserName()
        {
            string result = HttpContext.User.Identity.Name;
            return Ok(result);
        }
        #endregion

        #region Post
        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            UserBasicDto? result = await _mediatR.Send(command);
            if(result != null)
            {
                return Ok(result);
            }
            return Ok("Password Not Match");
        }
        #endregion

        #region Delete
        [HttpDelete("DeleteUser{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            DeleteUserCommand command = new DeleteUserCommand(userId);
            int result = await _mediatR.Send(command);
            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Deleted");
        }
        #endregion
    }
}

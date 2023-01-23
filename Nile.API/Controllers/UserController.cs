using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nile.Application.DtoModels;
using Nile.Application.UserApplication.Commands;
using Nile.Application.UserApplication.Queries;
using Nile.Application.UserApp.Commands;
using Nile.Domain.EntityModel;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Nile.Application.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
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
            string windowsAuth = HttpContext.User.Identity.Name;
            LoginCredentialQuery query = new LoginCredentialQuery(email, password, windowsAuth);
            var result = _mediatR.Send(query);
            if(result == null)
            {
                return NotFound(email);
            }
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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
            var result = await _mediatR.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("GetWindowsUserName")]
        public IActionResult GetWindowsUserName()
        {
            string result = HttpContext.User.Identity.Name;
            return Ok(result);
        }
        #endregion

        #region Add
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

        [HttpPost("AddRole")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRole([FromBody] UserRoleDto model)
        {
            AddUserRoleCommand data = new AddUserRoleCommand(model.RoleName, model.Description);
            var result = _mediatR.Send(data);
            return Ok(result);
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

        #region Update
        [HttpPost("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateRoleDto data)
        {
            UpdateUserRoleCommand command = new UpdateUserRoleCommand(
                data.UserId, data.RoleName
                );
            var result = await _mediatR.Send(command);
            return Ok(result);
        }
        #endregion
    }
}

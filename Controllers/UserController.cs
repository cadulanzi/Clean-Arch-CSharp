using Microsoft.AspNetCore.Mvc;
using UserRegistrationApi.Application.Services;
using UserRegistrationApi.Domain.Entities;

namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdUser = await _userService.Create(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.Delete(id);
            return NoContent();
        }
    }
}

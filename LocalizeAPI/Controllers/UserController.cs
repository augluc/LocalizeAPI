using Core.Entities;
using Core.Services.Interfaces;
using LocalizeAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LocalizeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authenticationService;

    public UserController(ILogger<UserController> logger, IUserService userService, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _userService = userService;
        _authenticationService = authenticationService;
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var response = _userService.GetbyId(id);

        return  Ok(response);
    }

    [HttpPost]
    [Route("")]
    public IActionResult AddUser([FromBody]AddUserDTO addUserDTO)
    {
        User user = new(addUserDTO.Username, addUserDTO.Password, addUserDTO.Email);

        _userService.AddUser(user);
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public IActionResult EditUser([FromRoute] int id, [FromBody] EditUserDTO editUserDTO)
    {
        
        _userService.UpdateUser(id, editUserDTO.Password, editUserDTO.Email);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _userService.RemoveUser(id);
        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginDTO loginDTO)
    {
        var authResult = _authenticationService.Login(
            request.Username,
            request.Password);
    }
}
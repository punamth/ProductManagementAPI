using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductManagementAPI.Application.DTOs.Auth;
using ProductManagementAPI.Application.Auth.Commands;
using ProductManagementAPI.Application.Auth.Queries;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _mediator.Send(new RegisterUserCommand(dto));
        if (!result) return BadRequest("Username already exists.");
        return Ok("Registration successful.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _mediator.Send(new LoginUserQuery(dto));
        if (token == null) return Unauthorized("Invalid credentials.");
        return Ok(new { token });
    }
}
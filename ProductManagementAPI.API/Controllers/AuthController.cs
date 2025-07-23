using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductManagementAPI.Application.DTOs.Auth;
using ProductManagementAPI.Application.Auth.Commands;
using ProductManagementAPI.Application.Auth.Queries;
using ProductManagementAPI.API.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthController(IMediator mediator, IJwtTokenGenerator jwtTokenGenerator)
    {
        _mediator = mediator;
        _jwtTokenGenerator = jwtTokenGenerator;
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
        var user = await _mediator.Send(new LoginUserQuery(dto));
        if (user == null) return Unauthorized("Invalid credentials.");

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Ok(new { token });
    }
}
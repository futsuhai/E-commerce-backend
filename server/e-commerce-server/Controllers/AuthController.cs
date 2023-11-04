using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace e_commerce_server.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        ILogger<AuthController> logger,
        IAccountService accountService,
        IMapper mapper)
    {
        _logger = logger;
        _accountService = accountService;
        _mapper = mapper;
    }

    [HttpPost("Auth")]
    public async Task<IResult> Login([FromBody] AccountModel accountModel)
    {
        var account = await _accountService.LoginAsync(accountModel.Login, accountModel.Password);
        if (account == null)
        {
            return Results.Unauthorized();
        }
        var token = GetJwtToken(accountModel.Login);
        var loginedAccount = _mapper.Map<AccountModel>(account);
        var response = new
        {
            acces_token = token,
            account = loginedAccount
        };
        return Results.Json(response);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] AccountModel accountModel)
    {
        var account = _mapper.Map<Account>(accountModel);
        await _accountService.CreateAsync(account);
        var token = GetJwtToken(account.Login);
        return Ok(token);
    }

    private static string GetJwtToken(string login)
    {
        var claims = new List<Claim>() { new(ClaimTypes.Name, login) };
        var jwt = new JwtSecurityToken(
            issuer: JwtOptions.Issuer,
            audience: JwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
            signingCredentials: new(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return token;
    }
}

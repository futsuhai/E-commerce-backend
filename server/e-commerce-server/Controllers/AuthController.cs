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

    private readonly AppConsts _appConsts;

    private readonly CryptoOptions _cryptoOptions;

    public AuthController(
        ILogger<AuthController> logger,
        IAccountService accountService,
        IMapper mapper,
        CryptoOptions cryptoOptions,
        AppConsts appConsts)
    {
        _logger = logger;
        _accountService = accountService;
        _mapper = mapper;
        _cryptoOptions = cryptoOptions;
        _appConsts = appConsts;
    }

    [HttpPut("Auth")]
    public async Task<IActionResult> Login([FromBody] AccountModel accountModel)
    {
        var account = await _accountService.LoginAsync(accountModel.Login);
        if (account == null)
        {
            return Unauthorized();
        }
        var hashPassword = _cryptoOptions.GenerateHashPassword(accountModel.Password, Convert.FromBase64String(account.Salt));
        if (Convert.ToBase64String(hashPassword) == account.HashPassword)
        {
            var tokens = GetJwtTokens(account.Login, _appConsts);
            account.Tokens = tokens;
            await _accountService.UpdateAsync(account.Id, account);
            var loginedAccount = _mapper.Map<AccountModel>(account);
            var response = new
            {
                tokens = tokens,
                account = loginedAccount
            };
            return Ok(response);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] AccountModel accountModel)
    {
        var salt = _cryptoOptions.GenerateSalt();
        var hashPassword = _cryptoOptions.GenerateHashPassword(accountModel.Password, salt);
        var account = _mapper.Map<Account>(accountModel);
        account.Salt = Convert.ToBase64String(salt);
        account.HashPassword = Convert.ToBase64String(hashPassword);
        var tokens = GetJwtTokens(account.Login, _appConsts);
        account.Tokens = tokens;
        await _accountService.CreateAsync(account);
        // check logins and emails
        return Ok(tokens);
    }

    [HttpPut("RefreshTokens")]
    public async Task<IActionResult> RefreshTokens([FromBody] string refreshToken)
    {
        var login = GetLoginFromJwtToken(refreshToken);
        var account = await _accountService.GetAccountByLoginAsync(login);
        if (account.Tokens.refreshToken == refreshToken)
        {
            var tokens = GetJwtTokens(login, _appConsts);
            account.Tokens = tokens;
            await _accountService.UpdateAsync(account.Id, account);
            return Ok(tokens);
        }
        else
        {
            return Unauthorized();
        }
    }

    private static Tokens GetJwtTokens(string? login, AppConsts appConsts)
    {
        if (login is null)
        {
            throw new ArgumentNullException(nameof(login));
        }
        var claims = new List<Claim>() { new(ClaimTypes.Name, login) };

        var access = new JwtSecurityToken(
            issuer: JwtOptions.Issuer,
            audience: JwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(appConsts.accessTime)),
            signingCredentials: new(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );
        var accessToken = new JwtSecurityTokenHandler().WriteToken(access);

        var refresh = new JwtSecurityToken(
        issuer: JwtOptions.Issuer,
        audience: JwtOptions.Audience,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(appConsts.refreshTime)),
        signingCredentials: new(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );
        var refreshToken = new JwtSecurityTokenHandler().WriteToken(refresh);

        return new Tokens
        {
            accessToken = accessToken,
            refreshToken = refreshToken
        };
    }

    private string GetLoginFromJwtToken(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

        if (securityToken == null)
        {
            throw new SecurityTokenException("Invalid token.");
        }

        var loginClaim = securityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
        if (loginClaim != null)
        {
            return loginClaim.Value;
        }

        throw new SecurityTokenException("Login claim not found in the token.");
    }
}

using Microsoft.AspNetCore.Mvc;

namespace e_commerce_server.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IAccountService _accountService;
    private readonly ILogger<ProductController> _logger;

    public AuthController(
        ILogger<ProductController> logger,
        IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    [HttpPost("Auth")]
    public async Task<IActionResult> Login([FromBody] Account account)
    {
        //await _accountService.Login(account);
        return Ok("Успешная авторизация");
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] Account account)
    {
        await _accountService.CreateAsync(account);
        return Ok("Регистрация успешна");
    }

}

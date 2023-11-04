using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_server.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{

    private readonly IAccountService _accountService;
    private readonly ILogger<AccountController> _logger;

    private readonly IMapper _mapper;

    public AccountController(
        ILogger<AccountController> logger,
        IAccountService accountService,
        IMapper mapper)
    {
        _logger = logger;
        _accountService = accountService;
        _mapper = mapper;
    }

    [HttpGet("GetAccount/{login}")]
    public async Task<AccountModel> GetAccountAsync(string login)
    {
        var account = await _accountService.GetAccountByLoginAsync(login);
        return _mapper.Map<AccountModel>(account);
    }
}

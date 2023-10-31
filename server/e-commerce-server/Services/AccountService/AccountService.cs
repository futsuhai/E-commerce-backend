using e_commerce_server;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(
        IAccountRepository accountRepository
    //mapper
    )
    {
        _accountRepository = accountRepository;
        //mapper
    }

    public async Task<IList<Account>> GetAllAsync() =>
        await _accountRepository.GetAllAsync();

    public async Task<Account> GetAsync(Guid id) =>
        await _accountRepository.GetAsync(id);

    public async Task DeleteAsync(Guid id) =>
        await _accountRepository.DeleteAsync(id);

    public async Task UpdateAsync(Guid id, Account item) =>
        await _accountRepository.UpdateAsync(id, item);

    public async Task CreateAsync(Account item) =>
        await _accountRepository.CreateAsync(item);
}

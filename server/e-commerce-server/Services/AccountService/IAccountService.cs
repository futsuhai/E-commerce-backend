using e_commerce_server;

public interface IAccountService : IService<Account>
{
    public Task<Account?> LoginAsync(string login);

    public Task<Account?> GetAccountByLoginAsync(string login);
}
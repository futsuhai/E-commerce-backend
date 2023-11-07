namespace e_commerce_server;

public class Account
{
    public Guid Id { get; set; }

    public string? Login { get; set; }

    public string? HashPassword { get; set; }

    public string? Email { get; set; }

    public string? Salt { get; set; }

    public Tokens? Tokens { get; set; }
}
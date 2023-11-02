namespace e_commerce_server;

public class Account {
    public Guid Id { get; set; }

    public string? Login {get; set;} = string.Empty;

    public string? Password {get; set;} = string.Empty;

    public string? Email {get; set;} = string.Empty;
}
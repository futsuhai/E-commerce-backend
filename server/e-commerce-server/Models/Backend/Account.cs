namespace e_commerce_server;

public class Account {
    public Guid Id { get; set; }

    public string? Login {get; set;}

    public string? Password {get; set;}

    public string? Email {get; set;}
}
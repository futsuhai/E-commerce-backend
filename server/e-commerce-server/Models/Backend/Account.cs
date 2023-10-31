namespace e_commerce_server;

public class Account{
    public Guid Id { get; set; }

    public String? Login {get; set;}

    public String? Password {get; set;}

    public String? Email {get; set;}
}
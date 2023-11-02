namespace e_commerce_server;

public class Product {
    public Guid Id { get; set; }
    public double CardPrice { get; set; } = 0;
    public double CommonPrice { get; set; } = 0;
    public string? Title { get; set; } = string.Empty;
    public int Rating { get; set; } = 0;
    public string? Image { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    public int Weight { get; set; } = 0;
    public int Article { get; set; } = 0;
    public int Reviews { get; set; } = 0;
    public string? Brand { get; set; } = string.Empty;
}
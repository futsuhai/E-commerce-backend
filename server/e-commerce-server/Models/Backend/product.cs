namespace e_commerce_server;

public class Product{
    public Guid Id { get; set; }
    public double CardPrice { get; set; }
    public double CommonPrice { get; set; }
    public string? Title { get; set; }
    public int Rating { get; set; }
    public string? Image { get; set; }
    public string? Country { get; set; }
    public int Weight { get; set; }
    public int Article { get; set; }
    public int Reviews { get; set; }
    public string? Brand { get; set; }
}
namespace e_commerce_server;

public class Product{
    public Guid Id { get; set; }
    public double CardPrice { get; set; }
    public double CommonPrice { get; set; }
    public String? Title { get; set; }
    public int Rating { get; set; }
    public String? Image { get; set; }
    public String? Country { get; set; }
    public int Weight { get; set; }
    public int Article { get; set; }
    public int Reviews { get; set; }
    public String? Brand { get; set; }
}
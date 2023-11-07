using e_commerce_server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

// consts
builder.Services.AddSingleton<AppConsts>();
// mapper
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
// options
builder.Services.Configure<DatabaseOptions>(
    builder.Configuration.GetSection("DatabaseOptions"));
builder.Services.AddSingleton<CryptoOptions>();
// services
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IAccountService, AccountService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "http://localhost:4200");
    });
}

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

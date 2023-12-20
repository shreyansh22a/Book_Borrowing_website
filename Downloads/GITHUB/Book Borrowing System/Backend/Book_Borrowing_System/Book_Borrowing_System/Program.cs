using Business_Layer.IServices;
using Business_Layer.Services;
using Data_Access_Layer.IRepository;
using Data_Access_Layer.Repository;
using Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Set the culture to invariant
var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("APIConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.MapControllers();

// Use JWT authentication
var key = Encoding.ASCII.GetBytes("your-secret-key"); // Replace with your own secret key
app.UseAuthentication();
app.UseAuthorization();

// Set the default culture to invariant

// Run migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();

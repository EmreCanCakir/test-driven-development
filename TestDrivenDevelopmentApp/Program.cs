using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestDrivenDevelopmentApp.DataAccess;
using TestDrivenDevelopmentApp.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services) {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddDbContext<MainDbContext>(options => options.UseSqlServer(connectionString));
    services.AddTransient<IBookService, BookService>();
    services.AddTransient<IBookDal, EfBookDal>();
}
using API.CoreSystem.Manager.Infrastructure;
using API.CoreSystem.Manager.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var teste = builder.Configuration.GetConnectionString("CoreSystemDB");
builder.Services.AddDbContext<CoreSystemContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {

        opt.MigrationsAssembly("API.CoreSystem.Manager.Repository");
        opt.MigrationsHistoryTable("Migrations", "Configuration");
    });
}, ServiceLifetime.Transient);


builder.Services.AddDIServices();
builder.Services.AddApiVersioning();
builder.Services.AddAutoMapper(typeof(AutoMapperProfileConfiguration));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoreCors();
//app.UseCoreSystemApiKey();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

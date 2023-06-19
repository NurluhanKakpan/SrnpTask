using Core.Application.Interfaces;
using Core.Persistence;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    option =>
    {
        option
            .WithOrigins("http://localhost:3000")                        
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    }));  

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
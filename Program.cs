using MediatR;
using Microsoft.EntityFrameworkCore;
using SLAMobileApi.Data;
using SLAMobileApi.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<SlaMobileContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped(typeof(GenericDataService<>));
builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<IStashService, StashService>();
builder.Services.AddScoped<ISlaSavingsService, SlaSavingsService>();
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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
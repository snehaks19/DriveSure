using Microsoft.EntityFrameworkCore;
using MotorPolicyApi.Core.Interfaces;
using MotorPolicyApi.Core.Services;
using MotorPolicyApi.Domain.Interfaces;
using MotorPolicyApi.Infrastructure.Data;
using MotorPolicyApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MotorPolicyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICodesMasterRep, CodesMasterRep>();
builder.Services.AddScoped<ICodesMasterService, CodesMasterService>();
builder.Services.AddScoped<IMotorPolicyService, MotorPolicyService>();
builder.Services.AddScoped<IMotorPolicyRep, MotorPolicyRep>();
builder.Services.AddScoped<IUserMasterService, UserMasterService>();
builder.Services.AddScoped<IUserMasterRep, UserMasterRep>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

builder.Services.AddCors();
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
app.MapControllers();

app.Run();

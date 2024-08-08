// Program.cs
using Microsoft.EntityFrameworkCore;
using Unity;
using Unity.Microsoft.DependencyInjection;
using RunningActivity.Infrastructure.DBContext;
using Unity.Lifetime;
using RunningActivity.Domain.Contracts;
using RunningActivity.Infrastructure.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Options;
using RunningActivity.WebApi.Mapper;
using log4net.Config;
using log4net;

var builder = WebApplication.CreateBuilder(args);

// Configure log4net
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RunningActivityDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(DomainMappingProfile));
builder.Services.AddAutoMapper(typeof(ServiceMappingProfile));



builder.Services.AddScoped<IRunningActivityUnitofWork, RunningActivityUnitofWork>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

var app = builder.Build();
builder.Services.AddEndpointsApiExplorer();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

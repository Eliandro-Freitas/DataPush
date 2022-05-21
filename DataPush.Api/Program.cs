using DataPush.Api.Configurations;
using DataPush.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
var connectionString = configuration.GetSection("ConnectionString").Value;

var service = builder.Services;
service.AddControllers();
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
service.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString)
    .ConfigureLoggingCacheTime(TimeSpan.FromMinutes(5)));
service.AddDependences();
service.AddCors(x =>
{
    x.AddDefaultPolicy(/*name: "LocalHost", */x => x.WithOrigins("http://localhost:8080/"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
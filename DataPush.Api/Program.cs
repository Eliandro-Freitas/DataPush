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

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("v1/swagger", "Thoth"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
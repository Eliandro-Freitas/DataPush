using DataPush.Domain.Repositories;
using DataPush.Infra;
using DataPush.Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
service.AddControllers();
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
service.AddMediatR(Assembly.Load("DataPush.Domain"));
service.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("ConnectionString"));
service.AddTransient<ISegmentRepository, SegmentRepository>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

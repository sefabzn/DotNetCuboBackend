using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using DataAccess.Concrete.Entityframework.Contexts;
using Microsoft.EntityFrameworkCore;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutoFacBusinessModule());
    });

builder.Services.AddDbContext<CuboContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddDependencyResolvers(new CoreModule());


//My Configurations
builder.Services.ConfigureLoggerService();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();// bunu biz yazdik �alisma suresi boyunca exceptionlari handle etmek i�in
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());//gelen isteklere izin ver angulardan
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

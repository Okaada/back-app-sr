using back_app_sr_Application;
using back_app_sr_Application.User.Business.Interface;
using back_app_sr_Application.User.Business.Service;
using back_app_sr.Infra;
using back_app_sr.Infra.Repository.Interfaces;
using back_app_sr.Infra.Repository.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfra();
builder.Services.AddApplication();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();   

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
return;

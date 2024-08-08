using back_app_sr_Application;
using back_app_sr.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfra();
builder.Services.AddApplication();
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
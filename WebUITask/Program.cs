using WebUITask.DataAccess.Injection;
using WebUITask.Services.Abstracts;
using WebUITask.Services.Concrets;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DataInjection.DataServices(builder.Services, builder.Configuration);

builder.Services.AddScoped<ICustomerInterface, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

using Booking.AccommodationNS.Infrastructure;
using Booking.BuildingBlocks.Infrastructure.Extensions;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthorization();

builder.Services.ConfigureAccomodationModule(builder.Configuration);


builder.Services
    .AddMassTransit(x =>
    {
        x.AddConsumersFromAssemblies([
            Booking.AccommodationNS.Infrastructure.AssemblyReference.Assembly
    ]);
        x.SetKebabCaseEndpointNameFormatter();
        x.SetKebabCaseEndpointNameFormatter();
        x.UsingRabbitMq((context, configurator) =>
        {
            configurator.Host(new Uri("rabbitmq://localhost/"), h =>
            {
                h.Username("user");
                h.Password("password");
            });

            configurator.ConfigureEndpoints(context);
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
     policy.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.Run();

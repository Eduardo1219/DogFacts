using DogFacts.DomainInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Hangfire;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHangfire((sp, config) =>
{
    var conn = sp.GetRequiredService<IConfiguration>().GetConnectionString("Default");
    config.UseSqlServerStorage(conn);
});

builder.Services.AddCors(o => o.AddPolicy("Policy", b =>
{
    b.SetIsOriginAllowed(hostName => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetPreflightMaxAge(TimeSpan.FromMinutes(10));
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();
app.Run();

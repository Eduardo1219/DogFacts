using Hangfire;
using Worker.DomainInjection;


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddHangfire((sp, config) =>
{
    var conn = sp.GetRequiredService<IConfiguration>().GetConnectionString("Default");
    config
    .UseSqlServerStorage(conn);
});
builder.Services.AddHangfireServer();
builder.Services.AddHostedService<Worker.HangfireWorker>();
var host = builder.Build();

host.Run();

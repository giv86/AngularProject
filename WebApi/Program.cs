using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Services.Core;

var builder = WebApplication.CreateBuilder(args);

const string connectionString =
  "server=s42.zenbox.pl;user id=zygmuntk_nawia;database=zygmuntk_nawia;password=1#Up_3Dw;SslMode=none;default command timeout=120;";

builder.Services.AddDbContext<NawiaDbContext>(dbContextOptions =>
  dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

builder.Services
  .AddCors()
  .AddResponseCompression()
  .AddControllers()
  .AddNewtonsoftJson(c =>
  {
    c.SerializerSettings.Formatting = Formatting.Indented;
    c.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    c.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
    c.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    c.SerializerSettings.Culture = new CultureInfo("en-US");
    c.SerializerSettings.ContractResolver = new DefaultContractResolver();
  });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(a => a.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().SetIsOriginAllowed(b => true));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

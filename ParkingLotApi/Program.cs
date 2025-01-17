using ParkingLotApi;
using ParkingLotApi.Repository;
using ParkingLotApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// global exception filter
builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidCapacityExceptionFilter>();
});
builder.Services.AddScoped<IParkingLotService, ParkingLotService>();
builder.Services.AddSingleton<IParkingLotRepository, ParkingLotRepository>();
builder.Services.Configure<ParkingLotDatabaseSetting>(
    builder.Configuration.GetSection("ParkingLotDatabase"));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
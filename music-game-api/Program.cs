using music_game_api.Services;
using OfficeOpenXml;
using songDB;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);
var path = "../songDB/songs.xlsx";
var excelFile = new FileInfo(path);
var excelPackage = new ExcelPackage(excelFile);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<ExcelSongRepository>(provider => new ExcelSongRepository(excelPackage));

builder.Services.AddSingleton<SongService>();

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
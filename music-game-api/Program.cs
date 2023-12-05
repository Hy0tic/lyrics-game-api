using music_game_api.Hubs;
using music_game_api.Services;
using OfficeOpenXml;
using songDB;
using songDB.Helpers;

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
var builder = WebApplication.CreateBuilder(args);
var path = "../songDB/songs.xlsx";
var excelFile = new FileInfo(path);
var excelPackage = new ExcelPackage(excelFile);
var excelPackageWrapper = new ExcelPackageWrapper(excelPackage);
var stringHelper = new StringHelper();

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSignalR();

builder.Services
    .AddSwaggerGen()
    .AddSingleton<HttpClient>()
    .AddSingleton<IExcelPackageWrapper>(excelPackageWrapper)
    .AddSingleton<ExcelSongRepository>(provider => new ExcelSongRepository(excelPackageWrapper, stringHelper))
    .AddSingleton<SongService>();

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

app.MapHub<LobbyHub>("/lobby-hub");
app.Run();
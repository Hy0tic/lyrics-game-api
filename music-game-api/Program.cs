using music_game_api.Services;
using OfficeOpenXml;
using songDB;

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
var builder = WebApplication.CreateBuilder(args);
var path = "../songDB/songs.xlsx";
var excelFile = new FileInfo(path);
var excelPackage = new ExcelPackage(excelFile);
var excelPackageWrapper = new ExcelPackageWrapper(excelPackage);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services
    .AddSwaggerGen()
    .AddSingleton<HttpClient>()
    .AddSingleton<IExcelPackageWrapper>(excelPackageWrapper)
    .AddSingleton<ExcelSongRepository>(provider => new ExcelSongRepository(excelPackageWrapper))
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

app.Run();
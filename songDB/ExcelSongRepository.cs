using System.Security.Cryptography;
using OfficeOpenXml;

namespace songDB;
public class ExcelSongRepository 
{
    private ExcelPackage excelPackage { get; set; }

    public ExcelSongRepository(ExcelPackage excelPackage)
    {
        this.excelPackage = excelPackage;
    }

    public Song GetRandomSong() {
        var worksheet = excelPackage.Workbook.Worksheets[0];
        var totalRows = worksheet.Dimension.Rows;
        var rowIndex = RandomNumberGenerator.GetInt32(totalRows);

        var songTitle = worksheet.Cells[rowIndex, 1].Value.ToString();
        var songAlbum = worksheet.Cells[rowIndex, 2].Value.ToString();
        var songLyrics = worksheet.Cells[rowIndex, 3].Value.ToString();

        var songResult = new Song(songTitle, songAlbum, songLyrics);
        return songResult;
    }

    public string GetRandomSongTitle()
    {
        var worksheet = excelPackage.Workbook.Worksheets[0];
        var totalRows = worksheet.Dimension.Rows;
        var rowIndex = RandomNumberGenerator.GetInt32(totalRows);

        var songTitle = worksheet.Cells[rowIndex, 1].Value.ToString();

        return songTitle;
    }

}
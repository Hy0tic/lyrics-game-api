using System.Security.Cryptography;
using OfficeOpenXml;

namespace songDB;
public class ExcelSongRepository 
{
    private IExcelPackageWrapper excelPackageWrapper { get; set; }

    public ExcelSongRepository(IExcelPackageWrapper excelPackageWrapper)
    {
        this.excelPackageWrapper = excelPackageWrapper;
    }

    public Song GetRandomSong() {
        var totalRows = excelPackageWrapper.GetTotalRows();
        var rowIndex = RandomNumberGenerator.GetInt32(totalRows);

        var songTitle = excelPackageWrapper.GetTitleAtRow(rowIndex);
        var songAlbum = excelPackageWrapper.GetAlbumAtRow(rowIndex);
        var songLyrics = excelPackageWrapper.GetLyricsAtRow(rowIndex);

        var songResult = new Song(songTitle, songAlbum, songLyrics);
        return songResult;
    }

    public string GetRandomSongTitle()
    {
        var totalRows = excelPackageWrapper.GetTotalRows();
        var rowIndex = RandomNumberGenerator.GetInt32(totalRows);

        var songTitle = excelPackageWrapper.GetTitleAtRow(rowIndex);

        return songTitle;
    }

}
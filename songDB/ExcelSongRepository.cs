using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
        var rowIndex = RandomNumberGenerator.GetInt32(1,totalRows-1);

        var songTitle = RemoveContentInParentheses(excelPackageWrapper.GetTitleAtRow(rowIndex));
        var songAlbum = RemoveContentInParentheses(excelPackageWrapper.GetAlbumAtRow(rowIndex));
        var songLyrics = excelPackageWrapper.GetLyricsAtRow(rowIndex);

        var songResult = new Song(songTitle, songAlbum, songLyrics);
        return songResult;
    }

    public string GetRandomSongTitle()
    {
        var totalRows = excelPackageWrapper.GetTotalRows();
        var rowIndex = RandomNumberGenerator.GetInt32(1,totalRows-1);

        var songTitle = excelPackageWrapper.GetTitleAtRow(rowIndex);

        return RemoveContentInParentheses(songTitle);
    }
    
    private string RemoveContentInParentheses(string input)
    {
        return Regex.Replace(input, @"\([^)]*\)", "").Trim();
    }

}
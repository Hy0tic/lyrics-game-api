using System.Security.Cryptography;
using songDB.Helpers;

namespace songDB;
public class ExcelSongRepository 
{
    private IExcelPackageWrapper excelPackageWrapper { get; set; }
    private StringHelper stringHelper { get; set; }

    public ExcelSongRepository(IExcelPackageWrapper excelPackageWrapper, StringHelper stringHelper)
    {
        this.excelPackageWrapper = excelPackageWrapper;
        this.stringHelper = stringHelper;
    }

    public Song GetRandomSong() {
        var totalRows = excelPackageWrapper.GetTotalRows();
        var rowIndex = RandomNumberGenerator.GetInt32(1,totalRows-1);

        var songTitle = stringHelper.RemoveContentInSquareBrackets(stringHelper.RemoveContentInParentheses(excelPackageWrapper.GetTitleAtRow(rowIndex)));
        var songAlbum = stringHelper.RemoveContentInSquareBrackets(stringHelper.RemoveContentInParentheses(excelPackageWrapper.GetAlbumAtRow(rowIndex)));
        var songLyrics = stringHelper.RemoveContentInSquareBrackets(excelPackageWrapper.GetLyricsAtRow(rowIndex));

        var songResult = new Song(songTitle, songAlbum, songLyrics);
        return songResult;
    }

    public string GetRandomSongTitle()
    {
        var totalRows = excelPackageWrapper.GetTotalRows();
        var rowIndex = RandomNumberGenerator.GetInt32(1,totalRows-1);

        var songTitle = stringHelper.RemoveContentInSquareBrackets(excelPackageWrapper.GetTitleAtRow(rowIndex));

        return stringHelper.RemoveContentInParentheses(songTitle);
    }

}
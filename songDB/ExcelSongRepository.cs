using System.Security.Cryptography;
using OfficeOpenXml;

namespace songDB;
public class ExcelSongRepository {

    public ExcelSongRepository() { }

    public Song GetRandomSong() {
        var path = "../songDB/songs.xlsx";
        using (var package = new ExcelPackage(new FileInfo(path)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            var totalRows = worksheet.Dimension.Rows;
            var rowIndex = RandomNumberGenerator.GetInt32(totalRows);

            var songTitle = worksheet.Cells[rowIndex, 1].Value.ToString();
            var songAlbum = worksheet.Cells[rowIndex, 2].Value.ToString();
            var songLyrics = worksheet.Cells[rowIndex, 3].Value.ToString();

            var songResult = new Song(songTitle, songAlbum, songLyrics);
            return songResult;

        }

    }

}
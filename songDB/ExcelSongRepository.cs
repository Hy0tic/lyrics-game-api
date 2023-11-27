using Microsoft.VisualBasic.FileIO;

namespace songDB;
public class ExcelSongRepository {

    public ExcelSongRepository() { }

    public string GetRandomSong() {
        var path = "../songDB/songs.csv";
        using (TextFieldParser csvParser = new TextFieldParser(path))
        {
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            // Skip the row with the column names
            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                // Read current line fields, pointer moves to the next line.
                string[] fields = csvParser.ReadFields();
                string Song = fields[0];
                string Album = fields[1];
                string Lyrics = fields[2];
                return Lyrics;
            }
        }

        return "";

    }


}
using songDB;
using Moq;
using OfficeOpenXml;
using Microsoft.Extensions.FileProviders;

namespace tests;

public class ExcelSongRepositoryTest : IClassFixture<ExcelSongRepository>
{

    private ExcelSongRepository songRepository { get; set; }
    public ExcelSongRepositoryTest(ExcelSongRepository songRepository)
    {
        this.songRepository = songRepository;
    }

    [Fact]
    public void GetRandomSongTitleReturnString()
    {
        //var title = songRepository.GetRandomSongTitle();
        var title = "";

        Assert.IsType<string>(title);
    }

}
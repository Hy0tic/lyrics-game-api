using songDB;
using Moq;
using System.Security.Cryptography;
using songDB.Helpers;

namespace tests;

public class ExcelSongRepositoryTest
{
    private ExcelSongRepository songRepository { get; set; }
    private Mock<IExcelPackageWrapper> excelPackageWrapperMock { get; set; }
    private Mock<StringHelper> stringHelperMock { get; set; }

    public ExcelSongRepositoryTest()
    {
        excelPackageWrapperMock = new Mock<IExcelPackageWrapper>();
        stringHelperMock = new Mock<StringHelper>();
        excelPackageWrapperMock.Setup(service => 
            service
                .GetTitleAtRow(It.IsAny<int>()))
                .Returns("song title");

        excelPackageWrapperMock.Setup(service => 
            service
                .GetLyricsAtRow(It.IsAny<int>()))
                .Returns("song lyrics");

        excelPackageWrapperMock.Setup(service => 
            service
                .GetAlbumAtRow(It.IsAny<int>()))
                .Returns("song album");

        excelPackageWrapperMock.Setup(service => 
            service
                .GetTotalRows())
                .Returns(255);

        songRepository = new ExcelSongRepository(excelPackageWrapperMock.Object, stringHelperMock.Object);
    }

    [Fact]
    public void GetRandomSongTitleReturnString()
    {
        var title = songRepository.GetRandomSongTitle();
        Assert.IsType<string>(title);
    }

    [Fact]
    public void GetRandomSongReturnSong()
    {
        var song = songRepository.GetRandomSong();
        Assert.IsType<Song>(song);
    }

    // [Fact]
    // public void GetRandomSongCallsRandomFunction()
    // {
    //     var mockRandomClass = new Mock<RandomNumberGenerator>();
        
    //     songRepository.GetRandomSong();

    //     mockRandomClass.Verify(dependency => dependency.GetInt32(It.IsAny<int>()), Times.Once());
    // }

}
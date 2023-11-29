using songDB;
using Moq;
using OfficeOpenXml;

namespace tests;

public class ExcelSongRepositoryTest
{
    private ExcelSongRepository songRepository { get; set; }
    private Mock<IExcelPackageWrapper> excelPackageWrapperMock { get; set; }
    public ExcelSongRepositoryTest()
    {
        excelPackageWrapperMock = new Mock<IExcelPackageWrapper>();
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

        songRepository = new ExcelSongRepository(excelPackageWrapperMock.Object);
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
        // Given
        
        // When
        var song = songRepository.GetRandomSong();

        // Then
        Assert.IsType<Song>(song);
    }

    // [Fact]
    // public void GetRandomSongCallsRandomFunction()
    // {
    //     var song = songRepository.Get;

    //     Assert.IsType<Song>(song);
    // }

}
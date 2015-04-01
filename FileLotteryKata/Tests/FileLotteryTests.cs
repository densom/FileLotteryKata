using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;

namespace FileLotteryKata.Tests
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleNullReferenceException

    [TestFixture]
    public class FileLotteryTests
    {
        private IRandomProvider _randomMock;
        private IDirectoryProvider _directoryMock;

        [SetUp]
        public void Setup()
        {
            _randomMock = Substitute.For<IRandomProvider>();
            _directoryMock = Substitute.For<IDirectoryProvider>();
        }

        [Test]
        public void EmptyDirectory_ReturnsEmptyString()
        {
            _directoryMock.GetFiles().Returns(new string[] {});

            var fileLottery = new FileLottery(_randomMock, _directoryMock);
            
            Assert.That(fileLottery.Current, Is.EqualTo(string.Empty));
        }

        [Test]
        public void DirectoryWithOneFile_ReturnsThatFile()
        {
            const string expectedFile = "File 1";
            _directoryMock.GetFiles().Returns(new[] { expectedFile });

            var fileLottery = new FileLottery(_randomMock, _directoryMock);

            Assert.That(fileLottery.Current, Is.EqualTo(expectedFile));
        }

        [Test]
        public void DirectoryWithTwoFiles_ReturnsAllFiles()
        {
            var expectedFiles = new[] {"File 1", "File 2"};
            _directoryMock.GetFiles().Returns(expectedFiles);

            var fileLottery = new FileLottery(_randomMock, _directoryMock);

            Assert.That(fileLottery.Current, Is.EqualTo("File 1"));
            fileLottery.MoveNext();
            Assert.That(fileLottery.Current, Is.EqualTo("File 2"));
        }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException
}
using System.Diagnostics;
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
            _randomMock.GetDistinctRandomValues().Returns(new[] { 0 });

            var fileLottery = new FileLottery(_randomMock, _directoryMock);
            
            Assert.That(fileLottery.Current, Is.EqualTo(string.Empty));
        }

        [Test]
        public void DirectoryWithOneFile_ReturnsThatFile()
        {
            const string expectedFile = "File 1";
            _directoryMock.GetFiles().Returns(new[] { expectedFile });
            _randomMock.GetDistinctRandomValues().Returns(new[] {0});

            var fileLottery = new FileLottery(_randomMock, _directoryMock);

            Assert.That(fileLottery.Current, Is.EqualTo(expectedFile));
        }

        [Test]
        public void DirectoryWithTwoFiles_ReturnsAllFiles()
        {
            var expectedFiles = new[] {"File 1", "File 2"};
            _directoryMock.GetFiles().Returns(expectedFiles);
            _randomMock.GetDistinctRandomValues().Returns(new[] { 0, 1 });

            var fileLottery = new FileLottery(_randomMock, _directoryMock);

            Assert.That(fileLottery.Current, Is.EqualTo("File 1"));
            fileLottery.MoveNext();
            Assert.That(fileLottery.Current, Is.EqualTo("File 2"));
        }

        [Test]
        public void DirectoryWithTwoFiles_ReturnsAllFilesInRandomOrder()
        {
            _randomMock.GetDistinctRandomValues().Returns(new[] {1,0});

            var expectedFiles = new[] { "File 1", "File 2" };
            _directoryMock.GetFiles().Returns(expectedFiles);

            var fileLottery = new FileLottery(_randomMock, _directoryMock);

            Assert.That(fileLottery.Current, Is.EqualTo("File 2"));
            fileLottery.MoveNext();
            Assert.That(fileLottery.Current, Is.EqualTo("File 1"));
        }

        [Test]
        public void RunRealScenario()
        {
            _directoryMock.GetFiles().Returns(new[] {"File 1", "File 2", "File 3", "File 4"});
            var fileLottery = new FileLottery(new RandomProvider(), _directoryMock);

            var continueLoop = true;
            while (continueLoop)
            {
                Debug.WriteLine(fileLottery.Current);

                continueLoop = fileLottery.MoveNext();
            }

            //todo:  put some sort of assertion here to test that the values are random.
        }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException
}
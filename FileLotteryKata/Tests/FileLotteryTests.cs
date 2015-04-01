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
        [Test]
        public void EmptyDirectory_ReturnsEmptyString()
        {
            var randomMock = Substitute.For<IRandomProvider>();
            var directoryMock = Substitute.For<IDirectoryProvider>();

            directoryMock.GetFiles().Returns(new string[] {});

            var fileLottery = new FileLottery(randomMock, directoryMock);
            
            Assert.That(fileLottery.First(), Is.EqualTo(string.Empty));
        }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException
}
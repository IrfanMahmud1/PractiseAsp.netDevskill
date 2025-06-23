namespace Demo.Application.Tests
{
    public class AuthorServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddAuthor_UniqueName_AddsAuthor()
        {
            Assert.Pass();
        }
        [Test]
        public void AddAuthor_DuplicateName_ThrowException()
        {
            Assert.Pass();
        }
    }
}

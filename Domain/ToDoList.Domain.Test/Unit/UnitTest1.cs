namespace ToDoList.Domain.Tests.Unit;

public class Tests
{
    [TestFixture]
    public class StringExpressionsTests
    {
        [Test]
        public void SplitSentencesWithOneSpace_InputWithExtraSpaces_ReturnsStringWithOneSpace()
        {
            // Arrange
            string input = "   Isso   é   uma   frase   teste.   ";

            // Act
            string result = StringExpressions.SplitSentencesWithOneSpace(input);

            // Assert
            Assert.That(result, Is.EqualTo("Isso é uma frase teste."));
        }

        [Test]
        public void SplitSentencesWithOneSpace_InputWithoutExtraSpaces_ReturnsSameString()
        {
            // Arrange
            string input = "Isso é uma frase teste.";

            // Act
            string result = StringExpressions.SplitSentencesWithOneSpace(input);

            // Assert
            Assert.That(result, Is.EqualTo(input));
        }

        [Test]
        public void SplitSentencesWithOneSpace_NullInput_ReturnsNull() => Assert.Throws<ArgumentNullException>(() => StringExpressions.SplitSentencesWithOneSpace(null));

        [Test]
        public void SplitSentencesWithOneSpace_EmptyInput_ReturnsEmptyString()
        {
            // Act
            string result = StringExpressions.SplitSentencesWithOneSpace(string.Empty);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
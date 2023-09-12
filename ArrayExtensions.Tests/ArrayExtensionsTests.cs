namespace ArrayExtensions.Tests
{
    using FluentAssertions;

    public class ArrayExtensionsTests
    {
        [Fact]
        public void Append_ShouldAppendValuesToArray()
        {
            // Arrange
            int[] array = { 1, 2, 3 };

            // Act
            var result = array.Append(4, 5, 6);

            // Assert
            result.Should().Equal(1, 2, 3, 4, 5, 6);
        }

        [Fact]
        public void Append_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            var action = () => array.Append(4, 5, 6);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Append_ShouldThrowArgumentExceptionForEmptyElements()
        {
            // Arrange
            int[] array = { 1, 2, 3 };

            // Act
            var action = () => array.Append();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Clear_ShouldClearAllElementsInArray()
        {
            // Arrange
            int[] array = { 1, 2, 3 };
            int[] expected = { 0, 0, 0 };

            // Act
            array.Clear();

            // Assert
            array.Should().Equal(expected);
        }

        [Fact]
        public void Clear_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            var action = () => array.Clear();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Count_ShouldCountNumberOfOccurrencesOfValueInArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 2, 3, 2 };

            // Act
            var count = array.Count(2);

            // Assert
            count.Should().Be(3);
        }

        [Fact]
        public void Count_ShouldReturnZeroForValueNotInArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5, 6 };

            // Act
            var count = array.Count(7);

            // Assert
            count.Should().Be(0);
        }

        [Fact]
        public void Count_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            Action action = () => array.Count(2);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Index_ShouldReturnIndexOfFirstOccurenceOfValueInArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5, 6 };

            // Act
            var index = array.Index(3);

            // Assert
            index.Should().Be(2);
        }

        [Fact]
        public void Index_ShouldReturnMinusOneForValueNotInArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5, 6 };

            // Act
            var index = array.Index(7);

            // Assert
            index.Should().Be(-1);
        }

        [Fact]
        public void Index_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            Action action = () => array.Index(2);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Insert_ShouldInsertValueAtSpecifiedIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };

            // Act
            var result = array.Insert(2, 6);

            // Assert
            result.Should().Equal(1, 2, 6, 3, 4, 5);
        }

        [Fact]
        public void Insert_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            var action = () => array.Insert(2, 6);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Insert_ShouldThrowArgumentOutOfRangeExceptionForIndexOutOfBounds()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };

            // Act
            var action = () => array.Insert(6, 6);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Revert_ShouldRevertArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };

            // Act
            array.Revert();

            // Assert
            array.Should().Equal(5, 4, 3, 2, 1);
        }

        [Fact]
        public void Revert_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            var action = () => array.Revert();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Remove_ShouldRemoveAllElements()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5, 3 };

            // Act
            var result = array.Remove(3);

            // Assert
            result.Should().Equal(1, 2, 4, 5);
        }

        [Fact]
        public void Remove_ShouldDoNothingIfElementNotFound()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };

            // Act
            var result = array.Remove(6);

            // Assert
            result.Should().Equal(1, 2, 3, 4, 5);
        }

        [Fact]
        public void Remove_ShouldThrowArgumentNullExceptionForNullArray()
        {
            // Arrange
            int[] array = null!;

            // Act
            Action action = () => array.Remove(3);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void IsNullOrAllElementsNull_ShouldReturnTrue_WhenArrayIsNull()
        {
            // Arrange
            int[] numbers = null!;

            // Act
            var result = numbers.IsNullOrAllElementsNull();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrAllElementsNull_ShouldReturnTrue_WhenAllElementsAreNull()
        {
            // Arrange
            string[] names = { null!, null!, null! };

            // Act
            var result = names.IsNullOrAllElementsNull();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrAllElementsNull_ShouldReturnFalse_WhenSomeElementsAreNotNull()
        {
            // Arrange
            string[] names = { null!, "Alice", null! };

            // Act
            var result = names.IsNullOrAllElementsNull();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsNullOrEmpty_ShouldReturnTrue_WhenArrayIsNull()
        {
            // Arrange
            int[] numbers = null!;

            // Act
            var result = numbers.IsNullOrEmpty();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_ShouldReturnTrue_WhenArrayIsEmpty()
        {
            // Arrange
            var names = Array.Empty<string>();

            // Act
            var result = names.IsNullOrEmpty();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_ShouldReturnFalse_WhenArrayIsNotEmpty()
        {
            // Arrange
            int[] numbers = { 1, 2, 3 };

            // Act
            var result = numbers.IsNullOrEmpty();

            // Assert
            result.Should().BeFalse();
        }
    }
}

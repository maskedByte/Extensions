namespace StringExtensions.Tests
{
    using FluentAssertions;

    public class StringExtensionsTests
    {
        [Fact]
        public void Capitalize_ShouldCapitalizeFirstCharacter()
        {
            // Arrange
            const string input = "hello";
            const string expectedOutput = "Hello";

            // Act
            var actualOutput = input.Capitalize();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void Count_ShouldCountAllCharacters()
        {
            // Arrange
            const string input = "hello";
            const int expectedOutput = 2;

            // Act
            var actualOutput = input.Count('l');

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void Count_ShouldCountAllStrings()
        {
            // Arrange
            const string input = "Hello, world! Hello, world! Hello, world!";
            const int expectedOutput = 3;

            // Act
            var actualOutput = input.Count("Hello");

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("12345", true)]
        [InlineData("12345abc", false)]
        [InlineData("", false)]
        public void IsAllNum_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsAllNum();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("Hello, world!", true)]
        [InlineData("Привет, мир!", false)]
        [InlineData("", false)]
        public void IsAscii_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsAscii();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("Hello, world!", true)]
        [InlineData("Привет, мир!", true)]
        [InlineData("", false)]
        public void IsUtf8_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsUtf8();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("Hello, world!", true)]
        [InlineData("Привет, мир!", true)]
        [InlineData("", false)]
        public void IsUtf16_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsUtf16();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("123.45", true)]
        [InlineData("abc", false)]
        [InlineData("", false)]
        [InlineData("123,1", true)]
        public void IsDecimal_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsDecimal();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("false", true)]
        [InlineData("Something_long1", true)]
        [InlineData("1_test", false)]
        public void IsIdentifier_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsIdentifier();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("abcdef", true)]
        [InlineData("ABCDEF", false)]
        [InlineData("", false)]
        public void IsLower_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsLower();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("abcdef", false)]
        [InlineData("ABCDEF", true)]
        [InlineData("", false)]
        public void IsUpper_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsUpper();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("name:John Doe|age:30|city:New York", "{\"name\":\"John Doe\",\"age\":\"30\",\"city\":\"New York\"}")]
        [InlineData("", "{}")]
        [InlineData(null, "{}")]
        public void ToJson_ShouldMatchCondition(string input, string expectedOutput)
        {
            // Act
            var actualOutput = input.ToJson();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("abcdef", true)]
        [InlineData("MNOPQ", true)]
        [InlineData("cdf2agt", false)]
        [InlineData("", false)]
        public void IsAlpha_ShouldMatchCondition(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.IsAlpha();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("abcdef", "fedcba")]
        [InlineData("123456", "654321")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void Reverse_ShouldMatchCondition(string input, string expectedOutput)
        {
            // Act
            var actualOutput = input.Reverse();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }
    }
}

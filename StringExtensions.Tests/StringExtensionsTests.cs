/*
 * MIT License
 * Copyright (c) 2022 Tony Haase
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

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
        [InlineData("name:John Doe|age:30|city:New York",
            "{\"name\":\"John Doe\",\"age\":\"30\",\"city\":\"New York\"}")]
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

        [Fact]
        public void ToInt16_ShouldConvertValidInt16String()
        {
            // Arrange
            const string input = "123";
            const short expectedOutput = 123;

            // Act
            var actualOutput = input.ToInt16();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToInt16_ShouldThrowFormatExceptionForInvalidInt16String()
        {
            // Arrange
            const string input = "abc";

            // Act
            Action action = () => input.ToInt16();

            // Assert
            action.Should().Throw<FormatException>();
        }

        [Fact]
        public void ToInt16_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ToInt16();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToInt16_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ToInt16();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToInt32_ShouldConvertValidInt32String()
        {
            // Arrange
            const string input = "156482";
            const int expectedOutput = 156482;

            // Act
            var actualOutput = input.ToInt32();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToInt32_ShouldThrowFormatExceptionForInvalidInt32String()
        {
            // Arrange
            var input = "abc";

            // Act
            Action action = () => input.ToInt32();

            // Assert
            action.Should().Throw<FormatException>();
        }

        [Fact]
        public void ToInt32_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ToInt32();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToInt32_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ToInt32();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToInt64_ShouldConvertValidInt64String()
        {
            // Arrange
            var input = "123";
            long expectedOutput = 123;

            // Act
            var actualOutput = input.ToInt64();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToInt64_ShouldThrowFormatExceptionForInvalidInt64String()
        {
            // Arrange
            const string input = "abc";

            // Act
            Action action = () => input.ToInt64();

            // Assert
            action.Should().Throw<FormatException>();
        }

        [Fact]
        public void ToInt64_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ToInt64();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToInt64_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ToInt64();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToDecimal_ShouldConvertValidPeriodDecimalString()
        {
            // Arrange
            const string input = "123.45";
            const decimal expectedOutput = 123.45m;

            // Act
            var actualOutput = input.ToDecimal();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToDecimal_ShouldConvertValidCommaDecimalString()
        {
            // Arrange
            const string input = "123,45";
            const decimal expectedOutput = 123.45m;

            // Act
            var actualOutput = input.ToDecimal();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToDecimal_ShouldThrowFormatExceptionForInvalidDecimalString()
        {
            // Arrange
            const string input = "abc";

            // Act
            Action action = () => input.ToDecimal();

            // Assert
            action.Should().Throw<FormatException>();
        }

        [Fact]
        public void ToDecimal_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ToDecimal();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToDecimal_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ToDecimal();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToFloat_ShouldConvertValidPeriodFloatString()
        {
            // Arrange
            const string input = "123.45";
            const float expectedOutput = 123.45f;

            // Act
            var actualOutput = input.ToFloat();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToFloat_ShouldConvertValidCommaFloatString()
        {
            // Arrange
            const string input = "123,45";
            const float expectedOutput = 123.45f;

            // Act
            var actualOutput = input.ToFloat();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToFloat_ShouldThrowFormatExceptionForInvalidFloatString()
        {
            // Arrange
            const string input = "abc";

            // Act
            Action action = () => input.ToFloat();

            // Assert
            action.Should().Throw<FormatException>();
        }

        [Fact]
        public void ToFloat_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ToFloat();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToFloat_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ToFloat();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("0", false)]
        [InlineData("1", true)]
        public void ToBoolean_ShouldConvertValidBooleanString(string input, bool expectedOutput)
        {
            // Act
            var actualOutput = input.ToBoolean();

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("11")]
        [InlineData("abc")]
        public void ToBoolean_ShouldThrowFormatExceptionForInvalidBooleanString(string input)
        {
            // Act
            Action action = () => input.ToBoolean();

            // Assert
            action.Should().Throw<FormatException>();
        }

        [Fact]
        public void ToBoolean_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ToBoolean();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToBoolean_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ToBoolean();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ExtractQuotedText_ShouldExtractTextInsideSingleQuotes()
        {
            // Arrange
            const string input = "function(parameter1, 'This is the text to extract')";
            const string expectedOutput = "This is the text to extract";

            // Act
            var actualOutput = input.ExtractQuotedText('\'');

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ExtractQuotedText_ShouldExtractTextInsideDoubleQuotes()
        {
            // Arrange
            const string input = "function(parameter1, \"This is the text to extract\")";
            const string expectedOutput = "This is the text to extract";

            // Act
            var actualOutput = input.ExtractQuotedText('\"');

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ExtractQuotedText_ShouldThrowArgumentExceptionForMissingQuote()
        {
            // Arrange
            const string input = "function(parameter1, This is the text to extract')";

            // Act
            Action action = () => input.ExtractQuotedText('\'');

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ExtractQuotedText_ShouldThrowArgumentExceptionForNullInput()
        {
            // Arrange
            string input = null!;

            // Act
            Action action = () => input.ExtractQuotedText('\'');

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ExtractQuotedText_ShouldThrowArgumentExceptionForEmptyInput()
        {
            // Arrange
            const string input = "";

            // Act
            Action action = () => input.ExtractQuotedText('\'');

            // Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}

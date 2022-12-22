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

namespace StringExtensions
{
    using System.Text;

    /// <summary>
    /// Class to provide string extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalizes the first character of the specified string.
        /// </summary>
        /// <param name="value">The string to capitalize.</param>
        /// <returns>A new string with the first character capitalized, or the original string if it is null or empty.</returns>
        public static string Capitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var chars = value.ToCharArray();

            if (char.IsLetter(chars[0]))
            {
                chars[0] = char.ToUpper(chars[0]);
            }

            return new string(chars);
        }

        /// <summary>
        /// Counts the number of occurrences of a specified character in a string.
        /// </summary>
        /// <param name="value">The string to search in.</param>
        /// <param name="search">The character to count.</param>
        /// <returns>The number of occurrences of the specified character in the string.</returns>
        public static int Count(this string value, char search)
        {
            return string.IsNullOrEmpty(value)
                ? 0
                : value.Count(c => c == search);
        }

        /// <summary>
        /// Counts the number of occurrences of a specified string in another string.
        /// </summary>
        /// <param name="value">The string to search in.</param>
        /// <param name="search">The string to count.</param>
        /// <returns>The number of occurrences of the specified string in the string.</returns>
        public static int Count(this string value, string search)
        {
            // Check if the search string is null or empty
            if (string.IsNullOrEmpty(search) || string.IsNullOrEmpty(value))
            {
                return 0;
            }

            var count = 0;
            var index = 0;

            while (index >= 0 && index < value.Length)
            {
                index = value.IndexOf(search, index, StringComparison.Ordinal);

                // Check if an occurrence was found
                if (index >= 0)
                {
                    // Increment the count and move the index past the search string
                    count++;
                    index += search.Length;
                }
            }

            // Return the count
            return count;
        }

        /// <summary>
        /// Determines whether a string consists only of numeric characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string consists only of numeric characters, false otherwise.</returns>
        public static bool IsAllNum(this string value)
        {
            // Check if the string is null or empty
            return !string.IsNullOrEmpty(value) && value.All(ch => char.IsDigit(ch));
        }

        /// <summary>
        /// Determines whether a string consists only of ASCII characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string consists only of ASCII characters, false otherwise.</returns>
        public static bool IsAscii(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(ch => ch <= 127);
        }

        /// <summary>
        /// Determines whether a string is encoded in UTF-8.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is encoded in UTF-8, false otherwise.</returns>
        public static bool IsUtf8(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value == Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Determines whether a string is encoded in UTF-16.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is encoded in UTF-16, false otherwise.</returns>
        public static bool IsUtf16(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value == Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(value));
        }

        /// <summary>
        /// Determines whether a string represents a decimal number.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string represents a decimal number, false otherwise.</returns>
        public static bool IsDecimal(this string value)
        {
            return !string.IsNullOrEmpty(value) && decimal.TryParse(value, out _);
        }

        /// <summary>
        /// Determines whether a string is a valid C# identifier.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is a valid C# identifier, false otherwise.</returns>
        public static bool IsIdentifier(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (!char.IsLetter(value[0]) && value[0] != '_')
            {
                return false;
            }

            for (var i = 1; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]) && value[i] != '_')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether a string consists only of lowercase characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string consists only of lowercase characters, false otherwise.</returns>
        public static bool IsLower(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(ch => char.IsLower(ch));
        }

        /// <summary>
        /// Determines whether a string consists only of uppercase characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string consists only of uppercase characters, false otherwise.</returns>
        public static bool IsUpper(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(ch => char.IsUpper(ch));
        }

        /// <summary>
        /// Generates a JSON string from a source string with the format "key:value|Key:value ...".
        /// </summary>
        /// <param name="value">The source string.</param>
        /// <returns>A JSON string representing the key-value pairs in the source string.</returns>
        public static string ToJson(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "{}";
            }

            var pairs = value.Split('|');
            var jsonBuilder = new StringBuilder();
            jsonBuilder.Append('{');

            for (var i = 0; i < pairs.Length; i++)
            {
                var keyValue = pairs[i].Split(':');
                jsonBuilder.Append($"\"{keyValue[0]}\":\"{keyValue[1]}\"");

                if (i < pairs.Length - 1)
                {
                    jsonBuilder.Append(',');
                }
            }

            jsonBuilder.Append('}');
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// Reverses the order of the characters in a string.
        /// </summary>
        /// <param name="value">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string Reverse(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var reversedBuilder = new StringBuilder();

            for (var i = value.Length - 1; i >= 0; i--)
            {
                reversedBuilder.Append(value[i]);
            }

            return reversedBuilder.ToString();
        }

        /// <summary>
        /// Determines whether a string consists only of alphabetic characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string consists only of alphabetic characters, false otherwise.</returns>
        public static bool IsAlpha(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(ch => char.IsLetter(ch));
        }
    }
}

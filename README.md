# Description

The StringExtensions class is a collection of extension methods for the string type in C#. 

These methods provide additional functionality for manipulating and querying string values.

### Tests
The StringExtensions.Test project includes unit tests for these extension methods using xUnit and FluentAssertions.

The following methods are include

### Methods

The following methods are included in the StringExtensions class:

* **Capitalize**: This method capitalizes the first character of a string.
* **Count**: This method counts the number of occurrences of a specified character in a string.
* **IsAllNum**: This method determines whether a string consists only of numeric characters.
* **IsASCII**: This method determines whether a string consists only of ASCII characters.
* **IsUTF8**: This method determines whether a string is encoded in UTF-8 format.
* **IsUTF16**: This method determines whether a string is encoded in UTF-16 format.
* **IsDecimal**: This method determines whether a string represents a valid decimal number.
* **IsDigit**: This method determines whether a string consists only of digits.
* **IsIdentifier**: This method determines whether a string is a valid identifier.
* **IsLower**: This method determines whether a string consists only of lowercase characters.
* **IsUpper**: This method determines whether a string consists only of uppercase characters.
* **ToJson**: This method generates a JSON string from a source string with the format "key:value|Key:value".
* **Reverse**: This method reverses the order of the characters in a string.
* **IsAlpha**: This method determines whether a string consists only of alphabetic characters
### Usage

To use these extension methods, simply call them on any string value like this:

````csharp
string input = "hello";
string output = input.Capitalize();
````

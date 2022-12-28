# Description

#### StringExtensions

The StringExtensions project is a collection of extension methods for the string class in C#. These methods provide additional functionality for working with strings, 

such as capitalizing the first letter, converting the string to lowercase, counting the number of occurrences of a specific character, and checking the encoding of the string.

#### ArrayExtensions
The ArrayExtensions project is a collection of extension methods for arrays in C#. These methods provide additional functionality for 

working with arrays, such as appending elements, clearing the array, counting the number of occurrences of a specific element, finding the index of an element, 

inserting an element at a specific index, and reversing the order of the elements in the array.

### Tests
Both projects have corresponding unit tests projects, these unit tests for these extension methods using xUnit and FluentAssertions.

### Methods

The following methods are included in the **StringExtensions** class:

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
* **ToInt16**: This method converts a string to an int16 value
* **ToInt32**: This method converts a string to an int32 value
* **ToInt64**: This method converts a string to an int64 value
* **ToDecimal**: This method converts a string to an decimal value
* **ToFloat**: This method converts a string to an float value
* **ToBoolean**: This method converts a string to an boolean value
* **ExtractQuotedText**: This method extracts the text inside a quote inside a string.

The following methods are included in the **ArrayExtensions** class:

* **Append**: Adds one or more elements to the end of an array.
* **Clear**: Removes all elements from an array.
* **Count**: Counts the number of occurrences of a specific element in an array.
* **Index**: Returns the index of a specific element in an array.
* **Insert**: Inserts an element at a specific index in an array.
* **Revert**: Reverses the order of the elements in an array.
* **Remove**: Removes all occurrences of a specific element from an array.

### Usage

To use these extension methods, simply call them on any string value like this:

````csharp
string input = "hello";
string output = input.Capitalize();

// Result: Hello
````

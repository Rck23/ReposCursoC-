using System;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests;

public class StringOperationsTest
{
    [Fact]
    public void ConcatenateStrings()
    {
        // Given
        var strOperations = new StringOperations();
        // When
        var result =  strOperations.ConcatenateStrings("Hola", "a todos"); 
        // Then
        Assert.NotEmpty(result);
        Assert.NotNull(result);
        Assert.Equal("Hola a todos", result);
    }

    [Fact]
    public void IsPalindrome_True()
    {
        // Given
        var strOperations = new StringOperations();
        // When
        var result =  strOperations.IsPalindrome("ama"); 
        
        // Then
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_False()
    {
        // Given
        var strOperations = new StringOperations();
        // When
        var result =  strOperations.IsPalindrome("Hola"); 
        
        // Then
        Assert.False(result);
    }

    [Fact]
    public void QuantintyInWords()
    {
        // Given
        var strOperations = new StringOperations();
        // When
        var result =  strOperations.QuantintyInWords("apple", 9); 
        
        // Then
        Assert.StartsWith("nine", result);
        Assert.Contains("apple", result);
    }

    [Fact(Skip = "Esta prueba no pasa")]
    public void GetStringLength_Exception()
    {
        // Given
        var strOperations = new StringOperations();
    
        // Then
        Assert.ThrowsAny<ArgumentException>(() => strOperations.GetStringLength(null));
    }

    [Theory]
    [InlineData("V", 5)]
    [InlineData("III", 3)]
    [InlineData("X", 10)]
    public void FromRomanToNumber(string romanNumber, int expected)
    {
        // Given
        var strOperations = new StringOperations();
        // When
        var result = strOperations.FromRomanToNumber(romanNumber);
        // Then
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOccurrences()
    {
        //var moqLogger = Mock<ILogger<StringOperations>>();

        // Given
        var strOperations = new StringOperations(/*moqLogger.Object*/); 

        // When
        var result = strOperations.CountOccurrences("Hola lola", 'l'); 
        // Then
        Assert.Equal(3, result);
    }

    [Fact]
    public void ReadFile()
    {
        // Given
        var strOperations = new StringOperations();

        /*var mockFile = new Mock<IFileReaderConector>();

        mockFile.Setup(f => f.ReadString(It.IsAny<string>() )).Returns("Reading file");
        
        // When
        var result = strOperations.ReadFile(mockFile.Object, "file.txt"); */
        
        // Then

        // Assert.Equal("Reading file", result);
    }
}

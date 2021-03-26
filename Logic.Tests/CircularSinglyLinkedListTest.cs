using System;
using System.Collections.Generic;
using Xunit;

namespace Logic.Tests
{
    public class CircularSinglyLinkedListTest
    {
        [Fact]
        public void Test_Add()
        {
            // Arrange
            var list = new SinglyLinkedList<string>();
            list.Add("Foo");
            list.Add("Bar");
            list.Add("Baz");
            
            // Act
            var ls = list.ToList();

            // Assert
            Assert.Equal(new List<string> { "Baz", "Bar", "Foo"}, ls);
        }
        
        [Fact]
        public void Test_RemoveAll()
        {
            // Arrange
            var list = new SinglyLinkedList<string>();
            list.Add("Foo");
            list.Add("Bar");
            list.Add("Baz");
            
            // Act
            list.RemoveAll();

            // Assert
            Assert.Equal(0, list.Size);
            Assert.True(list.IsEmpty());
        }
        
        [Fact]
        public void Test_Remove_Beginning()
        {
            // Arrange
            var list = new SinglyLinkedList<string>();
            list.Add("Foo");
            list.Add("Bar");
            list.Add("Baz");
            
            // Act
            list.Remove("Foo");

            // Assert
            Assert.Equal(new List<string> { "Baz", "Bar"}, list.ToList());
        }
        
        [Fact]
        public void Test_Remove_End()
        {
            // Arrange
            var list = new SinglyLinkedList<string>();
            list.Add("Foo");
            list.Add("Bar");
            list.Add("Baz");
            
            // Act
            list.Remove("Baz");

            // Assert
            Assert.Equal(new List<string> { "Bar", "Foo"}, list.ToList());
        }
        
        [Fact]
        public void Test_Remove_Middle()
        {
            // Arrange
            var list = new SinglyLinkedList<string>();
            list.Add("Foo");
            list.Add("Bar");
            list.Add("Baz");
            
            // Act
            list.Remove("Bar");

            // Assert
            Assert.Equal(new List<string> { "Baz", "Foo"}, list.ToList());
        }
        
        [Fact]
        public void Test_Remove_Nothing()
        {
            // Arrange
            var list = new SinglyLinkedList<string>();

            // Act
            list.Remove("hello");

            // Assert
            Assert.Equal(new List<string>(), list.ToList());
        }
    }
}
using System;
using Logic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoublyLinkedList<int> ls = new DoublyLinkedList<int>();
            ls.Add(1);
            ls.Add(2);
            ls.Add(3);
            ls.Add(5);
            Console.WriteLine(ls.ToString());
            ls.Remove(3);
            Console.WriteLine(ls.ToString());
            ls.Add(9);
            Console.WriteLine(ls.ToString());
            ls.Remove(1);
            Console.WriteLine(ls.ToString());
        }
    }
}
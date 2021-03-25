using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface ILinkedList<T>
    {
        public int Size { get; }

        public void Add(T value);
        
        public void Remove(T value);
        
        public void RemoveAll();
        
        public bool IsEmpty();

        public List<T> ToList();
    }
}
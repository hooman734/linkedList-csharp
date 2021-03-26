using System.Collections.Generic;
using Logic.Interfaces;

namespace Logic
{
    internal class CircularSinglyNode<T>
    {
        public CircularSinglyNode<T> Next { get; set; }
        public T Value { get; set; }
    }

    public class CircularSinglyLinkedList<T> : ILinkedList<T>
    {
        private CircularSinglyNode<T> _head;

        public override string ToString()
        {
            var response = "HEAD";
            var iter = _head;

            do
            {
                response = string.Join(" -@-> ", response, iter.Value);
                iter = iter.Next;
            } while (iter != _head);
            return response;
        }

        public int Size { get; private set;  }
        
        public void Add(T value)
        {
            var newItem = new CircularSinglyNode<T>
            {
                Value = value,
                Next = _head.Next ?? _head,
            };
            _head.Next = newItem;
            Size++;
        }

        public void Remove(T value)
        {
            if (_head == null)
            {
                // Do nothing
            }
            else if (_head.Next == null)
            {
                _head = null;
                Size = 0;
            }
            else if (_head.Value.Equals(value))
            {
                var iter = _head.Next;
                var prev = _head;
                do
                {
                    if (iter.Value.Equals(value))
                    {
                        prev.Next = iter.Next;
                    }

                    prev = iter;
                    iter = iter.Next;
                }
                while (iter != _head.Next) ;
                _head = _head.Next;
                Size--;
            }
            else
            {
                var iter = _head;
                CircularSinglyNode<T> prev = null;
                do
                {
                    if (iter.Value.Equals(value))
                    {
                        prev.Next = iter.Next;
                    }

                    prev = iter;
                    iter = iter.Next;
                }
                while (iter != _head) ;
                
                Size--;
            }
        }

        public void RemoveAll()
        {
            _head = null;
            Size = 0;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            var iter = _head;
            while (iter != null)
            {
                list.Add(iter.Value);
                iter = iter.Next;
            }

            return list;
        }
    }
}
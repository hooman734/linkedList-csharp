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
            while (iter != null)
            {
                response = string.Join(" -> ",response,  iter.Value);
                iter = iter.Next as CircularSinglyNode<T>;
            }
            return response;
        }

        public int Size { get; private set;  }
        
        public void Add(T value)
        {
            var newItem = new CircularSinglyNode<T>
            {
                Value = value,
                Next = _head
            };
            _head = newItem;
            Size++;
        }

        public void Remove(T value)
        {
            if (_head == null)
            {
                // Do nothing
            }
            else if (_head.Value.Equals(value))
            {
                _head = _head.Next;
                Size--;
            }
            else
            {
                var iter = _head;
                CircularSinglyNode<T> prev = null;
                while (iter != null)
                {
                    if (iter.Value.Equals(value))
                    {
                        prev.Next = iter.Next;
                    }

                    prev = iter;
                    iter = iter.Next;
                }
                
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
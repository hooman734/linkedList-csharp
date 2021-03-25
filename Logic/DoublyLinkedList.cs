using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Interfaces;

namespace Logic
{
    internal class DoublyNode<T>
    {
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
        public T Value { get; set; }
    }

    public class DoublyLinkedList<T> : ILinkedList<T>
    {
        private DoublyNode<T> _head;
        
        public override string ToString()
        {
            var response = string.Empty;
            var iter = _head;
            while (iter != null)
            {
                response = string.Join(" <-> ",response,  iter.Value);
                iter = iter.Next;
            }
            return response;
        }

        public int Size { get; private set;  }
        
        public void Add(T value)
        {
            var newItem = new DoublyNode<T>
            {
                Value = value,
                Next = _head,
                Previous = null
            };
            if (_head == null)
            {
                _head = newItem;
            }
            else
            {
                _head.Previous = newItem;
                _head = newItem;
            }

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
                _head.Previous = null;
                Size--;
            }
            else
            {
                var iter = _head;
                DoublyNode<T> prev = null;
                while (iter != null)
                {
                    if (iter.Value.Equals(value))
                    {
                        prev.Next = iter.Next;
                        iter.Next.Previous = prev;
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
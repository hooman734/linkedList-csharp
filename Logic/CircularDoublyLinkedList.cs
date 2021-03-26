using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Interfaces;


namespace Logic
{
    internal class CircularDoublyNode<T>
    {
        public CircularDoublyNode<T> Previous { get; set; }
        public CircularDoublyNode<T> Next { get; set; }
        public T Value { get; set; }
    }

    public class CircularDoublyLinkedList<T> : ILinkedList<T>
    {
        private DoublyNode<T> _head;
        
        public override string ToString()
        {
            var response = "HEAD";
            var iter = _head;
            while (iter != null)
            {
                response = string.Join(" <-> ",response,  iter.Value);
                iter = iter.Next;
            }
            return response;
        }

        public int Size { get; private set; }
        
        public void Add(T value)
        {
            var newItem = new DoublyNode<T>
            {
                Value = value,
                Next = _head,
                Previous = _head.Previous ?? _head
            };
            if (_head == null)
            {
                _head = newItem;
            }
            else
            {
                _head.Next = newItem;
                if (_head.Previous != null) _head.Previous.Next = newItem;
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
                if (_head.Previous != null) _head.Previous.Next = _head.Next;
                if (_head.Next != null) _head.Next.Previous = _head.Previous;
                Size--;
            }
            else
            {
                var iter = _head;
                DoublyNode<T> prev = null;
                do
                {
                    if (iter != null && iter.Value.Equals(value))
                    {
                        if (prev != null)
                        {
                            prev.Next = iter.Next;
                            if (iter.Next != null) iter.Next.Previous = prev;
                        }
                    }

                    prev = iter;
                    iter = iter?.Next;
                } while (iter != _head);
                
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
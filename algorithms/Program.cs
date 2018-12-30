using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;
using System.Runtime.InteropServices;

namespace algorithms
{




    public class node
    {
        public Object value
        {
            get

; set

;
        }
        public node next { get; set; }
    }

    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }


    }


    public class LinkedList<T> : ICollection<T>
    {



        public LinkedListNode<T> Head
        {
            get;

            private set;
        }

        public LinkedListNode<T> Tail
        {
            get;

            private set;

        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            { return false; }
        }

        int ICollection<T>.Count { get; }

        bool ICollection<T>.IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            AddtoHead(new LinkedListNode<T>(item));
        }

        public void AddtoHead(LinkedListNode<T> linkedListnode)
        {

            LinkedListNode<T> CurrentNode = Head;
            Head = linkedListnode;
            Head.Next = CurrentNode;
            if (CurrentNode == null)
            {
                Tail = Head;
            }
            else if (CurrentNode.Next == null)
            {
                Tail = CurrentNode;

            }
            Count++;
        }
        public void AddtoTail(LinkedListNode<T> linkedListNode)
        {
            Tail.Next = linkedListNode;
            Tail = linkedListNode;
            Tail.Next = null;
            Count++;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Head = null;
                Tail = null;
                Count = 0;
            }
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count > 0)
            {
                LinkedListNode<T> current = Head;
                while (current != null)
                {
                    array[arrayIndex] = current.Value;
                    arrayIndex++;
                    current = current.Next;
                }

            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {

            LinkedListNode<T> current = Head;
            if (Count == 0)
            {
                yield return current.Value;
            }
            else
            {
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }
        }




        void ICollection<T>.Add(T item)
        {
            AddtoHead(new LinkedListNode<T>(item));
        }

        void ICollection<T>.Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        bool ICollection<T>.Contains(T item)
        {
            if (Count == 0)
                return false;
            else
            {
                LinkedListNode<T> current = Head;
                while (current.Next != null)
                {
                    if (current.Value.Equals(item))
                        return true;
                    else
                        current = current.Next;

                }
                return false;
            }
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            if (Count == 0)
                yield return Head.Value;
            else
            {
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;

                }
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> Current = Head;
            //LinkedListNode<T> Next ;
            LinkedListNode<T> Previous = null;

            while (Current != null)
            {


                if (Current.Value.Equals(item))
                {

                    if (Current == Head)
                    {
                        Head = Current.Next;
                        Count--;
                        break;
                    }

                    else

                        //previous item should be pointing to current.next
                        Previous.Next = Current.Next;

                    if (Current.Next == null)
                    {
                        Tail = Previous;
                    }
                    Current.Next = null;
                    Current.Value = default(T);

                    Count--;
                    break;
                }
                else
                {
                    Previous = Current;
                }

                //make previous item as current as current is going to point next item



                //point current to next
                Current = Previous.Next;


            }
            return true;
        }



    }

    public class DoublyLinkedListNode<T>
    {

        public T Value { get; set; }
        public DoublyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public DoublyLinkedListNode<T> Previous { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

    }

    public class DoublyLinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        public int Count { get; private set; }

        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }
        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            AddToHead(new DoublyLinkedListNode<T>(item));
        }

        public void AddToHead(DoublyLinkedListNode<T> doublyLinkedListNode)
        {
            if (Count == 0)
            {
                Head = doublyLinkedListNode;
                Tail = Head;
            }

            else
            {
                DoublyLinkedListNode<T> Current = Head;
                Head = doublyLinkedListNode;
                Head.Previous = null;
                Head.Next = Current;
                Current.Previous = Head;
            }

            Count++;

        }

        public void Clear()
        {

            if (Count > 0)
            {
                DoublyLinkedListNode<T> Current = Head.Next;
                Head = null;
                Head.Next = null;
                Tail = null;
                Tail.Previous = null;
                while (Current.Next != null)
                {

                    Current.Previous = null;

                    Current = Current.Next;

                }
                Count = 0;
            }
        }

        public bool Contains(T item)
        {
            var v = new DoublyLinkedListNode<T>(item);
            DoublyLinkedListNode<T> Current = Head;

            while (Current != null)
            {
                if (Current == v)
                    return true;
                Current = Current.Next;

            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (Count > 0)
            {
                DoublyLinkedListNode<T> current = Head;
                DoublyLinkedListNode<T> previous = null;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        if (current.Previous == null)
                        {
                            Head = Head.Next;
                            Head.Previous = null;

                        }
                        else
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                            current.Next = null;
                            current.Previous = null;

                        }

                    }
                    current = current.Next;
                }
            }
            return false;
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class Stack_LinkedList<T> : IEnumerable<T>
    {
        //pop, peek and clear,push

        private System.Collections.Generic.LinkedList<T> items = new System.Collections.Generic.LinkedList<T>();

        int Count { get { return items.Count; } }

        public void push(T item)
        {
            items.AddFirst(item);
        }

        public T pop()
        {

            T value = items.First.Value;
            items.RemoveFirst();
            return value;
        }
        public T Peek()
        {
            return items.First.Value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }

    public class Stack_Array<T> : IEnumerable<T>
    {

        private T[] items = new T[0];
        int size;
        public void Push(T item)
        {
            //size=items.length means array items has reached upperbound limit
            if (size == items.Length)
            {
                int newlength = size == 0 ? 4 : size * 2;
                //initial length =4 otherwise double the existing length
                T[] newArray = new T[newlength];
                items.CopyTo(newArray, 0);


                items = newArray;
            }

            items[size] = item;
            size++;

        }
        public T Pop()
        {
            // size = items.Length;
            var removeditem = items[size - 1];

            items[size - 1] = default(T);
            size--;
            return removeditem;
        }

        public T Peek()
        {

            return items[size - 1];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            size = items.Length;

            for (int i = 0; i < size; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }


    public class Queue_linkedlist<T>
    {
        private System.Collections.Generic.LinkedList<T> values = new System.Collections.Generic.LinkedList<T>();
        public void Enqueue(T item)
        {
            values.AddLast(item);
        }
        public T Dequeue()
        {
            var firstitem = values.First;
            values.RemoveFirst();
            return firstitem.Value;
        }

    }

    public class Queue_array<T>
    {
        private T[] items = new T[0];

        int _size = 0;

        int _head=0;//first one
        int _tail=-1;//newest one


        public void Enqueue(T item)
        {


            if (_size == items.Length)
            {
                int newlength = _size == 0 ? 4 : _size * 2;
                T[] newArray = new T[newlength];

                if (_tail > _head)
                {


                    int targetindex = 0;
                    //copy head to tail to newarray
                    for (targetindex = _head; targetindex <=_tail; targetindex++)
                    {
                        newArray[targetindex] = items[targetindex];
                    }


                }
                else
                {
                    int targetindex = 0;
                    //copy head to items end to new array
                    for (int i  = _head; i<items.Length; i++)
                    {
                        newArray[targetindex] = items[i];
                        targetindex++;
                    }
                    //copy start of items to tail to new array
                    for(int i=0;i<=_tail;i++)
                    {
                        newArray[targetindex] = items[i];
                        targetindex++;
                    }

                    _head = 0;
                    _tail = items.Length-1;
                    items = newArray;

                }


                _head = 0;
                _tail = items.Length - 1;
                items = newArray;


            }
            //items = _size == 0 ? new T[4] : new T[_size * 2];
            if (_tail == items.Length - 1)
                _tail = 0;
            else
                _tail++;
            items[_tail] = item;
           
            _size++;
        }
        public T DeQueue()
        {
            
            var ditem = items[_head];
            items[_head] = default(T);
            _size--;
            _head++;
            return ditem;

        }
         
    }


    public class PriorityQueue<T> where T: IComparable<T>
    {

        private System.Collections.Generic.LinkedList<T> items = new System.Collections.Generic.LinkedList<T>();

        public void Enqueue(T item)
        {
            if (items.Count == 0)
                items.AddLast(item);
            else
            {
                var current = items.First;
                while (current!=null &&current.Value.CompareTo(item)>0)
                {
                    current = current.Next;

                }
                if (current == null)
                    //end of list is reached
                    items.AddLast(item);
                else
                    items.AddBefore(current,item);
            }
               
             
            
        }
        public T Dequeue()
        {
            var first = items.First;
            items.RemoveFirst();
            return first.Value;
        }

    }
    

    class Program
    {
        
        static void Main(string[] args)
        {

            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(8);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(7);
            var firstval = priorityQueue.Dequeue();


            Queue_array<int> testqueue = new Queue_array<int>();
            testqueue.Enqueue(4);
            testqueue.Enqueue(7);
            testqueue.Enqueue(9);
            testqueue.Enqueue(10);
            testqueue.Enqueue(11);

            var chk1 = testqueue.DeQueue();
            var chk2 = testqueue.DeQueue();
            testqueue.Enqueue(13);
            testqueue.Enqueue(15);
            Console.ReadLine();
            //LinkedList<int> vs = new LinkedList<int>();
            //vs.Add(3);
            //vs.Add(4);
            //vs.Add(6);
            //vs.Add(7);
            //foreach (var i in vs)
            //{
            //    Console.WriteLine(i);
            //}
            //vs.Remove(7);

            //DoublyLinkedList<int> ds = new DoublyLinkedList<int>();
            //ds.Add(1);
            //ds.Add(4);
            //ds.Add(5);
            //ds.Remove(4);


            //Stack_Array<int> st = new Stack_Array<int>();
            //st.Push(1);
            //st.Push(5);   
            //st.Push(2);
            //st.Pop();
            //var x=st.Peek();

            //    Stack_LinkedList<int> ts = new Stack_LinkedList<int>();
            //ts.push(3);
            //ts.push(4);
            //ts.push(2);

            //Stack<int> sts = new Stack<int>();
            //sts.Push(4);
            //sts.Push(2);
            //sts.Push(3);
            //sts.Pop();


        }
    }
}

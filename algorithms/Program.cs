using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace algorithms
{

    public  class node
    {
        public  Object value { get
                
                ; set
                
                ; }
      public   node next { get; set; }
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


    public class LinkedList<T>:ICollection<T>{



        public LinkedListNode<T> Head {
            get;

          private  set;
        }

        public LinkedListNode<T> Tail {
            get;

           private set;

        }

        public int Count { get; private set; }

        public bool IsReadOnly { get
            { return false; } }

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
            if (CurrentNode==null)
            {
                Tail=Head;
            }
            else if (CurrentNode.Next==null)
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
            if(Count>0)
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
                while (current!=null)
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
            LinkedListNode<T> Previous=null;
            
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

    public class DoublyLinkedListNode<T> {

       public T Value { get; set; }
        public DoublyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public DoublyLinkedListNode<T> Previous { get;  set; }
        public DoublyLinkedListNode<T> Next { get;  set; }

        }

    public class DoublyLinkedList<T> :IEnumerable<T>,ICollection<T>
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

            else {
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




    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");




            LinkedList<int> vs = new LinkedList<int>();
            vs.Add(3);
            vs.Add(4);
            vs.Add(6);
            vs.Add(7);
            foreach (var i in vs)
            {
                Console.WriteLine(i);
            }
            vs.Remove(7);

            DoublyLinkedList<int> ds = new DoublyLinkedList<int>();
            ds.Add(1);
            ds.Add(4);
            ds.Add(5);
            ds.Remove(4);
            Console.ReadLine();

        }
    }
}

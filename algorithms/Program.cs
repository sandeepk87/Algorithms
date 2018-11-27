using System;
using System.Collections;
using System.Collections.Generic;
namespace algorithms
{

    public  class node
    {
        public  Object value { get
                
                ; set
                
                ; }
      public   node next { get; set; }
    }

    public  class LinkedList<T> {

       

        public node Head { get; set;
        }

        public node Tail {
            get;

            set;

        }

        public node LinkedListnode {
            get;
            set;
        }
       
 
        public void AddtoHead(node Node)
        {
            
            node CurrentNode = Head;
            Head = Node;
            Head.next = CurrentNode;
            
        }
        public void AddtoTail(node Node)
        {
            Tail.next = Node;
            Tail = Node;
            Tail.next = null;
            
        }

        public IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {

            node current = Head;
            while (current.value != null)
            {
                yield return current.value;
                current = current.next;
            }

        }
      
       
    }

    public class LinkedListOps
    {

        public void Addtolinkedlist(node node) {

            Console.WriteLine("Add to Head or Tail type H or T");
            var x = Console.ReadLine();
            if (x == "H")
            {
                //add to Head

              
            }
        }

   
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

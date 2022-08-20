using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Diagnostics;
using algorithms.CodingProblems;
using algorithms.CodingProblems.Sorting;

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

    public class TreeNode<T> : IComparable<T> where T: IComparable<T>
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        public T Value;
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
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

        public void Reverse() {

            LinkedListNode<T> current = Head;
          
            var currentHead = Head;
            LinkedListNode<T> prev = null;
            LinkedListNode<T> next = null;
            while(current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
            Tail = currentHead;
        
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

        int _head = 0;//first one
        int _tail = -1;//newest one


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
                    for (targetindex = _head; targetindex <= _tail; targetindex++)
                    {
                        newArray[targetindex] = items[targetindex];
                    }


                }
                else
                {
                    int targetindex = 0;
                    //copy head to items end to new array
                    for (int i = _head; i < items.Length; i++)
                    {
                        newArray[targetindex] = items[i];
                        targetindex++;
                    }
                    //copy start of items to tail to new array
                    for (int i = 0; i <= _tail; i++)
                    {
                        newArray[targetindex] = items[i];
                        targetindex++;
                    }

                    _head = 0;
                    _tail = items.Length - 1;
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


    public class PriorityQueue<T> where T : IComparable<T>
    {

        private System.Collections.Generic.LinkedList<T> items = new System.Collections.Generic.LinkedList<T>();

        public void Enqueue(T item)
        {
            if (items.Count == 0)
                items.AddLast(item);
            else
            {
                var current = items.First;
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;

                }
                if (current == null)
                    //end of list is reached
                    items.AddLast(item);
                else
                    items.AddBefore(current, item);
            }



        }
        public T Dequeue()
        {
            var first = items.First;
            items.RemoveFirst();
            return first.Value;
        }

    }


    public class sanlookup
    {
        // private KeyValuePair<string,string> keyValuePairs;
        private static Dictionary<string, List<KeyValuePair<string, string>>> data;
        // private HashSet<KeyValuePair<string,string>> keys;
        //  private static string[] keys=new string[0];
        // private int keycount;
        static sanlookup()
        {
            data = new Dictionary<string, List<KeyValuePair<string, string>>>();
            // keycount = 0;
        }
        public void Add(string key, KeyValuePair<string, string> valuePair)
        {
            if (data.ContainsKey(key))
            {
                data[key].Add(valuePair);
            }
            else
            {
                //if (keys.Count() == keycount)
                //{
                //    int newcount = keycount == 0 ? 4 : keycount * 4;
                //    string[] newkeys = new string[newcount];
                //    keys.CopyTo(newkeys, 0);
                //    keys = newkeys;

                //}
                //keys[keycount] = key;
                //keycount++;
                data.Add(key, new List<KeyValuePair<string, string>>() { valuePair });

            }


        }

        public List<KeyValuePair<string, string>> this[string key]
        {
            get { return data[key]; }

        }


    }


    public class BinaryTree<T> where T: IComparable<T>
    {
        public int _count;

        public TreeNode<T> Head;

    public void Add(T val)
        {
            if (Head == null)
                Head=new TreeNode<T>(val);
            else
            {
                AddToTree(Head,val);

            }
            _count++;
        }


       
        void AddToTree(TreeNode<T> treeNode,T val)
        {
            //value less than Node
            if (val.CompareTo(treeNode.Value) < 0)
            {
                //there is no left node ,hence add to left node
                if (treeNode.Left == null)
                {
                    treeNode.Left = new TreeNode<T>(val);

                }
                    
                else
                {
                    //Add recursively to next left node
                    AddToTree(treeNode.Left, val);
                }
            }
            else
            {
                if (treeNode.Right == null)
                {
                    //no right node hence add to rightnode
                    treeNode.Right = new TreeNode<T>(val);
                }
                else
                {
                    AddToTree(treeNode.Right, val);
                }
            }
        }

        public bool Contains(T value)
        {
            TreeNode<T> ParentTreeNode;
            return   FindWithParent(value, out ParentTreeNode) != null;
        }

        private TreeNode<T> FindWithParent(T Value, out TreeNode<T> ParentNode)
        {
            TreeNode<T> current = Head;
            ParentNode = null;
            while(current != null) {
                int result = current.CompareTo(Value);
                if (result > 0)
                {
                    ParentNode = current;
                    current = current.Left;
                }
                else if(result <0)
                {
                    ParentNode = current;
                    current = current.Right;

                }
                else { break; }
            }



            return current;
        }

        public bool Remove(T value)
        {
            if (!Contains(value))
                return false;
            
                TreeNode<T> ParentNode = null;
                TreeNode<T> RemovedNode = FindWithParent(value,out ParentNode);

              //case 1: Removed Node has no right child, means current node is replaced by left node.
            if(RemovedNode.Right==null)
            {
                if (ParentNode == null)
                {
                    Head = RemovedNode.Left;
            
                }
               
                else
                {
                    int result = ParentNode.CompareTo(RemovedNode.Value);
                    if (result > 0)
                    {
                        ParentNode.Left = RemovedNode.Left;
                    }
                    else
                    {
                        ParentNode.Right = RemovedNode.Left;
                    }
                  
                }
            }
            //case 2: RemovedNodes'right node has no left child, then removednode's right child replaces removednode.
           else if (RemovedNode.Right.Left == null)
            {
                RemovedNode.Right.Left = RemovedNode.Left;

                if (ParentNode == null)
                {
                    Head = RemovedNode.Right;
                  
                }

                else
                {
                    int result = ParentNode.CompareTo(RemovedNode.Value);
                    if (result > 0)
                    {
                        ParentNode.Left = RemovedNode.Right;
                    }
                    else
                    {
                        ParentNode.Right = RemovedNode.Right;
                    }
                  
                }
            }

            //case 3: Removed Node's right node has left child, then removednode's right child's left most child replaces removed node.
            else {
                //find Right's left most child.
                var leftMost = RemovedNode.Right.Left;
                var leftMostParent = RemovedNode.Right;
                while (leftMost != null)
                {
                    
                    leftMost = leftMost.Left;
                    leftMostParent = leftMost;
                }

                //leftmostparent's left subtree=left most right subtree. as left most is moved

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = RemovedNode.Left;
                leftMost.Right = RemovedNode.Right;
                if (ParentNode == null)
                {
                    Head = leftMost;
                }

                else {
                    int result = ParentNode.CompareTo(RemovedNode.Value);
                    if (result < 0)
                    {
                        ParentNode.Left = leftMost;
                    }
                    else
                    {
                        ParentNode.Right = leftMost;
                    }

                }
            }
            _count--;
            return true;
        }


        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, Head);
        }

        private void PreOrderTraversal(Action<T> action, TreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action,node.Left);
                PreOrderTraversal(action,node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            var node = Head;
            PostOrderTraversal(action, node);   
        }
        private void PostOrderTraversal(Action<T> action, TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                PostOrderTraversal(action, treeNode.Left);
                PostOrderTraversal(action, treeNode.Right);
                action(treeNode.Value);
            }
        }
        public IEnumerable<T> PreOrderTraverse()
        {
            var current = Head;
            Stack<TreeNode<T>> node_stack = new Stack<TreeNode<T>>();
          node_stack.Push(current);
            while (node_stack.Count >0)
            {
                //first pop and return existing value in stack
                //then push left and right value onto stack then repeat same
                current = node_stack.Pop();
                yield return current.Value;
                
                if (current.Right != null)
                {
                    
                    node_stack.Push(current.Right);

                }
                   if(current.Left!=null)
                {
                   
                    node_stack.Push(current.Left);
                }

                
            }
            
        }


        public IEnumerable<T> PostOrderTraverse()
        {
            TreeNode<T> current = Head;
            Stack<TreeNode<T>> node_stack = new Stack<TreeNode<T>>();
            node_stack.Push(current);

            ////if (current.Right != null)
            ////{
            ////    node_stack.Push(current.Right);
            ////    node_stack.Push(current);
            ////    current = current.Left;
            ////}
              
            //first reach the left most node and display it
            //then check

            bool ascend = true;
            var last = current;
            
            while (node_stack.Any())
            {
                if (current == null)
                {
                    last = node_stack.Peek();
                    
                    node_stack.Pop();


                    if (last.Right == null)
                    {

                        yield return last.Value;
                        current = null;
                    }

                    else
                    {
                        if (node_stack.Count < 1)
                            break;
                        if (last.Right == node_stack.Peek())
                        {
                            node_stack.Pop();
                            node_stack.Push(last);
                            current = last.Right;

                        }
                        else
                        {
                            yield return last.Value;
                            
                        }

                    }
                }


              else  if (current.Right != null)
                {
                    node_stack.Push(current.Right);
                    node_stack.Push(current);
                    current = current == null ? null : current.Left;
                }
                else 
                {
                    node_stack.Push(current);
                    current = current == null ? null : current.Left;
                }

                
            }

        }
    }
    class Program
    {
       
        public static void Test(int x)
        {
          
            Console.WriteLine(x);
        }
        static void Main(string[] args)
        {

            var inputnumbers = new int[] { 2, 45, 10, 5, 7, 3 ,8,1};

            var sorted = RandomQuickSort.Sort(inputnumbers);

             sorted = QuickSort.Sort(inputnumbers);

             sorted = MergeSort.Sort(inputnumbers);
            foreach(var val in sorted)
            {
                Console.WriteLine(val);
            }


            var decodeStringCreator = DecodeString.DecodeStr("3[a2[c]]");
            Console.WriteLine(decodeStringCreator);

            var decodeStringCreator2 = DecodeString.Decode("12[abb]");
            Console.WriteLine(decodeStringCreator);

            Console.WriteLine("----Simple LInked List");
            LinkedList<int> vs = new LinkedList<int>();
            vs.Add(3);
            vs.Add(4);
            vs.Add(6);
            vs.Add(7);
            foreach (var i in vs)
            {
                Console.WriteLine(i);
            }
            //  vs.Remove(7);


            Console.WriteLine("Reversed List");
            vs.Reverse();

            foreach (var i in vs)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("Double Linked List");

            DoublyLinkedList<int> ds = new DoublyLinkedList<int>();
            ds.Add(1);
            ds.Add(4);
            ds.Add(5);
            ds.Remove(4);


            Console.WriteLine("Binary Tree starts");
            Console.WriteLine("-------------------");
            //Console.ReadKey();

            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(10);


            binaryTree.Add(7);
            binaryTree.Add(4);

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(5);
            
            binaryTree.Add(6);
            binaryTree.Add(9);
            binaryTree.Add(1);
           
            binaryTree.Remove(9);
            binaryTree.Add(17);
            binaryTree.Add(14);
            binaryTree.Add(24);

            binaryTree.Add(12);
            binaryTree.Add(16);
            binaryTree.Add(20);
            binaryTree.Add(30);
            binaryTree.Add(13);
            var a = binaryTree.Contains(8);
            List<int> tests = new List<int>();
            var ff=binaryTree.Contains(6);
            tests.Add(1);
            tests.Add(4);
            binaryTree.PostOrderTraversal(Test);
            var ss=binaryTree.PostOrderTraverse().ToList();
           binaryTree.PreOrderTraversal(Test);
            
       var oupt=     binaryTree.PreOrderTraverse().ToList();
            binaryTree.PostOrderTraversal(Test);
            Console.WriteLine()
                ;

            


            /*
            string s = "[\r\n{\r\n                name: \"san1\",\r\nvalue: \"dds1\",\r\nplace:\"hyd\"\r\n},\r\n{\r\n                name: \"san1\",\r\nvalue: \"dds2\",\r\nplace:\"ban\"\r\n},\r\n{\r\n                name: \"san3\",\r\nvalue: \"dds3\",\r\nplace:\"bel\"\r\n},\r\n{\r\n                name: \"san4\",\r\nvalue: \"dds4\",\r\nplace:\"mos\"\r\n}]";
            JArray jArray = JArray.Parse(s);

            HashSet<Dictionary<string, string>> keyValues = new HashSet<Dictionary<string, string>>();
            keyValues.Add(new Dictionary<string, string>() { { "car", "mercedes" } });
            keyValues.Add(new Dictionary<string, string>() { { "car", "bmw" } });
            keyValues.Add(new Dictionary<string, string>() { { "car", "toyota" } });
            keyValues.Add(new Dictionary<string, string>() { { "plane", "boeing" } });
            keyValues.Add(new Dictionary<string, string>() { { "plane", "airbus" } });
            keyValues.Add(new Dictionary<string, string>() { { "bus", "volvo" } });


            sanlookup _sanlookup = new sanlookup();
            var i = 10;
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for(int j=0;j<i;j++)
            foreach (var x in jArray)
            {
                _sanlookup.Add(x["name"].ToString(), new KeyValuePair<string, string>(x["value"].ToString(), x["place"].ToString()));
            }
            stop.Stop();
            Stopwatch st2 = new Stopwatch();

         
            st2.Start();
            ILookup<string, KeyValuePair<string, string>> vsl;
            for (int j = 0; j < i; j++)
           vsl =    jArray.ToLookup(a => a["name"].ToString(), b => new KeyValuePair<string, string>(b["value"].ToString(), b["place"].ToString()));
            st2.Stop();

            Stopwatch st3 = new Stopwatch();
            HashSet<Dictionary<string, KeyValuePair<string, string>>> dsk=new HashSet<Dictionary<string, KeyValuePair<string, string>>>();
            st3.Start();
            for (int j = 0; j < i; j++)
                foreach (var x in jArray)
            {
                    dsk.Add(new Dictionary<string, KeyValuePair<string, string>>() { { x["name"].ToString(), new KeyValuePair<string,string>(x["place"].ToString(), x["value"].ToString()) } });
            }
            st3.Stop();



            var f=_sanlookup["san1"];
          HashSet<JObject> tsh = new HashSet<JObject>();
            
            var df = tsh.Values("name");
            var mf=  tsh.GetHashCode();
            var st = tsh.Values();
            var arr = df.ToArray();

           
           // var ds=tsh.Values(JObject.FromObject())
            int  val = Convert.ToInt32(Console.ReadLine());

         
            int[] input = new int[2];
           
            for(int m=0;m<val;m++)
            {
                string valin = Console.ReadLine();
             string[] vsd=   valin.Split(" ");
                int N = Convert.ToInt32(vsd[0]);
                int K = Convert.ToInt32(vsd[1]);
            }


            */



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
            testqueue.Enqueue(16);
            testqueue.Enqueue(17);
            testqueue.Enqueue(18);
            testqueue.Enqueue(19);
       


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

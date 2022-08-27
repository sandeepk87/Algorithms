using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DataStructures
{
    public class Node
    {
        public string Value { get; set; }
        public Node Left { get; set; } = null;
        public Node Right { get; set; } = null;
        public Node(string value)
        {
            Value = value;
        }

    }
    public class Node<T> where T:struct
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;
        public Node(T value)
        {
            Value = value;
        }

    }
    public class BinaryTreeExample
    {
        
        public  Node Head;
        private Stack<Node> elements;
        public BinaryTreeExample()
        {
            Node a = new Node("a");
            Node b = new Node("b");
            Node c = new Node("c");
            Node d = new Node("d");
            Node e = new Node("e");
            Node f = new Node("f");
            Node g = new Node("g");
            Node h = new Node("h");
            Node i = new Node("i");
            Node j = new Node("j");
            Node k = new Node("k");
            Node l = new Node("l");
            Node m = new Node("m");
            Node n = new Node("n");
            Head = a;
            a.Left = b;
            a.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;
            c.Left = g;
            d.Left = h;
            d.Right = i;
            e.Left = k;
            e.Right = l;
            g.Left = m;
            g.Right = n;

            /***
             *                                a
                                       /             \
                                      /               \
                                     b                 c
                                    / \                /\
                                   /   \              /  \
                                  d      e           g    f
                                /  \    /  \        / \
                               /    \  /    \      /   \
                              h      i k     l     m    n
            **/


        }

        public string[] GetValues_DepthFirstPreOrder()
        {
            var result = new List<string>();
            if(Head == null)
            {
                return new string[] { };
            }
            elements = new Stack<Node>();
            elements.Push(Head);

            while(elements.Count != 0 && !string.IsNullOrEmpty(elements.Peek()?.Value))
            {
                var top = elements.Peek();
                elements.Pop();
                result.Add(top.Value);

                if(top.Right != null)
                {
                    elements.Push(top.Right);
                }
                if(top.Left != null)
                {
                    elements.Push(top.Left);
                }
            }

            return result.ToArray();
        }


        public void Print_DepthFirstPreOrder_WithStack()
        {
            var values = GetValues_DepthFirstPreOrder();
            foreach(var value in values) {
                Console.WriteLine(value);
            }
        }

        public string[] GetValues_DepthFirstPreOrder_WithRecursion(Node treeNode)
        {
            var values = new List<string>();
            if(treeNode != null)
            {
                values.Add(treeNode.Value);
                values.AddRange(GetValues_DepthFirstPreOrder_WithRecursion(treeNode.Left));
                values.AddRange(GetValues_DepthFirstPreOrder_WithRecursion(treeNode.Right));
            }

           

            return values.ToArray();

        }


        public string[] GetValues_BreadFirstPreOrder_WithQueue()
        {
            var listVals = new List<string>();
            var queue = new Queue<Node>();
            if (Head != null)
            {
                queue.Enqueue(Head);
            }
            while (queue.Count != 0)
            {
                var val = queue.Dequeue();
                listVals.Add(val.Value);
                if (val.Left != null)
                {
                    queue.Enqueue(val.Left);
                }
                if (val.Right != null)
                {
                    queue.Enqueue(val.Right);
                }
            }

            return listVals.ToArray();
        }

        public void Print_DepthFirstPreOrder_WithRecursion(Node treeNode)
        {
            //if(treeNode != null)
            //{
            //    Console.WriteLine(treeNode.Value);
            //}

            //if(treeNode.Left !=null)
            //Print_DepthFirstPreOrder_WithRecursion(treeNode.Left);


            //if (treeNode.Right != null)
            //    Print_DepthFirstPreOrder_WithRecursion(treeNode.Right);

            var values = GetValues_DepthFirstPreOrder_WithRecursion(treeNode);

            foreach(var value in values)
            {
                Console.WriteLine(value);
            }

        }


        public void Print_BreadthFirstPreOrder_WithQueue()
        {
            var values = GetValues_BreadFirstPreOrder_WithQueue();
            foreach(var value in values)
            {
                Console.WriteLine(value);
            }
        }


        public bool IncludesWithBreadthFirst(Node root,string target)
        {
            if(root == null)
            {
                return false;
            }

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count != 0)
            {
                var val = queue.Dequeue();
                if(val.Value == target)
                {
                    return true;
                }

                if (val.Left != null)
                {
                    queue.Enqueue(val.Left);
                }
                if (val.Right != null)
                {
                    queue.Enqueue(val.Right);
                }

            }
            return false;
        }


        public bool IncludesWithBreadthFirst_Recursive(Node root, string target)
        {
            if(root == null)
            {
                return false;
            }
            if(root.Value == target)
            {
                return true;
            }
            return IncludesWithBreadthFirst_Recursive(root.Left,target) || IncludesWithBreadthFirst_Recursive(root.Right,target);

        }



    }

    public class BinaryTreeIntExample
    {
        public Node<int> Root;
        public BinaryTreeIntExample()
        {
            Root = new Node<int>(3);
            var node11 = new Node<int>(11);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);
            var node9 = new Node<int>(9);
            var node20 = new Node<int>(20);
            var node6 = new Node<int>(6);

            Root.Left = node11;

            Root.Right = node2;
            node11.Left = node4;
            node11.Right = node5;
            node2.Left = node9;
            node2.Right = node20;
            node20.Left = node6;

            /*
             *                                 3    
             *                           /           \
             *                          /             \
             *                         11              2
             *                        /  \            /  \
             *                       /    \          /    \
             *                      4      5        9     20
             *                                           /
             *                                          / 
             *                                          6
            */


        }

        public int TreeSum(Node<int> root)
        {
            int sum = 0;
            if (root == null)
            {
                return 0;
            }
          

            return root.Value + TreeSum(root.Left) + TreeSum(root.Right);
            
        }


        public int TreeMin(Node<int> root)
        {            
            
            if(root == null)
            {
                return int.MaxValue;
            }    
            
            int  treeMinLeft = TreeMin(root.Right);
            int   treeMinRight = TreeMin(root.Left);
            return Math.Min(Math.Min(root.Value,treeMinLeft),treeMinRight);
        }

        public int TreeMin_DepthFirstStack(Node<int> root)
        {

            if(root == null)
            {
                return int.MaxValue;
            }
            int treeMin = root.Value;
            var st = new Stack<Node<int>>();
            st.Push(root);

            while (st.Count > 0)
            {
                var val = st.Peek();
                st.Pop();
                if(val.Value < treeMin)
                {
                    treeMin = val.Value;   
                }

                if(val.Right != null)
                {
                    st.Push(val.Right);
                }
                if (val.Left != null)
                {
                    st.Push(val.Left);
                }

            }
            return treeMin;

        }

        public int TreeMin_BreadthFirstQueue(Node<int> root)
        {

            if (root == null)
            {
                return int.MaxValue;
            }
            int treeMin = root.Value;
            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var val = queue.Dequeue();

               
               
                if (val.Value < treeMin)
                {
                    treeMin = val.Value;
                }

                if (val.Left != null)
                {
                    queue.Enqueue(val.Left);
                }
                if (val.Right != null)
                {
                    queue.Enqueue(val.Right);
                }

            }
            return treeMin;

        }
        /// <summary>
        /// Maximum sum for root to leaf node
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>

        public int MaxRootLeafPathSum(Node<int> root)
        {
            if(root == null)
            {
                return int.MinValue;
            }

            if(root.Left == null && root.Right == null) //leafNode
            {
                return root.Value;
            }
            var maxPathSum = Math.Max(MaxRootLeafPathSum(root.Left), MaxRootLeafPathSum(root.Right));
            return root.Value + maxPathSum;

        }
    }

}

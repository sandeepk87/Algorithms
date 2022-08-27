using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DataStructures
{
    public class GraphNode<T>
    {
        private GraphNode()
        {

        }
        public GraphNode(T value)
        {
            Value = value;
        
        }
            
        public T Value { get; set; }

       public GraphNode<T>[] Neighbours { get; set; }
    }

    public class GraphNodeStringExample
    {
        public GraphNodeStringExample()
        {
             a = new GraphNode<string>("a");

             b = new GraphNode<string>("b");

             c = new GraphNode<string>("c");

             d = new GraphNode<string>("d");

             e = new GraphNode<string>("e");

             f = new GraphNode<string>("f");


            a.Neighbours = new GraphNode<string>[] { b, c };
            c.Neighbours = new GraphNode<string>[] { e };
            b.Neighbours = new GraphNode<string>[] { d };

            d.Neighbours = new GraphNode<string>[] { f };

        }

        public GraphNode<string> a;
        public GraphNode<string> e;
        public GraphNode<string> b;
        public GraphNode<string> f;
        public GraphNode<string> d;
        public GraphNode<string> c;
    }

    public class GraphOperations
    {

        /// <summary>
        /// This wont work with cyclic graphs
        /// </summary>
        /// <param name="node"></param>
        public static void DepthFirstTraversal(GraphNode<string> node)
        {
            var stack = new Stack<GraphNode<string>>();
            stack.Push(node);

            while (stack.Count != 0)
            {
                var current = stack.Peek();
                stack.Pop();
                Console.WriteLine(current.Value);
                if(current.Neighbours!=null)
                foreach(var neighbour in current.Neighbours)
                {
                    stack.Push(neighbour);
                }

              
            }
        }

        /// <summary>
        /// This wont work with cyclic graphs
        /// </summary>
        /// <param name="node"></param>

        public static void DepthFirstTraversalRecursive(GraphNode<string> current)
        {
            if (current != null)
            {
                Console.WriteLine(current.Value);

                if (current.Neighbours != null)
                {
                    foreach(var val in current.Neighbours)
                    DepthFirstTraversalRecursive(val);
                }
               
            }

        }

        /// <summary>
        /// This wont work with cyclic graphs
        /// </summary>
        /// <param name="node"></param>

        public static void BreadthFirstTraversal(GraphNode<string> current)
        {
            var queue = new Queue<GraphNode<string>>();

            queue.Enqueue(current);
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                Console.WriteLine(current.Value);

                if (current.Neighbours != null)
                {
                    foreach(var val in current.Neighbours)
                    queue.Enqueue(val);
                }

            }
        }

        public static bool HasPath(GraphNode<string> src, GraphNode<string> dest)
        {
            if(src == dest)
            {
                return true;

            }

            if(src.Neighbours!=null)
            foreach(var neighbour in src.Neighbours)
            {
                if(neighbour!=null)
                if (HasPath(neighbour, dest))
                {
                    return true;
                }
            }
            return false;

        }


        public static bool HasPathWithBreadthFirst(GraphNode<string> src, GraphNode<string> dest)
        {

            if(src == dest)
            {
                return true;
            }

            var queue = new Queue<GraphNode<string>>();
            queue.Enqueue(src);
            while (queue.Count > 0)
            {
                var val = queue.Dequeue();
                if (val == dest) return true;

                if(val.Neighbours != null)
                {
                    foreach(var nei in val.Neighbours)
                    {
                        queue.Enqueue(nei);
                    }
                }

            }
            return false;

        }
    }


}

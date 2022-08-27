using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DataStructures
{
    /// <summary>
    /// this class can also be directed graph
    /// </summary>
    public class UndirectedGraph<T>
    {

        public Dictionary<T,
            System.Collections.Generic.List<T>> AdjacencyList
        { get; set; } = new Dictionary<T, List<T>>();

            

        public int NumOfVertices => AdjacencyList.Keys.Count;
        public UndirectedGraph()
        {


        }

        public void AddEdge(T node, T neighbour)
        {
            if (AdjacencyList.ContainsKey(node))
            {
                var neighbours = AdjacencyList[node];
                neighbours.Add(neighbour);
            }
            else
            {
                AdjacencyList.Add(node, new System.Collections.Generic.List<T>());
                AdjacencyList[node].Add(neighbour);
            }
        }


        public void PrintGraph()
        {
            foreach (var vertix in AdjacencyList.Keys)
            {
                var neighbours = new List<T>();
                foreach (var val in AdjacencyList[vertix])
                {
                    neighbours.Add(val);
                }

                Console.WriteLine($"Vertex {vertix} - [ {string.Join(",", neighbours)}  ]");
            }
        }
    }

    /// <summary>
    /// In Undirected Graph  if adjacencylist of  any node  has a neighbour, then the node should be present in adjacency list of neighbour too.
    /// </summary>


    public class UndirectedGraphStringExample
    {
        private UndirectedGraph<string> _unGraph;
        public UndirectedGraph<string> Undirected_Graph => _unGraph;
        public UndirectedGraphStringExample()
        {
            _unGraph = new UndirectedGraph<string>();
            _unGraph.AddEdge("i", "j");
            _unGraph.AddEdge("i", "k");
            _unGraph.AddEdge("j", "i");
            _unGraph.AddEdge("j", "k");
            _unGraph.AddEdge("j", "p");
            _unGraph.AddEdge("p", "j");
            _unGraph.AddEdge("p", "m");
            _unGraph.AddEdge("k", "i");
            _unGraph.AddEdge("k", "j");
            _unGraph.AddEdge("k", "l");
            _unGraph.AddEdge("m", "p");
            _unGraph.AddEdge("l", "k");
            _unGraph.AddEdge("o", "n");
            _unGraph.AddEdge("n", "o");


            _unGraph.AddEdge("q", "r");
            _unGraph.AddEdge("q", "s");
            _unGraph.AddEdge("t", "q");
            _unGraph.AddEdge("r", "q");
            _unGraph.AddEdge("s", "q");
            _unGraph.AddEdge("q", "t");



        }

        public void DepthFirstTraversal_Stack(UndirectedGraph<string> undirectedGraph,string source)
        {

            var stack = new Stack<string>();
            stack.Push(source);
            var visited = new HashSet<string>();

            while (stack.Count > 0)
            {               
                var val = stack.Peek();
                stack.Pop();
               // Console.WriteLine(val);
                visited.Add(val);
                    if(undirectedGraph.AdjacencyList.ContainsKey(val))
                    foreach (var nei in undirectedGraph.AdjacencyList[val])
                    {
                    if (!visited.Contains(nei))
                    {
                        stack.Push(nei);
                    }  
                    }
            }

            foreach(var val in visited)
            {
                Console.WriteLine(val);
            }
            
        }

        public void DepthFirstTraversal_Recursive(UndirectedGraph<string> undirectedGraph, string source)
        {
            var visited = DFS_Recursive(undirectedGraph, source, new HashSet<string>());

            foreach (var val in visited)
            {
                Console.WriteLine(val);
            }
        }

        public HashSet<string> DFS_Recursive(UndirectedGraph<string> undirectedGraph, string source,HashSet<string> visited)
        {
           
                Console.WriteLine(source);
                visited.Add(source);
                foreach (var nei in undirectedGraph.AdjacencyList[source])
                {
                    if (!visited.Contains(nei))
                    {
                    DFS_Recursive( undirectedGraph,nei, visited);
                    }
                }
            return visited;

        }

        public bool HasPath(string source, string dest)
        {

            return PathCheck(source,dest,new HashSet<string>());
        }
        private bool PathCheck (string source,string dest,HashSet<string> visited)
        {
            if (visited.Contains(source))
            {
                return false;
            }
            visited.Add(source);
            if(source == dest)
            {
                return true;
            }

            var adj = _unGraph.AdjacencyList[source];
           
            foreach(var val in adj)
            {
                if(val == dest)
                {
                    return true;
                }
                else
                {
                    if (PathCheck(val, dest, visited) == true)
                        return true;
                }
            }
            return false; ;
        }


        public int ConnectedComponentCount()
        {
            var count = 0;
            var nodes = _unGraph.AdjacencyList.Keys;
            var visited = new HashSet<string>();
            foreach(var node in nodes)
            {
               if(explore(node,visited) == true)
                {
                    count++;
                }

            }

            return count;
        }

        private bool explore(string source,HashSet<string> visited)
        {
            if (visited.Contains(source))
            {
                return false;
            }
            visited.Add(source);
            foreach(var val in _unGraph.AdjacencyList[source])
            {
                explore(val, visited);
            }

            return true;
        }

        /// <summary>
        /// returns no of nodes in largest component
        /// </summary>
        /// <returns></returns>
        public int LargestConponent()
        {
            int largerstComponent = 0;

            var visited = new HashSet<string>();
            foreach(var node in _unGraph.AdjacencyList.Keys)
            {
              var size = exploreSize(_unGraph, node, visited);    
              if(largerstComponent < size)
                    {
                    largerstComponent = size;
                    }                
            }

            

            return largerstComponent;
        }


        private int exploreSize(UndirectedGraph<string> graph,string node,HashSet<string> visited)
        {
            if (visited.Contains(node))
                return 0;
            visited.Add(node);
            var size = 1;
            foreach(var val in graph.AdjacencyList[node])
            { 
              size = size +  exploreSize(graph, val, visited);
            }
            return size;
        }


        public int ShortestPath(string source, string dest)
        {

            
            if(source == dest)
            {
                return 0;
            }

            var queue = new Queue<ValueTuple<string,int>>();
            var visited = new HashSet<string>();
            queue.Enqueue((source,0));
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                if(current.Item1 == dest)
                {
                    return current.Item2;
                }
                visited.Add(current.Item1);
               
                foreach (var val in _unGraph.AdjacencyList[current.Item1])
                {
                    if (!visited.Contains(val))
                    {
                       
                        queue.Enqueue((val,current.Item2+1));
                    }
                }

            }


            return -1;
        }
    }
}

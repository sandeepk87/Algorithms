using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.CodingProblems
{
    /// <summary>
    /// Count the no of islands formed by 'L' (use graph)
    /// </summary>
    public class Island
    {
        public static char[,] isLandMatrix = new char[5, 5] {

             { 'W','L','L','W','W'},
             { 'W','L','L','W','W'},
             {'W','W','W','L','L' },
             {'L','L','W','W','W' },
             {'L','L','W','W','W' }

        };
        public Island()
        {

        }


        public static int GetCount()
        {
            var count = 0;
            var visited = new HashSet<string>();
            for (int row = 0; row < isLandMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < isLandMatrix.GetLength(1); col++)
                {


                    if (exploreIsland(isLandMatrix, row, col, visited))
                    {
                        count++;
                    }

                    Console.WriteLine(isLandMatrix[row, col]);
                }
            }

            return count;
        }

        public static int MinimumIsland()
        {
            int smallest = int.MaxValue;
            var visited = new HashSet<string>();

            for (int row = 0; row < isLandMatrix.GetLength(0); row++)
                for (int col = 0; col < isLandMatrix.GetLength(1); col++)
                {
                    var size = exploreIslandSize(isLandMatrix, row, col, visited);
                    if (smallest > size && size > 0)
                    {
                        smallest = size;
                    }
                }


            return smallest;

        }

        private static bool exploreIsland(char[,] island, int row, int col, HashSet<string> visited)
        {
            if (visited.Contains($"{row},{col}"))
                return false;

            visited.Add($"{row},{col}");

            var rowInBounds = 0 <= row && row < island.GetLength(0);
            var colInBounds = 0 <= col && col < island.GetLength(1);

            if (!rowInBounds || !colInBounds)
            {
                return false;
            }

            if (isLandMatrix[row, col] == 'W')
            {
                return false;
            }

            exploreIsland(island, row - 1, col, visited);

            exploreIsland(island, row + 1, col, visited);

            exploreIsland(island, row, col - 1, visited);

            exploreIsland(island, row, col + 1, visited);


            return true;
        }


        private static int exploreIslandSize(char[,] island, int row, int col, HashSet<string> visited)
        {
            if (visited.Contains($"{row},{col}"))
                return 0;

            visited.Add($"{row},{col}");

            var size = 1;

            var rowInBounds = 0 <= row && row < island.GetLength(0);
            var colInBounds = 0 <= col && col < island.GetLength(1);

            if (!rowInBounds || !colInBounds)
            {
                return 0;
            }

            if (isLandMatrix[row, col] == 'W')
            {
                return 0;
            }

            size = size+  exploreIslandSize(island, row - 1, col, visited);

            size = size + exploreIslandSize(island, row + 1, col, visited);

            size = size + exploreIslandSize(island, row, col - 1, visited);

            size = size + exploreIslandSize(island, row, col + 1, visited);


            return size;
        }
    }
}

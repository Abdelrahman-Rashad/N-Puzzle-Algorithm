using System.Collections.Generic;
namespace N_puzz
{
    class Node
    {
        public int[,] puzzle;
        public int step=0;
        public int finalcost;
        public int cost;
        public int dimensions;
        public string ID;
        public int xEmptyindex;
        public int yEmptyindex;
        public static int move;
        public List<Node> children = new List<Node>();
        private Node parent = null;

        // O(1)
        public Node(int dim)
        {
            step = 0;
            puzzle = new int[dim, dim];
            cost = 0;
            ID = "";
            dimensions = dim;
        }

        // O(N^2)
        public Node(int[,] puzzles, int dimetions)
        {

            puzzle = new int[dimetions, dimetions];
            for (int i = 0; i < dimetions; i++)
            {
                for (int j = 0; j < dimetions; j++)
                {
                    puzzle[i, j] = puzzles[i, j];
                    if (puzzles[i, j] == 0)
                    {
                        xEmptyindex = i;
                        yEmptyindex = j;
                    }
                }
            }

        }

        // O(1)
        public void setParent(Node parent)
        {
            this.parent = parent;
        }

        // O(1)
        public Node getParent()
        {
            return this.parent;
        }


    }
}

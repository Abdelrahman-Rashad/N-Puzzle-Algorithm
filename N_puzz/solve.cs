using System;
using System.Collections.Generic;

namespace N_puzz
{
    class solve
    {
        Dictionary<string,bool> visited;
        Hamming calculate;
        public int count = 0;
        Manhattan better;
        queue q; 
        //O(1)
        public solve(int dim)
        {           
            visited = new Dictionary<string, bool>();
            calculate = new Hamming();
            q = new queue();
            better = new Manhattan();
        }

        // O(N^2)
        public string convertToString(int[,] puzzle, int dimensions)
        {
            string temp = "";
            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    temp += puzzle[i, j];
                }
            }
            return temp;
        }

        //O(N^3)
        public void display(Node node, int display_dimention)
        {

            if (node.getParent() != null)
            {
                Node temp = node.getParent();
                //O(N)
                display(temp, display_dimention);

            }

            // O(N^2)
            for (int i = 0; i < display_dimention; i++)
            {
                for (int j = 0; j < display_dimention; j++)
                {
                    Console.Write(node.puzzle[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------");
        }

        ////O(N^3)
        public void A_star_solution(Node start, Node goal, int dimention,string method)
        {
            start.step = 0;
            //O(N^2)
            if (method == "H" || method == "h")
                start.cost = calculate.hamming_method(start.puzzle, dimention);
            else if (method == "M" || method == "m")
                start.cost = better.Heuristics(start.puzzle, dimention);
            start.finalcost = start.step + start.cost;
            start.ID = convertToString(start.puzzle, dimention); //O(N^2)

            // O(log(N))
            q.push(start);


            while (q.size()!=0)
            {
                Node.move++;
                // O(log(N))
                Node select_node = q.pop();
                visited.Add(select_node.ID, true);

                ////O(N^3)
                if (select_node.cost == 0)
                {
                    Console.WriteLine("movements is: " + Node.move);
                    Console.WriteLine("steps is: " + select_node.step);

                    //O(N^3)
                    display(select_node, dimention);
                    break;
                }
                //O(N^2)
                generate_children(select_node, dimention, method);
                
            }
        }

        //O(N^2)
        private void generate_children(Node parent, int dimention_child,string method)
        {
            int var = 0;
            Node test_node;
            if (parent.xEmptyindex > 0)
            {
                test_node = new Node(parent.puzzle, dimention_child);
                var = test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex];
                test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex] = test_node.puzzle[parent.xEmptyindex - 1, parent.yEmptyindex];
                test_node.puzzle[parent.xEmptyindex - 1, parent.yEmptyindex] = var;
                //O(N^2)
                if (method == "H" || method == "h")
                     test_node.cost = calculate.hamming_method(test_node.puzzle, dimention_child);
                else if(method == "M" || method == "m")
                    test_node.cost = better.Heuristics( test_node.puzzle, dimention_child);
                test_node.step = parent.step + 1;
                test_node.setParent(parent);//O(1)
                test_node.dimensions = parent.dimensions;
                test_node.finalcost = test_node.step + test_node.cost;
                test_node.ID = convertToString(test_node.puzzle, dimention_child); //O(N^2)
                test_node.xEmptyindex = parent.xEmptyindex - 1;
                test_node.yEmptyindex = parent.yEmptyindex;
                parent.children.Add(test_node);
            }
            if (parent.xEmptyindex + 1 < dimention_child)
            {
                test_node = new Node(parent.puzzle, dimention_child);
                var = test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex];
                test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex] = test_node.puzzle[parent.xEmptyindex + 1, parent.yEmptyindex];
                test_node.puzzle[parent.xEmptyindex + 1, parent.yEmptyindex] = var;

                //O(N^2)
                if (method == "H" || method == "h")
                    test_node.cost = calculate.hamming_method(test_node.puzzle, dimention_child);
                else if (method == "M" || method == "m")
                    test_node.cost = better.Heuristics(test_node.puzzle, dimention_child);
                test_node.step = parent.step + 1;
                test_node.setParent(parent);//O(1)
                test_node.dimensions = parent.dimensions;
                test_node.finalcost = test_node.step + test_node.cost;
                test_node.ID = convertToString(test_node.puzzle, dimention_child);//O(N^2)
                test_node.xEmptyindex = parent.xEmptyindex + 1;
                test_node.yEmptyindex = parent.yEmptyindex;
                parent.children.Add(test_node);

            }
            if (parent.yEmptyindex > 0)
            {
                test_node = new Node(parent.puzzle, dimention_child);
                var = test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex];
                test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex] = test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex - 1];
                test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex - 1] = var;
                //O(N^2)
                if (method == "H" || method == "h")
                    test_node.cost = calculate.hamming_method(test_node.puzzle, dimention_child);
                else if (method == "M" || method == "m")
                    test_node.cost = better.Heuristics(test_node.puzzle, dimention_child);
                test_node.step = parent.step + 1;
                test_node.setParent(parent);//O(1)
                test_node.dimensions = parent.dimensions;
                test_node.finalcost = test_node.step + test_node.cost;
                test_node.ID = convertToString(test_node.puzzle, dimention_child);//O(N^2)
                test_node.xEmptyindex = parent.xEmptyindex;
                test_node.yEmptyindex = parent.yEmptyindex - 1;
                parent.children.Add(test_node);
            }
            if (parent.yEmptyindex + 1 < dimention_child)
            {
                test_node = new Node(parent.puzzle, dimention_child);
                var = test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex];
                test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex] = test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex + 1];
                test_node.puzzle[parent.xEmptyindex, parent.yEmptyindex + 1] = var;

                //O(N^2)
                if (method == "H" || method == "h")
                    test_node.cost = calculate.hamming_method(test_node.puzzle, dimention_child);
                else if (method == "M" || method == "m")
                    test_node.cost = better.Heuristics(test_node.puzzle, dimention_child);
                test_node.step = parent.step + 1;
                test_node.setParent(parent);//O(1)
                test_node.dimensions = parent.dimensions;
                test_node.finalcost = test_node.step + test_node.cost;
                test_node.ID = convertToString(test_node.puzzle, dimention_child);//O(N^2)
                test_node.xEmptyindex = parent.xEmptyindex;
                test_node.yEmptyindex = parent.yEmptyindex + 1;
                parent.children.Add(test_node);
            }
            //O(Nlog(N))
            for (int i = 0; i < parent.children.Count; i++)
            {
                //O(N)
                if (!visited.ContainsKey(parent.children[i].ID))
                {
                    //O(N)
                    if (!q.check.ContainsKey(parent.children[i].ID))
                    {

                        // O(log(N))
                        q.push(parent.children[i]);
                    }                    
                }
            }
        }
    }
}

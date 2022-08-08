using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace N_puzz
{
    class Program
    {
        public static int N;
        public static Node goal;
        public static string line;
        public static string[] size_puzzle;
        public static int[,] puzzle;
        public static Node node;
        public static string[] cols;



        static void Main(string[] args)
        {
            string val;
            Console.WriteLine("Is it a Puzzle:\n[1] Sample test cases\n[2] Complete testing\n");
            Console.Write("\nEnter your choice [1-2]: ");

            //read input from console
            val = Console.ReadLine();
            int Choice = Convert.ToInt32(val);

            if (Choice == 1)
            {

                // reading file
                Console.WriteLine("Reading File ...... ");
                //string file = "8 Puzzle(3) - Case 1.txt";
                //string file = "99 Puzzle - 2.txt";
                //string file = "8 Puzzle (1).txt";
                //string file = "8 Puzzle (2).txt";
                //string file = "8 Puzzle (3).txt";
                //string file = "9999 Puzzle.txt";
                //string file = "50 Puzzle.txt";
                //string file = "15 Puzzle - 1.txt";
                //string file = "15 Puzzle - Case 3.txt";
                //string file = "24 Puzzle 1.txt";
                //string file = "24 Puzzle 2.txt";
                string file = "15 Puzzle - Case 3.txt";

                FileStream FS = new FileStream(file, FileMode.Open);
                StreamReader SR = new StreamReader(FS);
                line = SR.ReadLine();
                N = int.Parse(line);
                try
                {
                    //O(N^2)
                    puzzle = new int[N, N];
                    for (int i = 0; i < N; i++)
                    {
                        line = SR.ReadLine();
                        cols = line.Split(' ');
                        for (int j = 0; j < N; j++)
                            puzzle[i, j] = int.Parse(cols[j]);
                    }
                    SR.Close();
                    FS.Close();
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(puzzle[i, j]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    SR.Close();
                    FS.Close();
                    StreamReader Textfile = new StreamReader(file);
                    //read line by line
                    line = Textfile.ReadLine();

                    //split size of puzzle
                    N = int.Parse(line);

                    puzzle = new int[N, N];

                    if (Textfile.ReadLine() != null)
                    {
                        //O(N^2)
                        for (int i = 0; i < N; i++)
                        {
                            line = Textfile.ReadLine();
                            //split data by space
                            size_puzzle = line.Split(' ');

                            for (int j = 0; j < N; j++)
                            {
                                puzzle[i, j] = int.Parse(size_puzzle[j]);
                            }
                        }
                    }
                    Textfile.Close();
                    //print puzzle
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(puzzle[i, j]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
                var watch = new System.Diagnostics.Stopwatch();

                watch.Start();
                //O(N^2)
                bool ReceivedAnswer = IsSolvable.isSolvable(puzzle, N);
                //bool   expectedAnswer = bool.Parse(Textfile.ReadLine());
                if (!ReceivedAnswer)
                {
                    Console.WriteLine("........ Un-Solvable ......");
                }
                else
                {
                    Console.WriteLine("........ Solvable .......");
                    //O(N^2)
                    node = new Node(puzzle, N);
                    //O(1)
                    solve solve_puzzle = new solve(N);
                    string method;
                    Console.Write("\nEnter your choice to solve the Puzzle {H,M}:  ");
                    method = Console.ReadLine();
                    //O(1)
                    goal = new Node(N);
                    int count = 1;
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            goal.puzzle[i, j] = count;
                            count++;

                        }
                    }
                    //O(N^3)
                    solve_puzzle.A_star_solution(node, goal, N,method);
                    Console.WriteLine();
                }
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Execution Time: {watch.Elapsed.Seconds} s");


            }//end of if of choice

            else if (Choice == 2)
            {

                // reading file
                Console.WriteLine("Reading File ...... ");

                //string file = "15 Puzzle 1.txt";
                //string file = "15 Puzzle 1 - Unsolvable.txt";
                //string file = "99 Puzzle - 2.txt";
                //string file = "15 Puzzle 4.txt";
                string file = "15 Puzzle 3.txt";
                //string file = "15 Puzzle 5.txt";
                //string file = "TEST.txt";

                //string file = "9999 Puzzle.txt";
                //string file = "50 Puzzle.txt";
                //string file = "9999 Puzzle.txt";
                //string file = "99 Puzzle - Unsolvable Case 1.txt";
                //string file = "99 Puzzle - 1.txt";
                //string file = "99 Puzzle - Unsolvable Case 2.txt";

                FileStream FS = new FileStream(file, FileMode.Open);
                StreamReader SR = new StreamReader(FS);
                line = SR.ReadLine();
                N = int.Parse(line);
                try
                {
                    puzzle = new int[N, N];
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        line = SR.ReadLine();
                        cols = line.Split(' ');
                        for (int j = 0; j < N; j++)
                            puzzle[i, j] = int.Parse(cols[j]);
                    }
                    SR.Close();
                    FS.Close();
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(puzzle[i, j]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    SR.Close();
                    FS.Close();
                    StreamReader Textfile = new StreamReader(file);
                    //read line by line
                    line = Textfile.ReadLine();

                    //split size of puzzle
                    N = int.Parse(line);

                    puzzle = new int[N, N];

                    if (Textfile.ReadLine() != null)
                    {
                        //O(N^2)
                        for (int i = 0; i < N; i++)
                        {
                            line = Textfile.ReadLine();
                            //split data by space
                            size_puzzle = line.Split(' ');

                            for (int j = 0; j < N; j++)
                            {
                                puzzle[i, j] = int.Parse(size_puzzle[j]);                                
                            }
                        }
                    }
                    Textfile.Close();
                    //print puzzle
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(puzzle[i, j]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
                
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                //O(N^2)
                bool ReceivedAnswer = IsSolvable.isSolvable(puzzle, N);
                //bool   expectedAnswer = bool.Parse(Textfile.ReadLine());
                if (!ReceivedAnswer)
                {
                    Console.WriteLine("........ Un-Solvable ......");
                }
                else
                {
                    Console.WriteLine("........ Solvable .......");
                    //O(N^2)
                    node = new Node(puzzle, N);
                    //O(1)
                    solve solve_puzzle = new solve(N);
                    //O(1)
                    goal = new Node(N);
                    int count = 1;
                    //O(N^2)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            goal.puzzle[i, j] = count;
                            count++;

                        }
                    }
                    goal.puzzle[N - 1, N - 1] = 0;  
                    string method;
                    Console.Write("\nEnter your choice to solve the Puzzle {H,M}:  ");
                    method = Console.ReadLine();
                    //O(N^3)
                    solve_puzzle.A_star_solution(node, goal, N,method);
                    Console.WriteLine();
                }                
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Execution Time: {watch.Elapsed.Seconds} s");

            }//end of else if of choice
        }//end of main
    }//end of class
}

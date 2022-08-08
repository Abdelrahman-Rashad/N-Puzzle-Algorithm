# N-Puzzle-Algorithm-
The N-puzzle (N = 8, 15...) is a classical problem for modelling algorithms involving heuristics. Commonly used heuristics for this problem include counting the number of misplaced tiles (Hamming Distance) OR finding the sum of the Manhattan distances between each block and its position in the goal configuration. Note that both are admissible, i.e. they never overestimate the number of moves left, which ensures optimality for certain search algorithms such as A*. A* is one of the informed search algorithms that can be used in such problems to get the optimal solution. 

## Aiming
This project aims to solve the N-puzzle with min number of moves to arrange the puzzle.

## Requirements
1-	Read and parse the input file <br />
2-	Represent the N-puzzle in form of graph/tree <br />
3-	Implement A* search algorithm using Hamming Distance<br />
4-	STEP by STEP display for the 3x3 case <br />
5-	Modify A* search algorithm to use Manhattan Distance<br />
6-	Find a formula to indicate whether any given game state is solvable or not.<br />
7-	Output: <br />
-	Min number of moves <br />
-	Solvable or not + min number of moves + STEP by STEP display for 3x3 case<br />

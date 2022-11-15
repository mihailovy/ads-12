/*
 If given an omniscient view of the maze, a simple recursive algorithm can tell one how to get to the end. The algorithm will be given a starting X and Y value. If the X and Y values are not on a wall, the method will call itself with all adjacent X and Y values, making sure that it did not already use those X and Y values before. If the X and Y values are those of the end location, it will save all the previous instances of the method as the correct path.

 This is in effect a depth-first search expressed in term of grid points. The omniscient view prevents entering loops by memoization.
 
 Source: https://en.wikipedia.org/wiki/Maze-solving_algorithm 

 */
 
using System;
class Maze {
  const int width  = 6;
  const int height = 5;
  
  // The maze
  static bool[,] maze =  {
    { false, false, false, false, false, false},
    { false, true , false, false, true , false},
    { false, true , true , false, true , false},
    { false, true , false, false, false, false},
    { false, false, false, false, true , false}
  };
    
  static bool[,] wasHere     = new bool[width, height];
  static bool[,] correctPath = new bool[width, height]; // The solution to the maze
  
  static int startX, startY; // Starting X and Y values of maze
  static int endX, endY;     // Ending X and Y values of maze

  static void PrintMaze(int startX, int startY, int endX, int endY) {
    Console.WriteLine("");
    for (int row = 0; row < height; row++) {
      for (int col = 0; col < width; col++) {
        if (row == startY && col == startY) {
          Console.Write("S ");
        } else if (row == endY && col == endX) {
          Console.Write("F ");
        } else if (maze[row, col] == true) {
          Console.Write("# ");   
        } else {
          Console.Write(". ");
        }
      }
      Console.WriteLine("");
    }
  }

  static void PrintPath() {
    Console.WriteLine("");
    for (int row = 0; row < height; row++) {
      for (int col = 0; col < width; col++) {
        if (correctPath[row, col] == true) {
          Console.Write("O ");   
        } else {
          Console.Write(". ");
        }
      }
      Console.WriteLine("");
    }
  }
    
  static void Main() {
    // Input
    startX = 0; // 0,0 - горен ляв ъгъл
    startY = 0;
    //
    endX   = 4; // 4,4 - долен ляв ъгъл
    endY   = 4;
    PrintMaze(startX, startY, endX, endY);
      
    // начални сттойности на масивите
    for (int y = 0; y < height; y++) { // по вертикал, y
      for (int x = 0; x < width; x++) { // по хоризонтал, x
        wasHere[x,y]      = false;
        correctPath[x, y] = false;
        // Console.WriteLine("X= "+x+", Y = "+y+", width = "+width+", height = " + height);
      }
    }
    
    bool b = RecursiveSolve(startX, startY);
    if (b == false) {
      Console.WriteLine("Задачата няма решение!");
    } else {
    }
    
  }
  
  static public bool RecursiveSolve(int x, int y) {
    // Console.WriteLine("==> X= "+x+", Y = "+y+", width = "+width+", height = " + height);
    // Условия за излизане от рекурсия
    if (x == endX && y == endY) {
      return true; // достигнали сме края
    }
    if (maze[y,x] == true || wasHere[y,x] == true) {
      return false; // Има препятствие или вече сме били в тази точка 
    }
    // Отбелязваме точката, че е проверена
    wasHere[x,y] = true;
    
    // Ако не сме на левия ръб
    if (x != 0) {
      if (RecursiveSolve(x-1, y)) { // Recalls method one to the left
        correctPath[y,x] = true; // Sets that path value to true;
         PrintPath();
        return true;
      }
    }
    // Checks if not on right edge
    if (x != width - 1) { 
      if (RecursiveSolve(x+1, y)) { // Recalls method one to the right
        correctPath[y,x] = true;
         PrintPath();
        return true;
      }
    }
    // Checks if not on top edge
    if (y != 0) { 
      if (RecursiveSolve(x, y-1)) { // Recalls method one up
        correctPath[y,x] = true;
         PrintPath();
        return true;
      }
    }
    // Checks if not on bottom edge
    if (y != height - 1) {
        if (RecursiveSolve(x, y+1)) { // Recalls method one down
            correctPath[y,x] = true;
             PrintPath();
            return true;
        }
    }
    return false;
  }

}

/*
 Source: https://en.wikipedia.org/wiki/Maze-solving_algorithm 
 */
 
using System;
class Maze {
  const int width  = 5;
  const int height = 5;
  
  // The maze
  static bool[,] maze =  {
    { false, false, false, false, false, false},
    { false, true , false, false, true , false},
    { false, true , true , false, true , false},
    { false, true , false, false, false, false},
    { false, false, false, false, false, false}
  };
    
  static bool[,] wasHere     = new bool[width, height];
  static bool[,] correctPath = new bool[width, height]; // Намерено решение
  
  static int startX, startY; // Стартови стойности
  static int endX, endY;     // Крайни стойности

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
    endX   = 4; // 4,4 - долен десен ъгъл
    endY   = 4;
    PrintMaze(startX, startY, endX, endY);
      
    // начални сттойности на масивите
    for (int y = 0; y < height; y++) { // по вертикал, y
      for (int x = 0; x < width; x++) { // по хоризонтал, x
        wasHere[x,y]      = false;
        correctPath[x, y] = false;
        Console.WriteLine("Debug X= "+x+", Y = "+y+", width = "+width+", height = " + height);
      }
    }
    
    bool b = RecursiveSolve(startX, startY);
    if (b == false) {
      Console.WriteLine("Задачата няма решение!");
    } else {
    }
    
  }
  
  static public bool RecursiveSolve(int x, int y) {
    // Console.WriteLine("Debug 2 ==> X= "+x+", Y = "+y+", width = "+width+", height = " + height);
    // Условия за излизане от рекурсия
    if (x == endX && y == endY) {
      return true; // достигнали сме края
    }
    if (maze[x, y] == true || wasHere[x, y] == true) {
      return false; // Има препятствие или вече сме били в тази точка 
    }
    // Отбелязваме точката, че е проверена
    wasHere[x, y] = true;
    
    // Ако не сме на левия ръб
    if (x != 0) {
      if (RecursiveSolve(x-1, y) == true) { 
        correctPath[x, y] = true; 
         PrintPath();
        return true;
      }
    }
    // Ако не сме на десния ръб
    if (x != width - 1) { 
      if (RecursiveSolve(x+1, y)) { 
        correctPath[x, y] = true;
         PrintPath();
        return true;
      }
    }
    // Ако не сме на горния ръб
    if (y != 0) { 
      if (RecursiveSolve(x, y-1)) { 
        correctPath[x, y] = true;
         PrintPath();
        return true;
      }
    }
    // Ако не сме на долния ръб
    if (y != height - 1) {
        if (RecursiveSolve(x, y+1)) { 
            correctPath[x, y] = true;
             PrintPath();
            return true;
        }
    }
    return false;
  }

}

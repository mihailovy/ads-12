using System;

class Graph {
  const int n = 6;
  static int[][] matrix = new int[n][] ; // създаваме масив, който е празен  
  
  static void Init() {
    int i,j;
  
    for (i = 0; i < n; i++) {
      for (j = 0; j < n; j++) {
        matrix[i][j] = 0;
      }
    } 
  }
    
  static void Main() {
    Init();
    
    // Елементарен насочен граф, който използва двумерен масив. 
  
    //                      ----------- 1 ---------
    //                    (45)                   (35)
    //                      V                     V
    //                   ---2---               ---3---
    //                 (23)    (11)          (55)    (89)
    //                   V      V              V      V
    //                   4      5              6      7      
    //
    // Ниво 1
    matrix[1-1][2-1] = 45; // ляво
    matrix[1-1][3-1] = 35; // дясно
    // Ниво 2
    matrix[4-1][2-1] = 23; // ляво
    matrix[2-1][5-1] = 11; // дясно
    matrix[3-1][6-1] = 55; // ляво
    matrix[3-1][7-1] = 89; // дясно
  }

  static void BFS() {
    // Обхождане
  }
}


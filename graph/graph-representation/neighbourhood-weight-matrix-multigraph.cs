using System;

class Graph {
  const int n = 6; // Брой върхове (nodes)
  const int m = 2; // Максимален брой дъги между два върха

  public struct Node {
    public int [] edge;
    string name;
  }
  
  static Node[][] matrix = new Node[n][] ; // създаваме масив, който е празен 
  

  
  static void Init() {
    int i,j;
  
    for (i = 0; i < n; i++) {
      for (j = 0; j < n; j++) {
        matrix[i][j] = new Node();
        matrix[i][j].edge[0] = 0;
        matrix[i][j].name = "No name";
      }
    } 
  }
    
  static void Main() {
    Init();
    
    // Елементарен насочен граф, който използва двумерен масив. 
    
    //               +------------(81)----------+
    //               |                          V
    // 1 ---(34)---> 2 ---(45)---> 3---(55)---> 4       5        6
    // |                           ^            ^                V
    // +------------(37)-----------+            +-------(67)------
    // |                           |            |                |
    // +------------(23)-----------+            +-------(11)------
    //
    // Мултиграф
    
    matrix[1-1][2-1].name = "Broadway"; 
    matrix[1-1][2-1].edge[0] =  34;
    matrix[2-1][1-1].edge[0] = -34;
    
    
    matrix[1-1][3-1].edge[0] =  37;
    matrix[3-1][1-1].edge[0] = -37;
    
    matrix[1-1][3-1].edge[1] =  23;
    matrix[3-1][1-1].edge[1] = -23;
    
    
    matrix[2-1][3-1].edge[0] =  45;
    matrix[3-1][2-1].edge[0] = -45;
    
    matrix[3-1][4-1].edge[0] =  55;
    matrix[4-1][3-1].edge[0] = -55;
    
    matrix[2-1][4-1].edge[0] =  81;
    matrix[4-1][2-1].edge[0] = -81;
    
    matrix[6-1][4-1].edge[0] =  67;
    matrix[4-1][6-1].edge[0] = -67;

    matrix[6-1][4-1].edge[1] =  11;
    matrix[4-1][6-1].edge[1] = -11;    
    
  }

}

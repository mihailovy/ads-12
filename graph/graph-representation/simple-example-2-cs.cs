using System;

class Graph2 {
  
  static int[][] graph2 = new int[3][] ; // създаваме масив, който е празен  
    
  static void Main() {
    // Елементарен насочен граф, който използва масив в масив (Jagged Array)
  
    //        +-------------+
    //        |             V
    // 1 ---> 2 ---> 3 ---> 4
    // |             ^  
    // +-------------+
  
    graph2[1] = new int[] {2, 3}; 
    graph2[2] = new int[] {3, 4};
    graph2[3] = new int[] {4, 1};
  }

}

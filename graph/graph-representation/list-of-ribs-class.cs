using System;
using System.Collections.Generic;

class Ribs {
  
  int[][] graph = new int[20][] ; // създаваме масив, който е празен 
  int lastIndex = 0;
  
  private bool nodeExists(int node)
  { 
    try{
      for (int i = 0; i < graph.Length; i++) {
        if (graph[i][0] == node) {
          // if node 'from' exists in the list of ribs
          return true;
        }
        if (graph[i][1] == node) {
          // if node 'to; exists in the list of ribs
          return true;
        }
      }
    } catch(Exception e){
    }
    return false;
  }
  
  public void AddNode(int nodeNum)
  {
    // Добавяне на връх
    if (nodeExists(nodeNum) == false) {
      AddRib(nodeNum, 0);
    } 
  } 
  
  public void AddRib(int start, int stop)
  {
    // Добавяне на ребро
    graph[lastIndex] = new int[] {start, stop};
    lastIndex++;
  }
  
  public void DelNode(int node)
  {
    // Изтриване на връх
    try {
       int length = lastIndex;
       for (int i = 0; i < length; i++) {
// Console.WriteLine("debug: "+i+","+graph[i][0]+","+graph[i][1]);
         if (graph[i][0] == node) {
// Console.WriteLine("1) length = "+length+", node = "+node+", start = "+graph[i][0]+", stop = "+graph[i][1]);
           List<int[]> graphList = new List<int[]>(graph);
           graphList.RemoveAt(i);
           graph = graphList.ToArray();
         }
        if ( graph[i][1] == node){
// Console.WriteLine("2) length = "+length+", node = "+node+", start = "+graph[i][0]+", stop = "+graph[i][1]);
           List<int[]> graphList = new List<int[]>(graph);
           graphList.RemoveAt(i);
           graph = graphList.ToArray();
         }  
       }
    } catch (Exception e){
    }
  }
  
  public void DelRib(int start, int stop)
  {
    // Изтриване на ребро
    try {
       for (int i = 0; i < graph.Length; i++) {
         if (graph[i][0] == start && graph[i][1] == stop){
           List<int[]> graphList = new List<int[]>(graph);
           graphList.RemoveAt(i);
           graph = graphList.ToArray();
         } 
       }
    } catch (Exception e){
    }
  }
  
  public void Print()
  {
    try{ 
      for (int i = 0; i < graph.Length; i++) {
        Console.WriteLine(" ("+graph[i][0]+","+graph[i][1]+") ");
      }
    } catch(Exception e) {
    }
  }
  
}
  
class Graph {    
  static void Main() {
    
    Ribs g = new Ribs();
    
    // Елементарен насочен граф, който използва масив в масив (Jagged Array)
    //
    //        +-------------+
    //        |             V
    // 1 ---> 2 ---> 3 ---> 4      5
    // |             ^  
    // +-------------+
    g.AddRib(1, 2);
    g.AddRib(2, 3);
    g.AddRib(3, 4);
    g.AddRib(1, 3);
    g.AddRib(2, 4);  
    g.AddNode(5); 
    g.Print();
    //g.DelRib (3, 4);
    // g.DelNode(3);
    // g.Print();
  }

}

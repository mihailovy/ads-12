using System;

class Deikstra {
  
  /* Максимален брой върхове в графа */
  const int MAXN = 150;


  const int MAX_VALUE = 10000;
  const int NO_PARENT = -1;

  /* Брой върхове в графа */
  const int n = 10; // Брой на вяърховете в графа
  const int s = 1;  // Фиксиран връх, от който ще търсим път до останалите върхове

  /* Матрица на теглата на графа - без птрицателни стойности */
  static int[][] A = new int [n][]
  {
    new int[] { 0, 23, 0, 0, 0,  0,  0,  8, 0,  0 },
    new int[] {23,  0, 0, 3, 0,  0, 34,  0, 0,  0 },
    new int[] { 0,  0, 0, 6, 0,  0,  0, 25, 0,  7 },
    new int[] { 0,  3, 6, 0, 0,  0,  0,  0, 0,  0 },
    new int[] { 0,  0, 0, 0, 0, 10,  0,  0, 0,  0 },
    new int[] { 0,  0, 0, 0, 10, 0,  0,  0, 0,  0 },
    new int[] { 0, 34, 0, 0, 0,  0,  0,  0, 0,  0 },
    new int[] { 8,  0, 25,0, 0,  0,  0,  0, 0, 30 },
    new int[] { 0,  0, 0, 0, 0,  0,  0,  0, 0,  0 },
    new int[] { 0,  0, 7, 0, 0,  0,  0, 30, 0,  0 }
  };
  static int[] T    = new int[MAXN];    // Първоначално съсъдржа всич върхове на графа без s 
  static int[] d    = new int[MAXN];    // 
  static int[] pred = new int[MAXN];    // 

  /* Алгоритъм на Дейкстра - минимален път от s до останалите върхове */
  public static void Dijkstra(int s) {
    int i;
    
    for (i = 0; i < n; i++) {
      /* инициализиране: d[i]=A[s][i], iV, i != s */
      // d :
      // { MAX_VALUE,  23, MAX_VALUE , MAX_VALUE , MAX_VALUE ,  MAX_VALUE ,  MAX_VALUE ,  8, MAX_VALUE ,  MAX_VALUE }
      // pred :
      // {  NO_PARENT, 23,  NO_PARENT,  NO_PARENT,  NO_PARENT,   NO_PARENT,   NO_PARENT,  8,  NO_PARENT,   NO_PARENT },
      if (0 == A[s][i]) { // За s = 1 => А[0][i]
        d[i]    = MAX_VALUE;
        pred[i] = NO_PARENT;
      }
      else {
        d[i]    = A[s][i];
        pred[i] = s;
      }
    }
    // d[]:
    // {10000, 23, 10000, 10000, 10000, 10000, 10000, 8, 10000, 10000}
    
    // pred[]:
    // {-1   , 1 , -1   , -1   ,    -1,   -1,    -1, 1,    -1,    -1}
  
      
    // Иницилизираме масива T:
    // { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    for (i = 0; i < n; i++) {
      T[i] = 1; /* T съдържа всички върхове */
    }
    T[s] = 0;
    
    
    pred[s] = NO_PARENT; /* от графа, с изключение на s */
    
    
    while ( true ) { /* докато T съдържа i: d[i] < MAX_VALUE */
      
      /* избиране на върха j от T, за който d[j] е минимално */
      int j  = NO_PARENT;
      int di = MAX_VALUE; // 
      
      // Намиране:
      // - най-ниската стойност (минимум) на d[i]
      // - индекса на най-ниската стойност на d[i]
      for (i = 0; i < n; i++) {
        // Две условия:
        // 1.T[i] == 1, т.е. прескачаме фискирания от нас връх s
        // 2.d[i] < di
        if (T[i] ==  1 && d[i] < di) {
          di = d[i]; // минимално d[i] 
          j   = i;   // индекс на минимално d[i]
        }
      }
      
      // Не сме намерили минимум на d[i]
      if (NO_PARENT == j) {
        // d[i] = MAX_VALUE, за всички i: изход от while(0)
        break;
      }
      
      // Намерили сме минимимум на d[i]
      
      // изключваме j от T, т.е. този връх вече е проверен и не е
      // нужно да намираме неговия минимум отново
      T[j] = 0;
      
      /* за всяко i от T изпълняваме D[i] = min (d[i], d[j]+A[j][i]) */
      for (i = 0; i < n; i++) {
        // Две условия:
        //   1.T[i] == 1
        //   2.Матрицата на теглата за j,i да не е нула
        if (T[i] == 1 && A[j][i] != 0) {
          // Трето условие:
          // 3.d[i] > намереното минимално d[j] + Тегло от матрицата за j,1
          if (d[i] > d[j] + A[j][i]) {
            d[i]    = d[j] + A[j][i];
            pred[i] = j; // добавяме върха в масива от върхове
          }
        }
      }
          
    }// end: while(1)
}

  public static void printPath(int s, int j)
  {
    if (pred[j] != s)
      printPath(s, pred[j]);
    Console.Write(" "+j+1+" ");
  }

  /* Отпечатва намерените минимални пътища */
  public static void PrintResult(int s) {
    int i;
    for (i = 0; i < n; i++) {
      if (i != s) {
        if (d[i] == MAX_VALUE)
          Console.WriteLine("No path between node " +(s+1)+ " and "+(i+1)+"\n");
        else {
          Console.WriteLine("Minimum path from "+(s+1)+" to "+(i+1)+": "+(s+1));
          printPath(s, i);
          Console.WriteLine(", lengt of path: "+d[i]+"\n");
        }
      }
    }
  }

  public static void Main() {
    Dijkstra(s-1);    // Подаваме индекса на фиксирания връх
    PrintResult(s-1); // Подаваме индекса на фиксирания връх
  }

}

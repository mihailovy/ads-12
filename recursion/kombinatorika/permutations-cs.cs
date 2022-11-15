using System;
class Permutations {

  const uint n = 5;
  
  static uint[] used = new uint[n]; /* Съдържа използваните пермутации */
  static uint[] mp   = new uint[n]; /* съдържа генерираните пермутации */

  static void Print() {
    uint i;
    for (i = 0; i < n; i++) {
      Console.Write(mp[i] + 1);
    }
    Console.WriteLine();
  }

  static void Permute(uint i) {
    uint k;

    if (i >= n) {
      Print();
      return;
    }
    for (k = 0; k < n; k++) {
      // print();
      if (used[k] == 0) { /* Проверка дали пермутацията не е използвана */
        used[k] = 1;
        mp[i]   = k;
        Permute(i+1);
        /* if (ако има смисъл да продължава генерирането)
        { permute(i+1); } 
        */
        used[k] = 0;
      } else {
        // printf("Already used!"); 
      }
    }
  }

  static void Main() {
    uint i;
    for (i = 0; i < n; i++) {
      used[i] = 0;
    }
    Permute(0);
  }

}

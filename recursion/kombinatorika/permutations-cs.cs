using System;
class Permutations {

  const uint n = 4;
  
  static uint[] used     = new uint[n]; /* Съдържа използваните пермутации */
  static uint[] mp       = new uint[n]; /* съдържа генерираните пермутации */
  static string[] symbol = {"Boyan","Ivan","Drago","Peter"};
   
  static void Print() {
    uint i;
    for (i = 0; i < n; i++) {
      Console.Write(symbol[mp[i]]+ " ");
    }
    PrintMp();
    Console.WriteLine();
  }
  
  static void PrintMp()
  {
    Console.WriteLine();  
    Console.WriteLine("----------------------"); 
    Console.WriteLine("The mp array contains:");  
    for (uint i = 0; i < n; i++) {
      Console.WriteLine("mp["+i+"] = "+ mp[i]);
    }
    Console.WriteLine("----------------------");
  }

  static void Permute(uint i, uint level) {
    uint k;

    if (i >= n) {
      Print();
      return;
    }

    Console.WriteLine("Recursion level = "+level);
    Console.WriteLine("Start of loop");
    for (k = 0; k < n; k++) {
      // print();
      Console.WriteLine("i = "+i+", k = "+k);

      if (used[k] == 0) { /* Проверка дали пермутацията не е използвана */
        used[k] = 1;
        mp[i]   = k;
        Console.WriteLine("mp["+i+"] = " + k);
        Permute(i+1, level+1); 
        used[k] = 0;
      } else {
         // Console.WriteLine("Already used! "+k);
      }
    }
    Console.WriteLine("End of loop");

    // 0, 1, 2, 3, 4
  }

  static void Main() {
    uint i;
    for (i = 0; i < n; i++) {
      used[i] = 0;
    }
    Permute(0, 1);
  }

}

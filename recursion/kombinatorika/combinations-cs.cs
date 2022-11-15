using System;
class Hello {
  
  const uint n = 5; 
  const uint k = 3;
  static uint[] mp = new uint[100];

  
  static void Main() {
    Console.WriteLine( "C(" + n + "," + k + "):" );
    comb(1, 1);
  }  
  
  static void print(uint length) {
    uint i;
    for (i = 0; i < length; i++) {
       Console.Write(mp[i]);
    }
    Console.WriteLine("");
  }

  static void comb(uint i, uint after) {
    uint j;
    if (i > k) {
      return;
    }
    for (j = after; j <= n; j++) {
      mp[i - 1] = j;
      if (i == k) {
        print(i);
      }
      comb(i + 1, j);
    }
  }

}











using System;
class GcdClass {

  static ulong Nod(ulong a, ulong b) {
    if (b == 0) {
      return a;
    } else {
      return Nod(b, a % b);
    }
	} 

  static void Main() {	
    ulong a = 40;
    ulong b = 36;
    Console.WriteLine("NOD = " + Nod(a, b));  
  }
}

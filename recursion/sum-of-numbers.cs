// Намиране на сумата на числата от 1 до num
using System;
class SumOfNumbers {

  static int Solve(int sum, int i, int num)  
  {
	  if (i <= num) {
	    sum = Solve(sum, i + 1, num) + i;
	  }
	  Console.WriteLine("sum = " + sum);  
	  return sum;
  }

  static void Main() {
    int sum = 0;
	  
    // Вход 
    sum = Solve(0, 1, 20);
    Console.WriteLine("sum = "+sum);  
  }
}

// sum, i, num 
// 1  , 1, 3 -> 1, 2, 3


/*
int sum = 0;
for (int i = 1; i <= num; i++) {
   sum = sum + i;
}
Console.WriteLine("sum = "+sum);
*/

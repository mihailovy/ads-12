using System;

class Program
{
  
  static void Main(string[] args)
  {
    int amount    = 298;
    int remainder;
    //                       0   1   2  3  4  5  
    int[] banknotes     = {100, 20, 50, 5, 2, 1};
    int[] numBanknotes  = {  0,  0,  0, 0, 0, 0};
  
    //
    remainder = amount;
    for (int i = 0; i < 6; i++) {
      numBanknotes[i] = remainder / banknotes[i];
      remainder       = remainder % banknotes[i];
      Console.Write(numBanknotes[i]+ " * " + banknotes[i] + " лв." + "\n");
      Console.WriteLine();
    }
  }// end Main
}// end class




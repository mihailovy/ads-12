using System;
class Bublesort {

  static void Main() {
	  
    long[] myArray = {481, 238, 221, 103, 56, 5, 1};
    long   temp, num;
    int    numSwaps  = 0;
    int    numChecks = 0;
     
    num = myArray.Length;
    
    Console.WriteLine("");
	Console.Write("Init :");
	for (int j = 0; j < num ; j++) {
		Console.Write(myArray[j] + ", ");
	}
		
    for (int i = 0; i < num - 1; i++) {
		
		for (int j = 0; j < num - i - 1; j++) {
			numChecks++;
			if (myArray[j] > myArray[j+1]) {
				temp         = myArray[j+1];
				myArray[j+1] = myArray[j];
				myArray[j]   = temp;
				numSwaps++;
			}
		}
		Console.WriteLine("");
		Console.Write("i = " + i + " :");
		for (int j = 0; j < num ; j++) {
			Console.Write(myArray[j] + ", ");
		}
	}
	Console.WriteLine("");
	Console.WriteLine("Checks: " + numChecks);
	Console.WriteLine("Swaps: "  + numSwaps);

    /* Брой проверки:           num * (num - 1)/2
     * Максимален брой размени: num * (num - 1)/2
	/*
	i = 0
	j = 0, 1, 2, 3, 4, 5
	
	i = 1
	j = 0, 1, 2, 3, 4
	
	i = 2
	j = 0, 1, 2, 3
	
	i = 3
	j = 0, 1, 2
	
	i = 4
	j = 0, 1
	
	i = 5
	j = 0 
	*/
  }
}

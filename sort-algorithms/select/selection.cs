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
		
		int iMin = i; /* Индекс на минималния елемент */
		
		for (int j = i + 1; j < num; j++) {
			numChecks++;
			if (myArray[j] < myArray[iMin]) {
				iMin = j;
			}
		}
		if (i != iMin) {
			temp          = myArray[i];
			myArray[i]    = myArray[iMin];
			myArray[iMin] = temp;
			numSwaps++;
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

    /* Брой проверки:  num * (num - 1) / 2         
     * Максимален брой размени: num - 1
	*/
  }
}

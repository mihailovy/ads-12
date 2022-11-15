using System;
class Lectures {
  
	
  static void Main() {
    int i, j, temp, num;
    // Вход
    // 1 ***********
    // 2                                    ***********
    // 3     ******************
    // 4             ****************
    // 5                        ********
    // 6         ********
    // 7                              **************
    //   3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20
    //
    //  s, f,   status
    //  0, 1,   2      <- индекс
    int[,] lecture = { // i, j   номер на лекция
      //0  1    2
      { 3, 8  , 0},    // 0      1
      {17, 20 , 0},    // 1      2
      { 5, 12 , 0},    // 2      3
      { 9, 14 , 0},    // 3      4
      {13, 15 , 0},    // 4      5
      { 7, 10 , 0},    // 5      6
      {15, 19 , 0}     // 6      7
    };
    num = 7; // Брой лекции
	
    // begin: Sort		
    for (i = 0; i < num - 1; i++) {		
      int iMin = i; // Индекс на минималния елемент 
		
      for (j = i + 1; j < num; j++) {
        // Console.WriteLine("lecture j,1  = " + lecture[j,1]);
        // Console.WriteLine("lectureiMin,1  = " + lecture[iMin,1]);
        if (lecture[j,1] < lecture[iMin,1]) {
          iMin = j;
          // Console.WriteLine("I am in the if.");
        }
      }
      // Console.WriteLine("iMin = " + iMin);
      if (i != iMin) {
        temp            = lecture[i,0];
        lecture[i,0]    = lecture[iMin,0];
        lecture[iMin,0] = temp;
        temp            = lecture[i,1];
        lecture[i,1]    = lecture[iMin,1];
        lecture[iMin,1] = temp;
        temp            = lecture[i,2];
	    lecture[i,2]    = lecture[iMin,2];
	  	lecture[iMin,2] = temp;
      }
    }
    // end: Sort
    
    for (i = 0; i < num - 1; i++) {
      //  Console.WriteLine("lecture i = { " + lecture[i,0] + ","+ lecture[i,1] +","+ lecture[i,2]+"}");
    }		
    
    // Първата лекция е винаги избрана
    i = 1;
    Console.WriteLine("Избрана " + i); 
    lecture[0, 2] = 1; // status = 1
    
	// Output
    for (j = 1; j <= num; j++) {
		
      int si = lecture[i-1,0];
      int fi = lecture[i-1,1];	
      int sj = lecture[j-1,0];
      int fj = lecture[j-1,1];
      
      Console.WriteLine("Стъпка № " + j);
      Console.WriteLine("j-та лекция №" + j + " start = "+sj+", finish = "+fj);
      Console.WriteLine("i-та лекция №" + i + " start = "+si+", finish = "+fi);
      Console.WriteLine("Сравняваме " + sj + " с  " + fi );
      if (sj > fi && i != j) {
        i = j; // i-тата лекция е винаги последната избрана!!!
        Console.WriteLine("Избрана " + i);
        Console.WriteLine("i = " + i + ", j = " + j);
        lecture[i-1, 2] = 1; // status = 1
        Console.WriteLine("status("+(i-1)+") = " + lecture[i-1,2]);
      } else {
        Console.WriteLine("Отхвърлена " + i);
        Console.WriteLine("i = " + i + ", j = " + j);
      }
      Console.WriteLine("----");
    } 	
	  /*
    for (i = 1; i <= num; i++) {
      if (lecture[i-1, 2] == 1){
        Console.WriteLine("status("+i+") = 1");
      } else {
        Console.WriteLine("status("+i+") = 0");		  
      }
    } 
    */
    
    for (i = 0; i < num - 1; i++) {
      Console.WriteLine("lecture i = { " + lecture[i,0] + ","+ lecture[i,1] +","+ lecture[i,2]+"}");
    }		
    // Console.WriteLine(l.ToString());

    // 1 XXXXXXXXXXX
    // 2         ******** отхвърлена
    // 3     ****************** отхвърлена
    // 4             XXXXXXXXXXXXXXXX избрана
    // 5                        ********
    // 6                              XXXXXXXXXXXXXX
    // 7                                    ***********
    //   3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20
  }   
}

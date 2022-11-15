// Source: https://www.dotnetperls.com/maze

using System;

class Program
{
    const string _maze = @"
   xxx .
 x x   .
 x2x   .
 xxx   .
 xx1 x .
   x   .
      x";

//
/*
{0,  0,  0, -1, -1, -1,  1},
{0, -1,  0, -1,  0,  0,  0},
{0, -1, -3, -1,  0,  0, -1},
{0, -1, -1, -1,  0,  0,  0},
{0, -1,  0,  0,  0, -1,  0},
{0,  0,  0, -1,  0, -1, -1},  
*/
   
    static int[][] _moves = {
        new int[] { -1,  0 },   // ляво
        new int[] {  0, -1 },   // горе
        new int[] {  0,  1 },   // долу
        new int[] {  1,  0 } }; // дясно

    static int[][] GetMazeArray(string maze)
    {
        // Split apart the maze string.
        string[] lines = maze.Split(new char[] { '.', '\n', '\r' },
            StringSplitOptions.RemoveEmptyEntries);
            
        // Create jagged array.
        int[][] array = new int[lines.Length][]; // lines.Length - броя на редовете (6 бр.)
        
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i]; // текущия ред
            
            // Правим си редица
            var row = new int[line.Length]; // Брой символи в ред (7 бр.)
           
            // Пример 
            // {0,  0,  0, -1, -1, -1,  1},
            
            for (int x = 0; x < line.Length; x++)
            {
                // Set ints from chars.
                switch (line[x])
                {
                    case 'x':
                        row[x] = -1;
                        break;
                    case '1':
                        row[x] = 1;
                        break;
                    case '2':
                        row[x] = -3;
                        break;
                    default:
                        row[x] = 0;
                        break;
                }
            }
            // Store row in jagged array.
            array[i] = row;
        }
        return array;
    }

    static void Display(int[][] array)
    {
        // Loop over int data and display as characters.
        for (int i = 0; i < array.Length; i++)
        {
            var row = array[i];
            for (int x = 0; x < row.Length; x++)
            {
                switch (row[x])
                {
                    case -1:
                        Console.Write('x'); // препятствие
                        break;
                    case 1:
                        Console.Write('1'); // начало
                        break;
                    case -3:
                        Console.Write('2'); // край
                        break;
                    case 0:
                        Console.Write(' ');
                        break;
                    default:
                        Console.Write('.');
                        break;
                }
            }
            // End line.
            Console.WriteLine();
        }
    }

    static bool IsValidPos(int[][] array, int row, int newRow, int newColumn)
    {
        // ... Ensure position is within the array bounds.
        if (newRow < 0) { 
          // горен ръб
          return false;
        }
        if (newColumn < 0) {
          // ляв ръб;
          return false;
        }
        if (newRow >= array.Length) {
          // долен ръб
          return false;
        }
        if (newColumn >= array[row].Length) {
          // десен ръб
          return false;
        }
        return true;
    }

    static int ModifyPath(int[][] array)
    {
        // Циклим по редове (вертикал), след което по колони (хоризонтал)
        for (int rowIndex = 0; rowIndex < array.Length; rowIndex++)
        {
            var row = array[rowIndex]; // row съдържа масив от int
            
            // Пример 
            // {0,  0,  0, -1, -1, -1,  1},
            
            for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
            {
                // int стойност на текущата точка
                int value = array[rowIndex][columnIndex];
                
                if (value >= 1)
                {
                    // Тестваме всички възможни ходове
                    foreach (var movePair in _moves)
                    {
                        // Move to a valid square.
                        int newRow    = rowIndex + movePair[0];   // Избор на нова редица
                        int newColumn = columnIndex + movePair[1];// Избор на нова колона
                        
                        if (IsValidPos(array, rowIndex, newRow, newColumn))
                        {
                            int testValue = array[newRow][newColumn];
                            if (testValue == 0)
                            {
                                // Променяме стойността на точката с +1
                                array[newRow][newColumn] = value + 1;
                                // Move has been performed.
                                return 0;
                            }
                            else if (testValue == -3)
                            {
                                // Достигнали сме крайната точка
                                return 1;
                            }
                        }
                    }
                }
            }
        }
        
        // Няма път
        return -1;
    }

    static void Main()
    {
        // Визуализация на лабиринта.
        var array = GetMazeArray(_maze);
        Display(array);
       
        int count = 0; // Брой на ходовете

        // Read user input and evaluate maze.
        while (true)
        {
            string line = Console.ReadLine(); // очаква Enter
            
            int result = ModifyPath(array); // пускаме фунцкията, която търси път
            
            if (result == 1) {
                Console.WriteLine("Намерен път: "+count+" хода");
                break;
            } else if (result == -1) {
                Console.WriteLine("Не е намерен път: "+count+" хода");
                break;
            } else {
                Display(array);
            }
            count++;
        }
        Console.ReadLine();
    }
}

using System;
class NQueens {
	
	public const int N = 8;
	
	private static void PrintSolution(int[,] board)
	{
    Console.WriteLine("--------------");
		for (int i = 0; i < N; ++i)
		{
			for (int j = 0; j < N; ++j) {
				Console.Write(" {0} ", board[i, j]);
			}
			Console.WriteLine();
		}
    Console.WriteLine("--------------");
    Console.WriteLine();
	}
	
	private static bool IsSafe(int[,] board, int row, int col)
	{
		int i, j;
	
		for (i = 0; i < col; ++i)
			if (Convert.ToBoolean(board[row, i]))
				return false;
	
		for (i = row, j = col; i >= 0 && j >= 0; --i, --j)
			if (Convert.ToBoolean(board[i, j]))
				return false;
	
		for (i = row, j = col; j >= 0 && i < N; ++i, --j)
			if (Convert.ToBoolean(board[i, j]))
				return false;
	
		return true;
	}
	
	private static bool SolveNQ(int[,] board, int col)
	{
    if (col >= N) {
			return true;
		}
    PrintSolution(board);
		for (int i = 0; i < N; ++i)
		{
			if (IsSafe(board, i, col) == true) {
        Console.WriteLine("Решение прието, row = "+i+", col = "+col+" !");
				board[i, col] = 1; /* Слагаме царица */
				if (SolveNQ(board, col + 1))
					return true;
	
				board[i, col] = 0;
			} else {
        Console.WriteLine("Решение отхвърлено row = "+i+", col = "+col+" !");;        
      }
		}
	
		return false;
	}
	
	static void Main()
	{
		int[,] board = {
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
      { 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 }     
		};
		if (SolveNQ(board, 0) == false){
		}
		PrintSolution(board);
	}
}

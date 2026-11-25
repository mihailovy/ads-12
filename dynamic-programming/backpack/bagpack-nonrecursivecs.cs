
using System;

class Program
{
    const int MAXN = 30;
    const int MAXM = 1000;

    // Set of selected items
    static int[,] set = new int[MAXM, MAXN];

    // Objective function
    static uint[] Fn = new uint[MAXM];

    // Item weights
    static readonly uint[] m = {
        0, 30, 15, 50, 10, 20, 40, 5, 65
    };

    // Item values
    static readonly uint[] c = {
        0, 3, 3, 3, 3, 3, 3, 12, 3
    };

    // Knapsack data
    const int M = 70;
    const int N = 8;

    static void DisplayFn()
    {
        Console.WriteLine("\n\nFn[{0}]", M);

        for (int i = 0; i <= M; i++)
        {
            Console.WriteLine("{0} => {1},", i, Fn[i]);
        }
    }

    static void DisplaySet()
    {
        Console.WriteLine("\n");

        for (int i = 1; i <= M; i++)
        {
            for (int j = 1; j <= N; j++)
            {
                Console.Write(" {0}", set[i, j]);
            }

            Console.WriteLine();
        }
    }

    static void Calculate()
    {
        uint maxValue;
        int maxIndex;
        uint sumM = 0;

        // Initialize sets
        Array.Clear(set, 0, set.Length);

        // Calculate total weight
        for (int i = 1; i <= N; i++)
        {
            sumM += m[i];
        }

        if (sumM <= M)
        {
            Console.WriteLine("You can take all items");
            return;
        }

        // Calculate objective function
        for (int i = 1; i <= M; i++)
        {
            maxValue = 0;
            maxIndex = 0;

            // Find maximum value for current capacity
            for (int j = 1; j <= N; j++)
            {
                if (m[j] <= i &&
                    set[i - (int)m[j], j] == 0)
                {
                    uint candidate =
                        c[j] + Fn[i - (int)m[j]];

                    if (candidate > maxValue)
                    {
                        maxValue = candidate;
                        maxIndex = j;
                    }
                }
            }

            if (maxIndex > 0)
            {
                Fn[i] = maxValue;

                // Copy previous set
                for (int j = 0; j < N; j++)
                {
                    set[i, j] =
                        set[i - (int)m[maxIndex], j];
                }

                // Add selected item
                set[i, maxIndex] = 1;
            }

            // Preserve previous solution if better
            if (Fn[i] < Fn[i - 1])
            {
                Fn[i] = Fn[i - 1];

                for (int j = 0; j < N; j++)
                {
                    set[i, j] = set[i - 1, j];
                }
            }
        }

        DisplayFn();
        DisplaySet();

        // Display selected items
        Console.WriteLine("\nTake item #:");

        for (int i = 1; i <= N; i++)
        {
            if (set[M, i] == 1)
            {
                Console.Write("{0,5}", i);
            }
        }

        Console.WriteLine();

        Console.WriteLine(
            "Maximal value of Fn: {0}", Fn[M]);
    }

    static void Main(string[] args)
    {
        Calculate();

        Console.ReadKey();
    }
}

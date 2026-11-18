using System;

class Program
{
    static void Main()
    {
        int[] weights = {  3, 10, 2, 2, 3, 5, 6, 10 };
        int[] values  = { 10, 20, 6, 7, 4, 5, 2, 20 };
        int capacity = 10;

        int bestValue = 0;
        int bestMask = 0;

        // Test all combinations from 0 to 15
        for (int mask = 0; mask < 255; mask++)
        {
            int totalWeight = 0;
            int totalValue = 0;

            // Check each of the 4 items
            for (int i = 0; i < weights.Length; i++)
            {
                // If bit i of mask is 1 → take item i
                if ((mask & (1 << i)) != 0)
                {
                    totalWeight += weights[i];
                    totalValue += values[i];
                }
            }

            // Check capacity and update best solution
            if (totalWeight <= capacity && totalValue > bestValue)
            {
                Console.WriteLine("Current total value: " + totalValue);
                bestValue = totalValue;
                bestMask = mask;
            }
        }

        // Print results
        Console.WriteLine("Best value: " + bestValue);
        Console.WriteLine("Items taken:");

        for (int i = 0; i < weights.Length; i++)
        {
            if ((bestMask & (1 << i)) != 0)
                Console.WriteLine("  Item " + (i + 1));
        }
    }
}

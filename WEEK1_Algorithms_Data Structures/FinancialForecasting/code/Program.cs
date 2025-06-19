using System;
using System.Collections.Generic;

class Program
{
    public static double RecursiveFutureValue(double principal, double rate, int periods)
    {
        if (periods == 0)
            return principal; // Base case
        else
            return RecursiveFutureValue(principal, rate, periods - 1) * (1 + rate);
    }

    public static double RecursiveFutureValueMemo(double principal, double[] rates, int periods, Dictionary<int, double> memo)
    {
        if (periods == 0)
            return principal;
        if (memo.ContainsKey(periods))
            return memo[periods];
        double value = RecursiveFutureValueMemo(principal, rates, periods - 1, memo) * (1 + rates[periods - 1]);
        memo[periods] = value;
        return value;
    }

 
    public static double IterativeFutureValue(double principal, double rate, int periods)
    {
        double result = principal;
        for (int i = 0; i < periods; i++)
        {
            result *= (1 + rate);
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Financial Forecasting Tool (Recursive Example)\n");

        Console.Write("Enter initial principal amount: ");
        double principal = double.Parse(Console.ReadLine());

        Console.Write("Enter annual growth rate (e.g., 0.05 for 5%): ");
        double rate = double.Parse(Console.ReadLine());

        Console.Write("Enter number of years to forecast: ");
        int periods = int.Parse(Console.ReadLine());

        double futureValueRecursive = RecursiveFutureValue(principal, rate, periods);
        Console.WriteLine($"\nRecursive Future Value after {periods} years: {futureValueRecursive:F2}");

        double futureValueIterative = IterativeFutureValue(principal, rate, periods);
        Console.WriteLine($"Iterative Future Value after {periods} years: {futureValueIterative:F2}");

        Console.WriteLine("\nExample with variable annual rates and memoization:");
        double[] rates = new double[periods];
        for (int i = 0; i < periods; i++)
        {
            rates[i] = rate + (i * 0.002); 
        }
        var memo = new Dictionary<int, double>();
        double futureValueMemo = RecursiveFutureValueMemo(principal, rates, periods, memo);
        Console.WriteLine($"Memoized Recursive Future Value after {periods} years: {futureValueMemo:F2}");

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}

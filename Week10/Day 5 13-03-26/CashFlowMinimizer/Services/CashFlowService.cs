using CashFlowMinimizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashFlowMinimizer.Services
{
    public class CashFlowService
    {

        public List<string> MinimizeCashFlow(List<Bank> banks, List<Transaction> transactions)
        {
            int n = banks.Count;

            Dictionary<string, int> index = new();

            for (int i = 0; i < n; i++)
                index[banks[i].Name] = i;

            int[,] graph = new int[n, n];

            foreach (var t in transactions)
            {
                int d = index[t.Debtor];
                int c = index[t.Creditor];

                graph[d, c] = t.Amount;
            }

            int[] net = new int[n];

            for (int b = 0; b < n; b++)
            {
                int amount = 0;

                for (int i = 0; i < n; i++)
                    amount += graph[i, b];

                for (int j = 0; j < n; j++)
                    amount -= graph[b, j];

                net[b] = amount;
            }

            List<string> result = new();

            while (true)
            {
                int minIndex = GetMinIndex(net);
                int maxIndex = GetMaxIndex(net);

                if (minIndex == -1 || maxIndex == -1)
                    break;

                int transactionAmount = Math.Min(Math.Abs(net[minIndex]), net[maxIndex]);

                result.Add($"{banks[minIndex].Name} pays {transactionAmount} to {banks[maxIndex].Name}");

                net[minIndex] += transactionAmount;
                net[maxIndex] -= transactionAmount;
            }

            return result;
        }

        private int GetMinIndex(int[] net)
        {
            int min = int.MaxValue;
            int index = -1;

            for (int i = 0; i < net.Length; i++)
            {
                if (net[i] < min)
                {
                    min = net[i];
                    index = i;
                }
            }

            return index;
        }

        private int GetMaxIndex(int[] net)
        {
            int max = int.MinValue;
            int index = -1;

            for (int i = 0; i < net.Length; i++)
            {
                if (net[i] > max)
                {
                    max = net[i];
                    index = i;
                }
            }

            return index;
        }
    }
}
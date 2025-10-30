using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Csharp_All_Task
{
    internal class N_Queens
    {
        public IList<IList<string>> SolveNQueens(int n, List<IList<string>> result)
        {

            int[] queenAtCol = new int[n];
            for (int i = 0; i < n; i++)
            {
                DFS(0, i);
            }
            return result;

            void DFS(int row, int col)
            {
                queenAtCol[row] = col;

                if (row == n - 1)
                {
                    result.Add(queenAtCol.Select(tCol => new string('.', tCol - 0) + "Q" + new string('.', n - tCol - 1)).ToList());
                    return;
                }
                bool goNextCol;
                int nextRow = row + 1;
                for (int nextCol = 0; nextCol < n; nextCol++)
                {
                    if (AttackByQueen(nextRow, nextCol))
                        continue;

                    DFS(nextRow, nextCol);
                }
            }
            bool AttackByQueen(int row, int col)
            {

                for (int tRow = 0; tRow < row; tRow++)
                {
                    if (queenAtCol[tRow] == col || Math.Abs(col - queenAtCol[tRow]) == row - tRow)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void run()
        {
            N_Queens obj = new N_Queens();
            Console.WriteLine("---- N Queens ----");
            Console.Write("Enter the value of N (board size): ");
            int n = int.Parse(Console.ReadLine());
            List<IList<string>> result = new List<IList<string>>();
            IList<IList<string>> solutions = obj.SolveNQueens(n, result);
            Console.WriteLine($"\nTotal Solutions: {solutions.Count}\n");
            int count = 1;
            foreach (var board in solutions)
            {
                Console.WriteLine($"Solution {count++}:");
                foreach (var row in board)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
        }

    }
}


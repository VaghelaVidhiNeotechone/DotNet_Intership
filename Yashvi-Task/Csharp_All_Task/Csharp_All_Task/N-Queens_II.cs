using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class N_Queens_II
    {
        int[,] board;
        int res = 0;
        public int TotalNQueens(int n)
        {
            board = new int[n, n];
            PutOnRow(n, 0);
            return res;
        }

        private void PutOnRow(int n, int row)
        {
            if (row == n)
            {
                res += 1;
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (board[row, i] == 0)
                {
                    TagBoard(n, row, i, 1);
                    PutOnRow(n, row + 1);
                    TagBoard(n, row, i, -1);

                }
            }
        }

        private void TagBoard(int n, int row, int col, int tag)
        {
            for (int i = 0; i < n; i++)
            {

                board[i, col] += tag;
                board[row, i] += tag;
                if (row + i < n && col + i < n)
                    board[row + i, col + i] += tag;
                if (row - i >= 0 && col - i >= 0)
                    board[row - i, col - i] += tag;
                if (row + i < n && col - i >= 0)
                    board[row + i, col - i] += tag;
                if (row - i > 0 && col + i < n)
                    board[row - i, col + i] += tag;
            }
        }
        public static void run()
        {
            N_Queens_II obj = new N_Queens_II();
            Console.WriteLine("----  N_Queens_II ----");
            Console.Write("Enter the value of N (board size): ");
            int n = Convert.ToInt32(Console.ReadLine());
            double result = obj.TotalNQueens(n);
            Console.WriteLine("Result: " + result);
        }
    }
}

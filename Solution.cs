using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Solution
    {
        /// <summary>
        /// 找Q可以走的位置
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<ArrayList<string>> Findqueen(int n)
        {
            char[][] board =new char[n][];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = '.';
                }
            }
           
            List<ArrayList<string>> res = new List<ArrayList<string>>();
            dfs(board, 0, res);
            return res;
        }

        /// <summary>
        /// 找每個點的可能性，使用遞迴
        /// </summary>
        /// <param name="board"></param>
        /// <param name="colIndex"></param>
        /// <param name="res"></param>
        private void dfs(char[][] board, int colIndex, List<ArrayList<string>> res)
        {
            if (colIndex == board.Length)
            {
                res.Add(construct(board));
                return;
            }

            for (int i = 0; i < board.Length; i++)
            {
                if (validate(board, i, colIndex))
                {
                    board[i][colIndex] = 'Q';
                    dfs(board, colIndex + 1, res);
                    board[i][colIndex] = '.';
                }
            }
        }

        /// <summary>
        /// 驗證該點是否可以採
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Boolean validate(char[][] board, int x, int y)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (board[i][j] == 'Q' && (x + j == y + i || x + y == i + j || x == i))
                        return false;
                }
            }

            return true;
        }

        private ArrayList<string> construct(char[][] board)
        {
            ArrayList<string> res = new ArrayList<string>();
            for (int i = 0; i < board.Length; i++)
            {
                string s = new string(board[i]);
                res.Add(new List<string> {s});
            }
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFieldRichard
{
    public class minefield
    {
        public char[,] makeMap(int row, int col)
        {
            char[,] map = new char[row, col];
            for(int i = 0; i < row; i++)
            {
                for(int k = 0; k < col; k++)
                {
                    map[i,k] = '*';
                }
            }

            return map;
        }

        public char[,] mineHint(char[,] mineMap)
        {
            int row = mineMap.GetLength(0), col = mineMap.GetLength(1);
            int[,] mineHintMap = new int[row, col];
            char[,] output = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    mineHintMap[i, k] = 0;
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    if (mineMap[i, k] != '*')
                    {
                        mineHintMap[i, k] = numOfMine(mineMap, i, k, mineHintMap[i, k]);
                    }
                    else
                    {
                        mineHintMap[i, k] = -1;
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    if (mineHintMap[i, k] == -1)
                    {
                        output[i, k] = '*';
                    }
                    else output[i, k] = (char)(mineHintMap[i, k] + 48);
                }
            }

            return output;
        }
        public int numOfMine(char[,] mineMap, int row, int col, int sum)
        {
            int sumOfMine = sum;//九宮格內的地雷數量
            int I, K;
            if (row - 1 < 0) I = 0;
            else I = row - 1;

            if (col - 1 < 0) K = 0;
            else K = col - 1;
            for (int i = I; i < mineMap.GetLength(0) && i < row + 2; i++)
            {
                for (int k = K; k < mineMap.GetLength(1) && k < col + 2; k++)
                {
                    if (i == row && k == col) continue;
                    if (mineMap[i, k] == '*') sumOfMine++;
                }
            }

            return sumOfMine;
        }
    }
}

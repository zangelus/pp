using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class P005_rotate_2d_array
    {

        public int[,]? Rotate_2d_array_solution1(int[,] matrix, int n_dimension)
        {
            int num_rows = matrix.GetLength(0);
            int num_cols = matrix.GetLength(1);

            if (num_cols != num_rows) return null;

            //create new matrix
            int[,] newMatrix = new int[num_rows, num_cols];
            Array.Copy(matrix, 0, newMatrix, 0, matrix.Length-1);

            //create 1D buffer to hold rows
            int[] buff = new int[num_rows];

            //for(int row= num_rows - 1; row > 0; row--)
            //{
            //    Array.Copy(matrix.GetRw, newMatrix, num_rows);
            //
            //}


            return new int[,] { };
        }

        public int[,] Rotate_2d_array_solution2()
        {
            return new int[,] { };
        }

    }
}

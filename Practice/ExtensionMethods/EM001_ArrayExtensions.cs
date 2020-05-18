using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class EM001_ArrayExtensions
    {
        public static T[] GetRow<T>(this T[,] matrix, int row_number)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[row_number, x])
                .ToArray();
        }

        public static T[] GetColumn<T>(this T[,]matrix,  int col_number)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[x, col_number])
                .ToArray();
        }
    }
}

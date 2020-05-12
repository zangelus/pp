using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class P003_mine_sweeper
    {
        public int NumColumns { get; set; }
        public int NumRows { get; set; }

        public (int x, int y) MinPos { get; set; }
        public (int x, int y) MaxPos { get; set; }

        int[,] Matrix;

        public void CreateMatrix((int x, int y)[] position, int num_rows, int num_cols )
        {
            NumColumns = num_cols;
            NumRows = num_rows;

            MinPos = (0,0);
            MaxPos = (NumColumns-1, NumRows-1);

            //create matrix, everything is initialized to zero
            Matrix = new int[NumColumns, NumRows];

            //position the items and increase value of sourrounding positions
            for (int i=0; i<position.Length; i++)
            {
                Matrix[position[i].x, position[i].y] = -1;
                IncreaseOneInSouroundingSpace(position[i].x, position[i].y);
            }
        }

        private void IncreaseOneInSouroundingSpace(int posx, int posy)
        {
            for (int ix = posx -1; ix < posx + 2; ix++)
            {
                for (int iy = posy - 1; iy < posy + 2; iy++)
                {
                    if(ix >= MinPos.x && ix <= MaxPos.x &&
                       iy >= MinPos.y && iy <= MaxPos.y && 
                       Matrix[ix,iy] != -1)
                    {
                        Matrix[ix, iy] += 1;
                    }
                }
            }
        }

        public string PrettyPrint()
        {
            string result = String.Empty;

            for(int iy=0; iy<MaxPos.y + 1; iy++)
            {
                for (int ix = 0; ix < MaxPos.x + 1; ix++)
                {
                    int value = Matrix[ix, iy];
                    result += value >= 0 ? " "+value.ToString() : value.ToString();
                    if (ix != MaxPos.x) result += " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}

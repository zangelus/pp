using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class P004_mine_sweeper_expand
    {
        private (int row, int col) minIndex;
        private (int row, int col) maxIndex;

        public int[,] Breath_first_search(int[,] field, (int row, int col) click)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            int[,] matrix = new int[rows , columns ];
            Array.Copy(field,0,matrix,0,field.Length);

            if (matrix[click.row, click.col] != 0) { return matrix; }

            minIndex = (0, 0);
            maxIndex = (rows - 1, columns - 1);

            var nextPosition = new Queue<(int row, int col)>(new[] { (click.row, click.col)});

            while (nextPosition.Count != 0)
            {
                (int row, int col) currentPos = nextPosition.Dequeue();

                for(int col = currentPos.col - 1; col <= currentPos.col+1; col++)
                {
                    for (int row = currentPos.row - 1; row <= currentPos.row + 1; row++)
                    {
                        if (col == currentPos.col && row == currentPos.row)
                        {
                            if (matrix[row, col] == 0)
                            {
                                matrix[row, col] = -2;
                            }
                        }
                        else
                        {
                            if(col >= minIndex.col && col <= maxIndex.col &&
                               row >= minIndex.row && row <= maxIndex.row &&
                               matrix[row,col] == 0)
                            {
                                nextPosition.Enqueue((row, col));
                            }
                        }
                    }
                }
            }
            return matrix;
        }

        public int[,] Depth_first_search(int[,] field, (int row, int col) click)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            int[,] matrix = new int[rows, columns];
            Array.Copy(field, 0, matrix, 0, field.Length);

            if (matrix[click.row, click.col] != 0) { return matrix; }

            minIndex = (0, 0);
            maxIndex = (rows - 1, columns - 1);

            var stackedPos = new Stack<(int col, int row)>(new[] { (click.row, click.col) });

            while (stackedPos.Count != 0)
            {
                (int row, int col) currentPos = stackedPos.Peek();
                if(IsValid(currentPos) && matrix[currentPos.row, currentPos.col] == 0)
                {
                    matrix[currentPos.row, currentPos.col] = -2;
                }

                var pos = GetPosition(Direction.right, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.right_down, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.down, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.down_left, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.left, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.left_up, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.up, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                pos = GetPosition(Direction.up_right, currentPos);
                if (IsValid(pos) && matrix[pos.row, pos.col] == 0)
                {
                    stackedPos.Push(pos);
                    continue;
                }

                stackedPos.Pop();
            }

            return matrix;
        }
            
        private enum Direction{
            right,
            right_down,
            down,
            down_left,
            left,
            left_up,
            up,
            up_right
        }
        private (int row, int col) GetPosition(Direction direction, (int row, int col) currentPos)
        {
            (int row, int col) result = (0,0); 

            switch (direction)
            {
                case Direction.right:
                    result = (currentPos.row, currentPos.col + 1);
                    break;
                case Direction.right_down:
                    result = (currentPos.row + 1, currentPos.col + 1);
                    break;
                case Direction.down:
                    result = (currentPos.row + 1, currentPos.col );
                    break;
                case Direction.down_left:
                    result = (currentPos.row + 1, currentPos.col - 1);
                    break;
                case Direction.left:
                    result = (currentPos.row, currentPos.col - 1);
                    break;
                case Direction.left_up:
                    result = (currentPos.row - 1, currentPos.col - 1);
                    break;
                case Direction.up:
                    result = (currentPos.row - 1, currentPos.col);
                    break;
                case Direction.up_right:
                    result = (currentPos.row - 1, currentPos.col + 1);
                    break;
                default:
                    break; 
            }

            return result;
        }

        private bool IsValid((int row, int col) position)
        {
            if (position.col >= minIndex.col && position.col <= maxIndex.col &&
                   position.row >= minIndex.row && position.row <= maxIndex.row)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
 
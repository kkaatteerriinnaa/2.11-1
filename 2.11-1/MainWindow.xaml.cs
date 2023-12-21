using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2._11_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Game
        {
            private int[,] board;
            private Random random = new Random();

            public Game()
            {
                board = new int[4, 4];
                GenerateNewTile();
            }

            public void Move(MoveDirection direction)
            {
                switch (direction)
                {
                    case MoveDirection.Up:
                        MoveUp();
                        break;
                    case MoveDirection.Down:
                        MoveDown();
                        break;
                    case MoveDirection.Left:
                        MoveLeft();
                        break;
                    case MoveDirection.Right:
                        MoveRight();
                        break;
                }
                GenerateNewTile();
            }

            private void GenerateNewTile()
            {
                while (true)
                {
                    int row = random.Next(0, 4);
                    int col = random.Next(0, 4);

                    if (board[row, col] == 0)
                    {
                        board[row, col] = random.Next(1, 11) == 1 ? 4 : 2;
                        break;
                    }
                }
            }

            private void MoveLeft()
            {
                for (int i = 0; i < 4; i++)
                {
                    SlideRow(i);
                    CombineRow(i);
                    SlideRow(i);
                }
            }

            private void MoveRight()
            {
                for (int i = 0; i < 4; i++)
                {
                    SlideRowRight(i);
                    CombineRowRight(i);
                    SlideRowRight(i);
                }
            }

            private void MoveUp()
            {
                for (int j = 0; j < 4; j++)
                {
                    SlideColumn(j);
                    CombineColumn(j);
                    SlideColumn(j);
                }
            }

            private void MoveDown()
            {
                for (int j = 0; j < 4; j++)
                {
                    SlideColumnDown(j);
                    CombineColumnDown(j);
                    SlideColumnDown(j);
                }
            }

            private void SlideRow(int row)
            {
                int[] tempRow = new int[4];
                int index = 0;

                for (int j = 0; j < 4; j++)
                {
                    if (board[row, j] != 0)
                    {
                        tempRow[index] = board[row, j];
                        index++;
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    board[row, j] = tempRow[j];
                }
            }

            private void SlideRowRight(int row)
            {
                int[] tempRow = new int[4];
                int index = 3;

                for (int j = 3; j >= 0; j--)
                {
                    if (board[row, j] != 0)
                    {
                        tempRow[index] = board[row, j];
                        index--;
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    board[row, j] = tempRow[j];
                }
            }

            private void SlideColumn(int column)
            {
                int[] tempColumn = new int[4];
                int index = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (board[i, column] != 0)
                    {
                        tempColumn[index] = board[i, column];
                        index++;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    board[i, column] = tempColumn[i];
                }
            }

            private void SlideColumnDown(int column)
            {
                int[] tempColumn = new int[4];
                int index = 3;

                for (int i = 3; i >= 0; i--)
                {
                    if (board[i, column] != 0)
                    {
                        tempColumn[index] = board[i, column];
                        index--;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    board[i, column] = tempColumn[i];
                }
            }

            private void CombineRow(int row)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[row, j] == board[row, j + 1] && board[row, j] != 0)
                    {
                        board[row, j] *= 2;
                        board[row, j + 1] = 0;
                    }
                }
            }

            private void CombineRowRight(int row)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (board[row, j] == board[row, j - 1] && board[row, j] != 0)
                    {
                        board[row, j] *= 2;
                        board[row, j - 1] = 0;
                    }
                }
            }

            private void CombineColumn(int column)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, column] == board[i + 1, column] && board[i, column] != 0)
                    {
                        board[i, column] *= 2;
                        board[i + 1, column] = 0;
                    }
                }
            }

            private void CombineColumnDown(int column)
            {
                for (int i = 3; i > 0; i--)
                {
                    if (board[i, column] == board[i - 1, column] && board[i, column] != 0)
                    {
                        board[i, column] *= 2;
                        board[i - 1, column] = 0;
                    }
                }
            }
        }

        public enum MoveDirection
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}

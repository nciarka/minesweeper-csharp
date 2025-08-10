
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[10, 10]; 

            BoardBody(board);

            int bombs = 15;
            PlacesBombs(board, bombs);

            ShowBombs(board);

            bool[,] UncoveredFields = new bool[10, 10];

            bool[,] FlaggedFields = new bool[10, 10];

            GamePlay(board, UncoveredFields, FlaggedFields, bombs);

        }

        static void BoardBody(char[,] board) 
        {
            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 10; j++) 
                {
                    board[i, j] = '*';  
                }
            }
        }

        static void PlacesBombs(char[,] board, int bombs) 
        {
            Random r = new Random(); 
            while (bombs > 0) 
            {
                int row = r.Next(0, board.GetLength(0));
                int column = r.Next(0, board.GetLength(1));
                {
                    if (board[row, column] != 'X') 
                    {
                        board[row, column] = 'X'; 
                        bombs--; 
                    }
                }

            }
        }

        static int CountBombs(char[,] board, int row, int column) 
        {
            int count = 0; 
            for (int i = row - 1; i <= row + 1; i++) 
            {
                for (int j = column - 1; j <= column + 1; j++) 
                {
                    if (i >= 0 && i < board.GetLength(0) && j >= 0 && j < board.GetLength(1)) 
                    {
                        if (board[i, j] == 'X') 
                        {
                            count++;
                        }
                    }
                }
            }
            return count; 
        }

        static void ShowBombs(char[,] board) 
        {
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'X') 
                    {
                        Console.Write('X' + " ");
                    }
                    else 
                    {
                        Console.Write(CountBombs(board, i, j) + " "); 
                    }
                }
                Console.WriteLine(); 
            }
        }


        static bool DiscoveringFields(char[,] board, bool[,] UncoveredFields, int row, int column) 
        {
            if (row < 0 || row >= board.GetLength(0) || column < 0 || column >= board.GetLength(1)) 
                return false;

            if (UncoveredFields[row, column]) 
                return false;

            UncoveredFields[row, column] = true; 

            if (board[row, column] == 'X') 
            {
                Console.WriteLine("BOMB! Game Over");
                return true; 
            }
            return false; 
        }

        static bool CheckWin(char[,] board, bool[,] FlaggedFields, bool[,] UncoveredFields) 
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if ((board[i, j] == 'X' && !FlaggedFields[i, j]) || (board[i, j] != 'X' && !UncoveredFields[i, j])) 
                    {
                        return false; 
                    }
                }
            }
            return true;
        }

        static void ShowUncoveredOrFlaggedFields(char[,] board, bool[,] UncoveredFields, bool[,] FlaggedFields) 
        {
            Console.Clear();  
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (FlaggedFields[i, j])
                    {
                        Console.Write('F' + " ");
                    }
                    else if (UncoveredFields[i, j])
                    {
                        if (board[i, j] == 'X')
                        {
                            Console.Write('X' + " ");
                        }
                        else
                        {
                            Console.Write(CountBombs(board, i, j) + " ");
                        }
                    }
                    else
                    {
                        Console.Write('*' + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void GamePlay(char[,] board, bool[,] UncoveredFields, bool[,] FlaggedFields, int bombs) 
        {
            int FieldsWithoutBombs = (board.GetLength(0) * board.GetLength(1)) - bombs; 
            int DiscoveredFieldsWithoutBombs = 0; 
            bool GameOver = false; 

            while (!GameOver) 
            {
                ShowUncoveredOrFlaggedFields(board, UncoveredFields, FlaggedFields);  

                int row = -1, column = -1; 
                char action = ' '; 

                while (action != 'u' && action != 'f')
                {
                    Console.Write("Choose action (u - uncover field, f - flag field):  ");
                    string StartAction = Console.ReadLine();
                    if (StartAction[0] == 'u' || StartAction[0] == 'f')
                        action = StartAction[0];
                    else
                        Console.WriteLine("Game error");
                }

                while (row < 0 || row >= 10)
                {
                    Console.Write("Select Field - row(0-9): ");
                    string StartRow = Console.ReadLine();
                    if (StartRow[0] >= '0' && StartRow[0] <= '9') 
                        row = StartRow[0] - '0';
                    else
                        Console.WriteLine("Game error");
                }

                while (column < 0 || column >= 10)
                {
                    Console.Write("Select Field - column(0-9): ");
                    string StartColumn = Console.ReadLine();
                    if (StartColumn[0] >= '0' && StartColumn[0] <= '9')
                        column = StartColumn[0] - '0';
                    else
                        Console.WriteLine("Game error");
                }

                if (action == 'f')
                {
                    FlaggedFields[row, column] = !FlaggedFields[row, column]; 
                }
                else if (action == 'u' && !FlaggedFields[row, column])
                {
                    if (DiscoveringFields(board, UncoveredFields, row, column)) 
                    {
                        ShowUncoveredOrFlaggedFields(board, UncoveredFields, FlaggedFields);
                        Console.WriteLine("Bomb! Game over");
                        GameOver = true; 
                    }

                    else
                    {
                        DiscoveredFieldsWithoutBombs++; 
                        if (DiscoveredFieldsWithoutBombs == FieldsWithoutBombs) 
                        {
                            ShowUncoveredOrFlaggedFields(board, UncoveredFields, FlaggedFields);
                            Console.WriteLine("Win! All fields without bombs uncovered");
                            GameOver = true;
                        }
                        else if (CheckWin(board, FlaggedFields, UncoveredFields)) 
                        {
                            Console.WriteLine("Win! All bombs flagged");
                            ShowUncoveredOrFlaggedFields(board, UncoveredFields, FlaggedFields);
                            GameOver = true; 
                        }

                    }
                }
            }
        }
    }


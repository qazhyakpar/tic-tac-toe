using System;
//tic tac toe by Kazhyakpar Aibolat


class TicTacToe
{
    static char[,] board = new char[,]
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
    };

    static int turns = 0;
    static string player1, player2;

    static void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"|{board[i, 0]}|{board[i, 1]}|{board[i, 2]}|");
        }
    }

    static void ResetBoard()
    {
        board = new char[,]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };
    }

    static void ExampleBoard()
    {
        Console.WriteLine("This table is an example, in which order numbers are assigned in the table\n");
        Console.WriteLine("|1|2|3|");
        Console.WriteLine("|4|5|6|");
        Console.WriteLine("|7|8|9|\n");
    }

    static char CheckPlayerTurn()
    {
        return turns % 2 == 0 ? 'X' : 'O';
    }

    static void InputXO()
    {
        char playerMark = CheckPlayerTurn();
        string currentPlayer = playerMark == 'X' ? player1 : player2;

        Console.WriteLine($"{currentPlayer}'s turn :)");

        while (true)
        {
            try
            {
                int boardInput = int.Parse(Console.ReadLine());

                if (boardInput >= 1 && boardInput <= 9)
                {
                    int row = (boardInput - 1) / 3;
                    int col = (boardInput - 1) % 3;

                    if (board[row, col] == ' ')
                    {
                        board[row, col] = playerMark;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This cell is already marked, choose another one.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Do you really think that {boardInput} is in the range 1-9???\n");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }
    }

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
            {
                return true; // rows
            }

            if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
            {
                return true; // columns
            }
        }

        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
        {
            return true; // diagonals
        }

        if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != ' ')
        {
            return true; // diagonals
        }

        return false;
    }

    static void InputPlayerNames()
    {
        Console.Write("Enter name of Player 1 (X): ");
        player1 = Console.ReadLine();

        Console.Write("Enter name of Player 2 (O): ");
        player2 = Console.ReadLine();

        Console.WriteLine();
    }

    static void Main()
    {
        InputPlayerNames();
        ExampleBoard();

        while (true)
        {
            InputXO();
            DisplayBoard();

            if (CheckWin())
            {
                char winner = CheckPlayerTurn();
                Console.WriteLine($"Player '{(winner == 'X' ? player1 : player2)}' is the winner\n");
                break;
            }
            else if (turns == 8)
            {
                Console.WriteLine("Draw\n");
                break;
            }

            turns++;
        }

        MainMenu();
    }

    static void MainMenu()
    {
        Console.WriteLine("1. Start new game");
        Console.WriteLine("2. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ResetBoard();
                turns = 0;
                Main();
                break;
            case "2":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a valid option.\n");
                MainMenu();
                break;
        }
    }
}

//tic tac toe by Kazhyakpar Aibolat

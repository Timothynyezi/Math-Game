
using System.Security.Cryptography;

List<GameRecord> gameHistory = new List<GameRecord>();

bool isRunning = true;

ShowWelcome();

while (isRunning)
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("       MATH GAME MENU         ");
    Console.WriteLine("==============================");
    Console.WriteLine("1. Addition (+)");
    Console.WriteLine("2. Subtraction (-)");
    Console.WriteLine("3. Multiplication (x)");
    Console.WriteLine("4. Division (/)");
    Console.WriteLine("5. View Game History");
    Console.WriteLine("0. Exit");
    Console.WriteLine("------------------------------");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1":
            PlayGame("Addition", gameHistory);
            break;
        case "2":
            PlayGame("Subtraction", gameHistory);
            break;
        case "3":
            PlayGame("Multiplication", gameHistory);
            break;
        case "4":
            PlayGame("Division", gameHistory);
            break;
        case "5":
            ShowHistory(gameHistory);
            break;
        case "0":
            isRunning = false;
            ShowGoodby();
            break;
        default:
            Console.WriteLine("\n Invalid option. Please choose 0 -5.");
            Thread.Sleep(1500);
            Console.ReadKey();
            break;
    }
}

void ShowWelcome()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("      WELCOME TO MATH GAME    ");
    Console.WriteLine("==============================");
    Console.WriteLine("  Test your math skills!");
    Console.WriteLine("  Answer 5 questions per game.");
    Console.WriteLine("  Try all 4 operations.");
    Console.WriteLine("------------------------------");
    Console.WriteLine("  Press any key to start...");
    Console.ReadKey(); 
}

void ShowGoodby() 
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("        THANKS FOR PLAYING    ");
    Console.WriteLine("==============================");

    // Show a summary of all games played this session
    if (gameHistory.Count > 0)
    {
        Console.WriteLine($"  Games played  : {gameHistory.Count}");

        // LINQ — a powerful way to query collections.
        // Here we sum all scores across every game record.
        // We'll explain LINQ more as we use it going forward.
        int totalScore = 0;
        int totalPossible = 0;

        foreach (GameRecord r in gameHistory)
        {
            totalScore += r.Score;           // += adds to the existing value
            totalPossible += r.TotalQuestions;
        }

        Console.WriteLine($"  Total score   : {totalScore} / {totalPossible}");
        Console.WriteLine($"  Keep practising every day!");
    }

    Console.WriteLine("==============================");
    Thread.Sleep(2500); // Show goodbye screen for 2.5 seconds before closing
}

void PlayGame(string operation, List<GameRecord> history)
{
    Console.Clear();

    Random random = new Random();

    int totalQuestions = 5;
    int score = 0;

    Console.WriteLine("===============================");
    Console.WriteLine($"       {operation.ToUpper()} GAME");
    Console.WriteLine("===============================");
    Console.WriteLine($"Answer {totalQuestions} questions. Good luck!\n");
    
    for (int i = 1; i <= totalQuestions; i++)
    {
        int firstNumber;
        int secondNumber;
        int correctAnswer;

        if (operation == "Division")
        {
            correctAnswer = random.Next(1, 11);
            secondNumber = random.Next(1, 11);
            firstNumber = correctAnswer * secondNumber;
        }
        else
        {
            firstNumber = random.Next(1, 21);
            secondNumber = random.Next(1, 21);

            correctAnswer = operation switch
            {
                "Addition"      => firstNumber + secondNumber,
                "Subtraction"   => firstNumber - secondNumber,
                "Multiplication"=> firstNumber * secondNumber,
                _                => 0
            };
        }

        string symbol = operation switch
        {
            "Addition"      => "+",
            "Subtraction"   => "-",
            "Multiplication"=> "*",
            "Division"      => "/",
            _               => "?"
        };

        Console.Write($"Question {i}: {firstNumber} {symbol} {secondNumber} =");

        int playerAnswer;
        bool isValidInput = int.TryParse(Console.ReadLine(), out playerAnswer); 

        while (!isValidInput)
        {
            Console.Write("Please enter a valid number: ");
            isValidInput = int.TryParse(Console.ReadLine(), out playerAnswer);
        }

        if (playerAnswer == correctAnswer)
        {
            score++;
            Console.WriteLine("Correct!\n");
        }
        else
        {
            Console.WriteLine($"Wrong! The answer was {correctAnswer}\n");
        }
    }
    Console.WriteLine("==============================");
    Console.WriteLine($"Game Over! You scored {score} out of {totalQuestions}");
    Console.WriteLine("==============================");

    GameRecord record = new GameRecord(operation, score, totalQuestions);
    history.Add(record);

    Console.WriteLine("Result saved to history.");
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}

void ShowHistory(List<GameRecord> history)
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("        GAME HISTORY          ");
    Console.WriteLine("==============================");

    
    if (history.Count == 0)
    {
        Console.WriteLine("No games played yet.");
    }
    else
    {
        foreach (GameRecord record in history)
        {
            Console.WriteLine($"Date     : {record.DatePlayed:dd MMM yyyy HH:mm}");
            Console.WriteLine($"Operation: {record.Operation}");
            Console.WriteLine($"Score    : {record.Score} / {record.TotalQuestions}");
            Console.WriteLine("------------------------------");
        }
    }

    Console.ReadKey();
}


class GameRecord
{
    public string Operation { get; set; }   
    public int Score { get; set; }          
    public int TotalQuestions { get; set; } 
    public DateTime DatePlayed { get; set; }

    public GameRecord(string operation, int score, int totalQuestions)
    {
        Operation = operation;
        Score = score;
        TotalQuestions = totalQuestions;
        DatePlayed = DateTime.Now; 
    }
}
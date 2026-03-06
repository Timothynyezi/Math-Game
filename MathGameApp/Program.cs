
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
            Console.WriteLine("Invalid option. Please try again.");
            Console.ReadKey();
            break;
    }
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
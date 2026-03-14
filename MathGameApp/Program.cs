
using System.ComponentModel.Design.Serialization;

List<GameRecord> gameHistory = new List<GameRecord>();
bool isRunning = true;

ShowWelcome();

while (isRunning)
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("       MATH GAME MENU         ");
    Console.WriteLine("==============================");
    Console.WriteLine("  1. Addition       (+)");
    Console.WriteLine("  2. Subtraction    (-)");
    Console.WriteLine("  3. Multiplication (x)");
    Console.WriteLine("  4. Division       (/)");
    Console.WriteLine("  5. View Game History");
    Console.WriteLine("  0. Exit");
    Console.WriteLine("------------------------------");
    Console.Write("  Choose an option: ");

    string choice = Console.ReadLine()?.Trim(); // ?. safely handles null

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
            ShowGoodbye();
            break;
        default:
            
            Console.WriteLine("\n Invalid option. Please choose 0 - 5.");
            Thread.Sleep(1500); 
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

void ShowGoodbye()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("        THANKS FOR PLAYING    ");
    Console.WriteLine("==============================");

    if (gameHistory.Count > 0)
    {
        Console.WriteLine($"  Games played  : {gameHistory.Count}");

       
        int totalScore = 0;
        int totalPossible = 0;

        foreach (GameRecord r in gameHistory)
        {
            totalScore += r.Score;         
            totalPossible += r.TotalQuestions;
        }

        Console.WriteLine($"  Total score   : {totalScore} / {totalPossible}");
        Console.WriteLine($"  Keep practising every day!");
    }

    Console.WriteLine("==============================");
    Thread.Sleep(2500); 
}

void PlayGame(string operation, List<GameRecord> history)
{
    Console.Clear();

    Random random = new Random();
    int totalQuestions = 5;
    int score = 0;

    Console.WriteLine("==============================");
    Console.WriteLine($"       {operation.ToUpper()} GAME");
    Console.WriteLine("==============================");
    Console.WriteLine($"  Answer {totalQuestions} questions. Good luck!\n");

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
                "Addition"       => firstNumber + secondNumber,
                "Subtraction"    => firstNumber - secondNumber,
                "Multiplication" => firstNumber * secondNumber,
                _                => 0
            };
        }

        string symbol = operation switch
        {
            "Addition"       => "+",
            "Subtraction"    => "-",
            "Multiplication" => "x",
            "Division"       => "/",
            _                => "?"
        };

        
        Console.WriteLine($"  --- Question {i} of {totalQuestions} ---");
        Console.Write($"  {firstNumber} {symbol} {secondNumber} = ");

        // NULL-SAFE INPUT HANDLING
        // Console.ReadLine() can return null if the input stream
        // ends unexpectedly. The '?.' operator (null-conditional)
        // safely calls .Trim() only if the string is not null.
        // If it IS null, the whole expression returns null instead
        // of throwing a NullReferenceException (crash).
        
        int playerAnswer;
        string input = Console.ReadLine()?.Trim();
        bool isValidInput = int.TryParse(input, out playerAnswer);

        
        while (!isValidInput)
        {
            Console.Write("Please enter a whole number: ");
            input = Console.ReadLine()?.Trim();
            isValidInput = int.TryParse(input, out playerAnswer);
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

    ShowResults(operation, score, totalQuestions);

    GameRecord record = new GameRecord(operation, score, totalQuestions);
    history.Add(record);

    Console.WriteLine("\n  Press any key to return to the menu...");
    Console.ReadKey();
}

void ShowResults(string operation, int score, int total)
{
    double percentage = (double)score / total * 100;
    Console.WriteLine("==============================");
    Console.WriteLine("           RESULTS            ");
    Console.WriteLine("==============================");
    Console.WriteLine($"  Operation : {operation}");
    Console.WriteLine($"  Score     : {score} / {total}");
    
    Console.WriteLine($" Percentage :  {percentage:F1}");
    Console.WriteLine($" Rating     :  {GetRating(score, total)}");
    Console.WriteLine($"  {GetPerformanceMessage(score, total)}");
    Console.WriteLine("===============================");
}

string GetRating(int score, int total)
{
    double percentage = (double)score / total * 100;

    
    if (percentage == 100) return "Perfect!";
    if (percentage >= 80)  return "Great!";
    if (percentage >= 60)  return "Good";
    if (percentage >= 40)  return "Keep Practising";
                           return "Keep Trying!";
}

string GetPerformanceMessage(int score, int total)
{
    double percentage = (double)score / total * 100;

    if (percentage == 100) return "Flawless! You got every question right!";
    if (percentage >= 80)  return "Nearly perfect — great job!";
    if (percentage >= 60)  return "Solid effort — keep it up!";
    if (percentage >= 40)  return "You're getting there — practice makes perfect!";
                           return "Don't give up — try again!";
}

void ShowHistory(List<GameRecord> history)
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("        GAME HISTORY          ");
    Console.WriteLine("==============================");

    if (history.Count == 0)
    {
        Console.WriteLine("  No games played yet.");
        Console.WriteLine("  Play a game first then come back!");
    }
    else
    {
        Console.WriteLine($"  Total games played: {history.Count}\n");

        for (int i = 0; i < history.Count; i++)
        {
            GameRecord record = history[i]; 

            double percentage = (double)record.Score / record.TotalQuestions * 100;

            Console.WriteLine($"  Game #{i + 1}");  // i + 1 so it shows 1, not 0
            Console.WriteLine($"  Date      : {record.DatePlayed:dd MMM yyyy HH:mm}");
            Console.WriteLine($"  Operation : {record.Operation}");
            Console.WriteLine($"  Score     : {record.Score} / {record.TotalQuestions}");
            Console.WriteLine($"  Percentage: {percentage:F1}");
            Console.WriteLine($"  Rating    : {GetRating(record.Score, record.TotalQuestions)}");
            Console.WriteLine("  ----------------------------");
        }
    }

    Console.WriteLine("\n  Press any key to return to the menu...");
    Console.ReadKey();
}

int GetNumberOfQuestions()
{
    Console.WriteLine("\n How many questions would you like? (minimum 5)");
    Console.WriteLine(" Enter a number: ");

    int numberOfQuestions;
    string input = Console.ReadLine()?.Trim();
    bool isValid = int.TryParse(input, out numberOfQuestions);

    while (!isValid || numberOfQuestions < 5)
    {
        Console.WriteLine("Please enter a whole number of 5 or more: ");
        input = Console.ReadLine()?.Trim();
        isValid = int.TryParse(input, out numberOfQuestions);
    }


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
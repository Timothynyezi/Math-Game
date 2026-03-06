
List<GameRecord> gameHistory = new List<GameRecord>();

bool isRunning = true;

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

    string choice = Console.ReadLine();

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
            Console.WriteLine("Thanks for playing. Goodbye!");
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
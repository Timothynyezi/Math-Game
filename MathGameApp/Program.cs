bool isRunning = true; // this is to control whether the menu will keep on looping

while (isRunning)
{
    Console.Clear();

    Console.WriteLine("=========================");
    Console.WriteLine("         MATH MENU       ");
    Console.WriteLine("=========================");
    Console.WriteLine("1. Addition (+)");
    Console.WriteLine("2. Subtraction (-)");
    Console.WriteLine("3. Multiplication (x)");
    Console.WriteLine("4. Division (/)");
    Console.WriteLine("5. View Game History");
    Console.WriteLine("0. Exit");
    Console.WriteLine("-------------------------");
    Console.WriteLine("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("You chose Addition - game coming soon!");
            Console.ReadKey();
            break;
        case "2":
            Console.WriteLine("You chose Subtraction - game coming soon!");
            Console.ReadKey();
            break;
         case "3":
            Console.WriteLine("You chose Multiplication - game coming soon!");
            Console.ReadKey();
            break;
         case "4":
            Console.WriteLine("You chose Division - game coming soon!");
            Console.ReadKey();
            break;
         case "5":
            Console.WriteLine("History coming soon!");
            Console.ReadKey();
            break;
         case "0":
            Console.WriteLine("Thanks for playing. Goodbye!");
            Console.ReadKey();
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
   Console.WriteLine($"Starting {operation} game...");
   Console.WriteLine("Game logic coming in step 3"); 

   GameRecord record = new GameRecord(operation, 3, 5);
   history.Add(record);

   Console.WriteLine($"Test record saved for {operation}.");
   Console.ReadKey();
}



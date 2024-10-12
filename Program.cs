// See https://aka.ms/new-console-template for more information
internal class Program
{
  static int PlayerScore = 0;
  static int ComputerScore = 0;
  static readonly string[] Choices = ["Rock", "Paper", "Scissors"];
  static readonly Dictionary<string, string> WinConditions = new() { { "Rock", "Scissors" }, { "Paper", "Rock" }, { "Scissors", "Paper" } };
  private static void Main()
  {
    string playerHand = ChooseHand();
    Console.WriteLine($"You chose {playerHand}.");
    string computerHand = GetComputerHand();
    Console.WriteLine($"Computer chose {computerHand}.");

    if (playerHand == computerHand)
    {
      Console.WriteLine("DRAW GAME");
    }
    else if (WinConditions[playerHand] == computerHand)
    {
      Console.WriteLine("YOU WIN");
      PlayerScore++;
    }
    else
    {
      Console.WriteLine("YOU LOSE");
      ComputerScore++;
    }

    Thread.Sleep(2000);
    Console.Clear();

    Console.WriteLine($"Player Score: {PlayerScore} | Computer Score: {ComputerScore}");

    Console.WriteLine("Play again? y/n");

    ConsoleKeyInfo key = Console.ReadKey();

    if (key.Key == ConsoleKey.Y)
    {
      Main();
    }
  }

  static string ChooseHand(int choiceIndex = 0)
  {
    Console.Clear();
    Console.WriteLine("Which hand do you want to play?");
    for (int i = 0; i < Choices.Length; i++)
    {
      string choice = Choices[i];
      if (choiceIndex == i)
      {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        choice = "> " + choice;
      }
      Console.WriteLine(choice);
      Console.ResetColor();
    }
    ConsoleKeyInfo key = Console.ReadKey();

    switch (key.Key)
    {
      case ConsoleKey.UpArrow:
      case ConsoleKey.LeftArrow:
        choiceIndex = choiceIndex == 0 ? Choices.Length - 1 : choiceIndex - 1;
        return ChooseHand(choiceIndex);
      case ConsoleKey.RightArrow:
      case ConsoleKey.DownArrow:
        choiceIndex = choiceIndex == Choices.Length - 1 ? 0 : choiceIndex + 1;
        return ChooseHand(choiceIndex);
      case ConsoleKey.Enter:
        return Choices[choiceIndex];
      case ConsoleKey.Escape:
        Environment.Exit(0);
        return "Exit Application";
      default:
        return ChooseHand(choiceIndex);
    }
  }

  static string GetComputerHand()
  {
    int randomIndex = new Random().Next(Choices.Length);
    return Choices[randomIndex];
  }

}
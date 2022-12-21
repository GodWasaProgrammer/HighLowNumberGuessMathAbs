namespace HighLowNumberGuessMathAbs
{
    internal class Program
    {
        static void Main()
        {
            int guessAsInt;
            int range = 5;
            int result;
            const int MAXGUESS = 101;
            const int LOWESTGUESS = 0;
            bool isParsable;
            string gameLoop;
            do
            {
                int chances;
                int secretNumber = new Random().Next(0, 101);
                chances = 5;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to our number guessing game. \n Make a guess between zero and hundred");
                do
                {
                    Console.WriteLine($"Current Chances:{chances}");
                    // loop on if the tryparse is succesful or not
                    do
                    {
                        Console.WriteLine("Input your guess");
                        isParsable = Int32.TryParse(Console.ReadLine(), out guessAsInt);
                        if (isParsable == false)
                        {
                            Console.WriteLine("Your input was not acceptable. try again");
                        }

                        if (guessAsInt > MaxGuess || guessAsInt < LowestGuess)
                        {
                            Console.WriteLine("You were so far off you might aswell be in Narnia... \n Guess should be between 0 and 100!");
                            isParsable = false;
                        }

                    }
                    while (isParsable == false);

                    chances--;
                    // calculates the difference between the guess and secret number to determine if we are in range or out of range
                    result = Math.Abs(guessAsInt - secretNumber);
                    if (secretNumber == guessAsInt)
                    {
                        Console.WriteLine("You have won ze game!");
                        break;
                    }

                    else
                    {
                        if (result < range && guessAsInt > secretNumber)
                        {
                            Console.WriteLine($"Too High! You are {result} off!");
                        }

                        if (result < range && guessAsInt < secretNumber)
                        {
                            Console.WriteLine($"Too Low! You are {result} off!");
                        }

                        else
                        {
                            if (guessAsInt > secretNumber && result > range)
                            {
                                Console.WriteLine("Too High!");
                            }

                            if (guessAsInt < secretNumber && result > range)
                            {
                                Console.WriteLine("Too low!");
                            }

                        }
                        if (chances == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You Lose!");
                        }

                    }
                } while (chances > 0);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Would you like to play again? if so, type y");
                gameLoop = Console.ReadLine();
            } while (gameLoop == "y");

        }
    }
}
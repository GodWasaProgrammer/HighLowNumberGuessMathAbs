namespace HighLowNumberGuessMathAbs
{
    internal class Program
    {
        static void Main()
        {
            int guessAsInt;
            int range = 5;
            int result;
            const int MAXVALUE = 101;
            const int LOWESTVALUE = 0;
            bool isParsable;
            string gameLoop;
            do
            {
                int chances;
                int secretNumber = new Random().Next(MAXVALUE);
                chances = 5;

                Console.ForegroundColor = ConsoleColor.DarkRed;
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

                        if (guessAsInt > MAXVALUE || guessAsInt < LOWESTVALUE)
                        {
                            Console.WriteLine($"You were so far off you might aswell be in Narnia... \n Guess should be between {LOWESTVALUE} and {MAXVALUE}!");
                            isParsable = false;
                        }

                    }
                    while (isParsable == false);

                    chances--;
                    // calculates the difference between the guess and secret number to determine if we are in range or out of range

                    if (secretNumber == guessAsInt)
                    {
                        Console.WriteLine("You have won ze game!");
                        break;
                    }

                    result = Math.Abs(guessAsInt - secretNumber);

                    if (result < range)
                    {
                        if (guessAsInt > secretNumber)
                        {
                            Console.WriteLine($"Too High! But close... You are {result} off!");
                        }

                        if (guessAsInt < secretNumber)
                        {
                            Console.WriteLine($"Too Low! But close... You are {result} off!");
                        }
                    }

                    if (result > range)
                    {
                        if (guessAsInt > secretNumber)
                        {
                            Console.WriteLine("Too High!");
                        }

                        if (guessAsInt < secretNumber)
                        {
                            Console.WriteLine("Too low!");
                        }

                    }

                    if (chances == 0)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You Lose!");
                    }

                } while (chances > 0);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Would you like to play again? if so, type y");
                gameLoop = Console.ReadLine();
            } while (gameLoop == "y");

        }
    }
}
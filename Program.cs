namespace HighLowNumberGuessMathAbs
{
    internal class Program
    {
        const int MAXVALUE = 100;
        const int LOWESTVALUE = 0;
        static void Main()
        {
            int guessAsInt;
            int range = 5;
            int result;
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
                            
                        }

                    } while (isParsable == false);

                    // You lost a chance because parse passed.
                    chances--;

                    // calculates the difference between the guess and secret number to determine if we are in range or out of range
                    if (secretNumber == guessAsInt)
                    {
                        Console.WriteLine("You have won ze game!");
                        break;
                    }

                    else
                    {
                        // calculates the difference between the guess and secret number to determine if we are in range or out of range
                        result = Math.Abs(guessAsInt - secretNumber);

                        // if our guess is over our secret number
                        if (guessAsInt > secretNumber)
                        {
                            Console.WriteLine("Too high!");
                            // if the difference between the guess and the secret number is less then our predetermined range of 5
                            if (result < range)
                            {
                                Console.Write($"But you are close {result} off!");
                            }

                        }

                        // if our guess is under our secret number
                        if (guessAsInt < secretNumber)
                        {
                            Console.WriteLine("Too low!");
                            // if the difference between the guess and the secret number is less then our predetermined range of 5
                            if (result < range)
                            {
                                Console.Write($"But you are close {result} off!");
                            }

                        }

                        // If you run out of chances you lose
                        if (chances == 0)
                        {

                            Console.WriteLine("You Lose!");
                        }

                    }

                } while (chances > 0);

                Console.WriteLine("Would you like to play again? if so, type y");
                gameLoop = Console.ReadLine();

            } while (gameLoop == "y");

        }
    }
}
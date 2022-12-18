namespace HighLowNumberGuessMathAbs
{
    internal class Program
    {
        static void Main()
        {
            int guessAsInt;
            int secretNumber = new Random().Next(0, 100);
            int range = 5;
            int result;
            bool isParsable;
            int chances = 5;
            // loop on if the tryparse is succesful or not
            do
            {
                do
                {
                    Console.WriteLine($"Current Chances:{chances}");
                    Console.WriteLine("Input your guess");
                    isParsable = Int32.TryParse(Console.ReadLine(), out guessAsInt);
                }
                while (isParsable == false);
                chances--;
                // calculates the difference between the guess and secret number to determine if we are in range or out of range
                result = Math.Abs(guessAsInt - secretNumber);
                if (result < range)
                {
                    Console.WriteLine($"You are {result} off!");
                }
                else
                {
                    Console.WriteLine("You are more then 5 off!");
                }
                if (secretNumber == guessAsInt)
                {
                    Console.WriteLine("You have won ze game!");
                    Console.WriteLine("Game Restarting");
                    chances = 5;
                    secretNumber = new Random().Next(0, 100);
                }
                if (chances == 0)
                {
                    Console.WriteLine("You Lose!");
                    chances = -1;
                }
            } while (chances > -1);
        }
    }
}
using System;

class Mastermind
{
    static void Main(string[] args)
    {
        // Generate a random 4-digit answer with digits between 1 and 6
        Random random = new Random();
        int[] answer = new int[4];
        for (int i = 0; i < 4; i++)
        {
            answer[i] = random.Next(1, 7);
        }

        int attempts = 10;

        Console.WriteLine("Try to guess the 4-digit number, 1 ~ 6");
        Console.WriteLine("You have 10 attempts. Try now!");

        while (attempts > 0)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            if (input.Length != 4 || !IsAllDigits(input))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            int[] guess = new int[4];
            for (int i = 0; i < 4; i++)
            {
                guess[i] = int.Parse(input[i].ToString());
            }

            if (IsCorrectGuess(guess, answer))
            {
                Console.WriteLine("Congratulations!");
                break;
            }

            int plusCount = 0;
            int minusCount = 0;
            bool[] checkedAnswer = new bool[4];
            bool[] checkedGuess = new bool[4];

            // Check for correct digits in the correct position (+)
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == answer[i])
                {
                    plusCount++;
                    checkedAnswer[i] = true;
                    checkedGuess[i] = true;
                }
            }

            // Check for correct digits in the wrong position (-)
            for (int i = 0; i < 4; i++)
            {
                if (!checkedGuess[i])
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (!checkedAnswer[j] && guess[i] == answer[j])
                        {
                            minusCount++;
                            checkedAnswer[j] = true;
                            break;
                        }
                    }
                }
            }

            // Display the result
            Console.WriteLine(new string('+', plusCount) + new string('-', minusCount));

            attempts--;

            if (attempts == 0)
            {
                Console.WriteLine("You've run out of attempts. The correct number was: " + string.Join("", answer));
            }
        }

        Console.WriteLine("Game Over!");
    }

    static bool IsAllDigits(string s)
    {
        foreach (char c in s)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    static bool IsCorrectGuess(int[] guess, int[] answer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] != answer[i])
            {
                return false;
            }
        }
        return true;
    }
}
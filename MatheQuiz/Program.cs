internal class Program
{
    
    enum QuestionType : int
    {
        Subtraction,
        Addition,
        Multiplication,
        Division
    }

    private const int MaxValue = 101;
    private const int MinValue = 1;
    private const int MinQuestionRoll = 0;
    private const int MaxQuestionRoll = 4;
    private const int MaxMultiplication = 1001;
    private static readonly Random roll = new();
    public static void Ask()
    {
        int life = 3;
        int correctAnswer = MinQuestionRoll;
        int num1 = roll.Next(MinValue, MaxValue);
        int num2 = roll.Next(MinValue, MaxValue);

        QuestionType questionType = (QuestionType)roll.Next(MinQuestionRoll, MaxQuestionRoll);

        switch (questionType)
        {
            case QuestionType.Subtraction:
                correctAnswer = num1 - num2;
                Console.WriteLine($"{num1} - {num2} = ?");
                break;
            case QuestionType.Addition:
                correctAnswer = num1 + num2;
                Console.WriteLine($"{num1} + {num2} = ?");
                break;
            case QuestionType.Multiplication:
                while (num1 * num2 >= MaxMultiplication)
                {
                    num1 = roll.Next(MinValue, MaxValue);
                    num2 = roll.Next(MinValue, MaxValue);
                }
                correctAnswer = num1 * num2;
                Console.WriteLine($"{num1} * {num2} = ?");
                break;
            case QuestionType.Division:
                while (num1 % num2 != 0)
                {
                    num1 = roll.Next(MinValue, MaxValue);
                    num2 = roll.Next(MinValue, MaxValue);
                }
                correctAnswer = num1 / num2;
                Console.WriteLine($"{num1} / {num2} = ?");
                break;
        }
        Console.WriteLine("");

        while (life >= 0)
        {
            string? userInput = Console.ReadLine();

            if (userInput.ToLower() == "skip")
            {
                    Console.Clear();
                    Console.WriteLine("Question skipped!");
                    Ask();
            }

            if (int.TryParse(userInput, out int numericInput))
            {
                if (numericInput == correctAnswer)
                {
                    Console.Clear();
                    Console.WriteLine(Motivate());
                    Ask();
                }
                else
                {
                    Console.WriteLine(life == 1 ? "Last chance!" : "Try again.");
                    life--;
                }
            }
        }
    }

    private static string Motivate()
    {
        string[] motivations =
        [
            "Great job!",
            "Correct answer!",
            "Good job!",
            "You got this!"
        ];
        return motivations[roll.Next(0, motivations.Length)];
    }
    private static void Start()
    {
        Console.WriteLine("You have 3 tries for every question.\nType 'skip' to skip current question.\nYou can write down your own notes.\nPress any key to start.");
        Console.ReadKey();
        Console.Clear();
        Ask();
    }

    private static void Main(string[] args)
    {
        Start();
    }
}

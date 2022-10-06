class DonutCompetition
{
    static Random Random = new Random();
    static int[] results;
    
    static void Main()
    {
        Console.Clear();
        Console.Write("This is the 'Donut Competitoin'. To win this competition ");
        Console.WriteLine("participants should as many donuts as possible in 10 minutes.");
        bool undone = true;
        int N;

        while (undone)
        {
            Console.Write("How many participants do you like to participate in this: ");
            
            if (int.TryParse(Console.ReadLine(), out N))
            {
                results = new int[N];
                StartCompetition(N);
                undone = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Try Again!");
            }
        }
    }

    static void StartCompetition(int n)
    {
        Console.ForegroundColor = (ConsoleColor) Random.Next(1, 14);

        for (int i = 1; i <= 10; i++)
        {
            Console.Clear();
            Console.WriteLine($"Time: {i}");

            for (int j = 0; j < n; j++)
            {
                Console.Write($"Number of eaten donuts by participant {j+1}: ");
                Console.WriteLine((results[j] += Random.Next(1, 4)));
            }
            Thread.Sleep(1500);
        } 

        Array.Sort(results);
        Console.WriteLine($"\nThe winner has eaten {results[^1]} donuts.");
        Console.WriteLine($"The runner-up has eaten {results[^2]} donuts.");
        Console.WriteLine($"The third result is {results[^3]} donuts.");
        Console.WriteLine($"And the worst result is {results[0]} donuts.\n");
    }
}
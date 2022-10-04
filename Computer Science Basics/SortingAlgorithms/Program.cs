class Program
{
        static int lowerBound = -17;
        static int upperBound = 77;
        static int length = 17;
        static int[] numbers = new int[length];
        static string[] sorts = { "Bubble", "Heap", "Insertion", "Merge", "Quick", "Radix", "Selection" };

    static void Main()
    {
        foreach (var sort in sorts)
        {
            CheckSorting(sort);
        }        
    }

    static void CheckSorting(string sort)
    {
        Sort.FillArray(numbers, lowerBound, upperBound);
        switch (sort.ToLower())
        {
            case "bubble":
            default:
                SetBackground(ConsoleColor.Blue);
                Sort.Bubble(numbers);
                break;
            case "heap":
                SetBackground(ConsoleColor.Yellow);
                Sort.Heap(numbers);
                break;
            case "insertion": 
                SetBackground(ConsoleColor.Gray);
                Sort.Insertion(numbers);
                break;
            case "merge":
                SetBackground(ConsoleColor.Green);
                Sort.Merge(numbers);
                break;
            case "quick":
                SetBackground(ConsoleColor.Red);
                Sort.Quick(numbers, 0, numbers.Length - 1);
                break;
            case "radix":
                SetBackground(ConsoleColor.Magenta);
                Sort.Radix(numbers);
                break;
            case "selection":
                SetBackground(ConsoleColor.Cyan);
                Sort.Selection(numbers);
                break;
        }
        
        Console.Write($"After {sort} Sort: ");
        Sort.PrintArray(numbers);
    }

    static void SetBackground(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write("Initial Array: ");
        Sort.PrintArray(numbers);
    }
}


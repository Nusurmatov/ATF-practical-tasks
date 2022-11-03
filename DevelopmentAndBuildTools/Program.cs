namespace DevelopmentAndBuildTools
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter some text: ");
            string text = Console.ReadLine() ?? String.Empty;

            byte max = GetTotalConsecutiveUnequalChars(text);
            Console.WriteLine($"There are maximum {max} consecutive unequal characters.");
        }

        static byte GetTotalConsecutiveUnequalChars(string text)
        {
            bool undone = true;
            byte max = 0;
            while (undone)
            {
                if (text == String.Empty)
                {
                    Console.Clear();
                    Console.WriteLine("Nothing Entered... ");
                    Console.Write("Please, do not play, enter something: ");
                    text = Console.ReadLine() ?? String.Empty;
                }
                else
                {
                    byte count = 1;
                    for (int i = 0; i < text.Length - 1; i++)
                    {
                        if (text[i + 1] != text[i])
                        {
                            count++;
                        }
                        else
                        {
                            count = 1;
                        }

                        if (count > max)
                        {
                            max = count;
                        }
                    }

                    undone = false;
                }
            }

            return max;
        }

    }
}

/* Output:
Please, enter some text: apple
There are maximum 3 consecutive unequal characters.
Please, enter some text: asssapoikjkkasfag
There are maximum 8 consecutive unequal characters.
Nothing Entered...
Please, do not play, enter something: okay
There are maximum 4 consecutive unequal characters.
*/
class Sort
{
    private static int permutations;
    private static int comparisons;

    public static void Bubble(int[] numbers)
    {
        bool needIteration = true;
        int length = numbers.Length;

        while (needIteration)
        {
            needIteration = false;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j+1])
                    {
                        numbers[j] = numbers[j] ^ numbers[j+1];
                        numbers[j+1] = numbers[j+1] ^ numbers[j];
                        numbers[j] = numbers[j] ^ numbers[j+1];
                        needIteration = true;
                        permutations++;
                    }
                    comparisons++;
                }        
            }
        }
    }      

    public static void Heap(int[] numbers)
    {
        int i;
        for (i = numbers.Length/2-1; i >= 0; i--)
        {
            Heapify(numbers, numbers.Length, i);  // build max heap
        }

        for (i = numbers.Length - 1; i >= 0; i--)
        {
            (numbers[i], numbers[0]) = (numbers[0], numbers[i]);
            permutations++;
            Heapify(numbers, i, 0);
        }
    } 

    private static void Heapify(int[] numbers, int length, int start)
    {
        int largest = start;
        int left = 2 * start + 1;
        int right = 2 * start + 2;

        if (left < length && numbers[left] > numbers[largest])
        {
            largest = left;
        }

        if (right < length && numbers[right] > numbers[largest])
        {
            largest = right;
        }
        comparisons += 2;

        if (largest != start)
        {
            (numbers[start], numbers[largest]) = (numbers[largest], numbers[start]);
            permutations++;
            comparisons++;
            Heapify(numbers, length, largest);
        }
    }

    public static void Insertion(int[] numbers)
    {
        int i, j, key, length = numbers.Length;

        for (i = 1; i < length; i++)
        {
            key = numbers[i];
            j = i - 1;
            while (j >= 0 && numbers[j] > key)
            {
                numbers[j+1] = numbers[j];
                j--;
                permutations++;
            }
            comparisons++;
            numbers[j+1] = key;
            permutations++;
        }
    }      

    public static void Merge(int[] numbers)
    {
        if (numbers.Length > 1)
        {
            int mid = numbers.Length / 2;
            int[] left = numbers[..mid];
            int[] right = numbers[mid..];

            Merge(left);
            Merge(right);

            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    numbers[k] = left[i];
                    i++;
                }
                else
                {
                    numbers[k] = right[j];
                    j++;
                }
                k++;  permutations++;  comparisons++;
            }

            while (i < left.Length)
            {
                numbers[k] = left[i];
                i++;  k++;
                permutations++;  comparisons++;
            }

            while (j < right.Length)
            {
                numbers[k] = right[j];
                j++;  k++;
                permutations++;  comparisons++;
            }
        }
    }

    public static void Quick(int[] numbers, int left, int right)
    {
        if (left < right)
        {
            int key = partition(numbers, left, right);
            Quick(numbers, left, key - 1);
            Quick(numbers, key + 1, right);
        }
    }

    private static int partition(int[] numbers, int left, int right)
    {
        int key = numbers[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (numbers[j] < key)
            {
                i++;
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
            permutations++; comparisons++;
        }

        (numbers[i+1], numbers[right]) = (numbers[right], numbers[i+1]);
        permutations++;
        return ++i;
    }

    public static void Radix(int[] numbers)
    {

    } 

    public static void Selection(int[] numbers)
    {
        int i, j, min, length = numbers.Length;

        for (i = 0; i < length; i++)
        {
            min = i;
            for (j = i + 1; j < length; j++)
            {
                if (numbers[min] > numbers[j])
                {
                    min = j;
                }
                comparisons++;
            }

            (numbers[i], numbers[min]) = (numbers[min], numbers[i]);
            permutations++; 
        }
    }

    public static void FillArray(int[] array, int lowerBound, int upperBound)
    {
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(lowerBound, upperBound);
        }
    }

    public static void PrintArray(int[] array)
    {
        Console.Write("{ ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(i != array.Length - 1 ? $"{array[i]}, " : $"{array[i]}");
        }

        Console.WriteLine(" }.");

        if (permutations != 0)
        {
            Console.WriteLine("Number of Permutations: {0}.", permutations);
            Console.WriteLine("Number of Comparisons: {0}.\n", comparisons);
            permutations = comparisons = 0;
        }
    }
}
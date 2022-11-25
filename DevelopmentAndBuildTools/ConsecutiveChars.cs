namespace DevelopmentAndBuildTools
{
    public class ConsecutiveChars
    {
        static int GetTotalConsecutiveUnequalChars(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            bool undone = true;
            int max = 0;
            int count = 1;

            while (undone)
            {

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

            return max;
        }

        static int GetMaxConcsecutiveIndenticalLatinLetters(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            int max = 0;
            int count = 0;
            bool undone = true;
            
            while (undone)
            {
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if (IsLatinLatter(text[i]) && (text[i+1] == text[i]))
                    {
                        count++;
                    }
                    else if (IsLatinLatter(text[i]))
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

            return max;
        }

        static int GetMaxConsecutiveIdenticalDigits(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            int max = 0;
            int count = 0;
            bool undone = true;

            while (undone)
            {
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if (Char.IsDigit(text[i]) && (text[i + 1] == text[i]))
                    {
                        count++;
                    }
                    else if (Char.IsDigit(text[i]))
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
            
            return max;
        }

        private static bool IsLatinLatter(char c) => (c > 64 && c < 91) || (c > 96 && c < 123);
    }
}
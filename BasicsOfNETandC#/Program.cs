Console.Write("Enter a decimal integer: ");
bool undone = true;
int number;
int baseN;

while(undone)
{
    if (int.TryParse(Console.ReadLine(), out number))
    {
        Console.Write("Now enter a base number system (from 2 to 20): ");
        if (int.TryParse(Console.ReadLine(), out baseN))
        {
            if (baseN > 20 || baseN < 2)
            {
                Console.WriteLine("Please enter an integer base ranging " +
                    "from 2 to 20, inclusive...!");
                Console.Write("Enter an integer: ");
            }
            else
            {
                Console.WriteLine("The result of the converting {0} to base {1} " +
                    "system is {2}.", number, baseN, ConvertNumber(number, baseN));
                undone = false;
            }
        }
    }
    else
    {
        Console.Write("Please, enter an INTEGER (...,-2,-1,0,1,2...): ");
    }
}

string ConvertNumber(int n, int b)
{
    string result = String.Empty;
    
    while (n > 0)
    {
        int remainder = n % b;
        switch (remainder)
        {
            case 10: result = "A" + result; break;
            case 11: result = "B" + result; break;
            case 12: result = "C" + result; break;
            case 13: result = "D" + result; break;
            case 14: result = "E" + result; break;
            case 15: result = "F" + result; break;
            case 16: result = "G" + result; break;
            case 17: result = "H" + result; break;
            case 18: result = "I" + result; break;
            case 19: result = "J" + result; break;
            case 20: result = "K" + result; break;
            default: result = (n % b) + result; break; 
        }

        n = n / b;
    }

    return result;
}

/* Sample Input and Output:
Enter a decimal integer: 25
Now enter a base number system (from 2 to 20): 7
The result of the converting 25 to base 7 system is 34.
Enter a decimal integer: 465.4
Please, enter an INTEGER (...,-2,-1,0,1,2...): 34
Now enter a base number system (from 2 to 20): 17
The result of the converting 34 to base 17 system is 20.
Enter a decimal integer: 77
Now enter a base number system (from 2 to 20): 21
Please enter an integer base ranging from 2 to 20, inclusive...!
Enter an integer: 777
Now enter a base number system (from 2 to 20): 19
The result of the converting 777 to base 19 system is 22H.
*/
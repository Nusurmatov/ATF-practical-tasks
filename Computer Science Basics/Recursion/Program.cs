class DartCompetition
{
    static Random Random = new Random();
    static int[,] highPoints = new int[4, 5];

    static void Main()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("There are 3 teams with 4 participants in this" + 
                " 'Dart Competition'. Each player has 3 attemps.");
            Console.WriteLine("Enter 1 to enter scores of participants manually,");
            Console.Write("   or 2 to let the computer do it automatically and randomly: ");
            
            byte option;
            if (byte.TryParse(Console.ReadLine(), out option))
            {
                AcceptParticipantScores(1, option);
                AcceptParticipantScores(2, option);
                AcceptParticipantScores(3, option);
                PrintTheHighestPoint(1);
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again!");
            }
        }
    }

    static void AcceptParticipantScores(int team, byte option)
    {
        Console.WriteLine("Now enter points (between 1 and 60) for participants of team {0} (e.g, 17 24 57):", team);
        int score = 1;

        for (int i = 1; i < 5; i++)
        {
            Console.Write($"Team {team}, participant {i}, attempts: ");
            for (int j = 1; j < 4; j++)
            {
                if (option == 1)
                {
                    highPoints[team, i] = Console.ReadLine().Split(" ").ToArray().Max(int.Parse);
                    break;
                }                
                else
                {
                    score = Random.Next(1, 61);
                    Console.Write($"{score} ");
                }

                if (highPoints[team, i] < score)
                {
                    highPoints[team, i] = score;
                }
            }

            PrintTheHighestPoint(start: team);
        }
    }

    static void PrintTheHighestPoint(int start)
    {
        int max = 0;
        int team = 1;
        int participant = 1;

        for (int i = start; i < highPoints.GetLength(0); i++)
        {
            for (int j = 1; j < highPoints.GetLength(1); j++)
            {
                if (highPoints[i, j] > max)
                {
                    (max, team, participant) = (highPoints[i,j], i, j);
                }
            }
        }

        Console.Write($"\nThe highest point is {max} and scored by participant {1}, team {team}.\n");    
    }
}
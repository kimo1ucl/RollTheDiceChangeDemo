﻿using System;


namespace RollTheDiceLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mode = "Random";

            if (args.Length == 4)
            {
                //http://www.java2s.com/Tutorial/Cpp/0040__Data-Types/Logicaloperators.htm
                if (
                    (int.Parse(args[0]) > 0 && int.Parse(args[0]) < 7) &&
                    (int.Parse(args[1]) > 0 && int.Parse(args[1]) < 7) &&
                    (int.Parse(args[2]) > 0 && int.Parse(args[2]) < 7) &&
                    (int.Parse(args[3]) > 0 && int.Parse(args[3]) < 7)
                   )
                {
                    mode = "Test";
                }
                else
                {
                    Console.WriteLine("!--> one or more arguments not within range (1-6)");
                    Console.WriteLine("!--> game runs in random mode");
                }

            }

            Console.WriteLine("this is a game where you will roll 2 dices, then I will roll 2 dices.");
            Console.WriteLine("We will evaluate the dices:");
            Console.WriteLine("- if only one of us has to dices showing equal eyes, then we have a winner");
            Console.WriteLine("- if we both has to dices showing equal eyes, then the one having largets will win");
            Console.WriteLine("You are running the game in " + mode + " mode");

            Random rand = new Random();
            bool proceed = true;

            int dice_1_1 = 0;
            int dice_1_2 = 0;
            int dice_2_1 = 0;
            int dice_2_2 = 0;
            while (proceed)
            {
                Console.WriteLine("You roll the dices - press <Return> to continue:");
                Console.ReadLine();

                if (mode == "Random")
                {
                    dice_1_1 = rand.Next(1, 7);
                    dice_1_2 = rand.Next(1, 7);
                    dice_2_1 = rand.Next(1, 7);
                    dice_2_2 = rand.Next(1, 7);
                }
                else if (mode == "Test")
                {
                    dice_1_1 = int.Parse(args[0]);
                    dice_1_2 = int.Parse(args[1]);
                    dice_2_1 = int.Parse(args[2]);
                    dice_2_2 = int.Parse(args[3]);
                }
                Console.WriteLine(string.Format("Your roll: {0} - {1}", dice_1_1.ToString(), dice_1_2.ToString()));
                Console.WriteLine(string.Format("My roll: {0} - {1}", dice_2_1.ToString(), dice_2_2.ToString()));


                // Kald til metode
                proceed = GameMaster(dice_1_1, dice_1_2, dice_2_1, dice_2_2);

                Console.ReadLine();
            }
        }

        static bool GameMaster(int dice_1_1,
            int dice_1_2,
            int dice_2_1, 
            int dice_2_2) 
        {
            bool proceed = true;
            bool player_equal;
            bool opponent_equal;
            int countEquals = 0;
            player_equal = dice_1_1 == dice_1_2;
            opponent_equal = dice_2_1 == dice_2_2;
            if (player_equal)
            {
                countEquals++;
            }
            if (opponent_equal)
            {
                countEquals++;
            }

            if (countEquals == 1)
            {
                if (player_equal)
                {
                    Console.WriteLine("You win!");
                }
                if (opponent_equal)
                {
                    Console.WriteLine("I win!");
                }
                proceed = false;
            }

            if (countEquals == 2)
            {
                if ((dice_1_1 + dice_1_2) > (dice_2_1 + dice_2_2))
                {
                    Console.WriteLine("You win!");
                    proceed = false;
                }
                if ((dice_1_1 + dice_1_2) < (dice_2_1 + dice_2_2))
                {
                    Console.WriteLine("I win!");
                    proceed = false;
                }
                if ((dice_1_1 + dice_1_2) == (dice_2_1 + dice_2_2))
                {
                    Console.WriteLine("Draw! Continuing");
                }
            }
            return proceed;
        }
    }
}
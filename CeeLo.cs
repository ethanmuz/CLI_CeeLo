using System;

namespace CeeLo
{
    /**
     * This program simulates a game of Cee-Lo
     * 
     * @author Ethan Uzarowski github/ethanmuz
     */
    class CeeLo
    {
        /**
         * The Main method begins the game and is the skeleton for the gameplay
         */
        public static void Main()
        {
            Console.WriteLine("Welcome to Cee-Lo!\n");
            Console.WriteLine("Please enter Player 1's name");
            String name1 = Console.ReadLine();
            Console.WriteLine("Please enter Player 2's name");
            String name2 = Console.ReadLine();
            Console.WriteLine("");

            int firstWinner = GetFirstWinner(name1, name2); // Determine who will go first

            if (firstWinner == 1)
            {
                GetWinner(name1, name2);
            }
            else
            {
                GetWinner(name2, name1);
            }

            Console.WriteLine("Play Again? (Yes/no)");
            String response = Console.ReadLine().ToLower();
            if (response.Equals("yes") || response.Equals(""))
            {
                Console.Clear();
                Main();
            }
        }

        /**
        * This method determines who goes first 
        */
        public static int GetFirstWinner(String name1, String name2)
        {
            int firstroll1 = GetFirstRoll(name1);
            int firstroll2 = GetFirstRoll(name2);

            if (firstroll1 > firstroll2)
            {
                Console.WriteLine(name1 + " rolls first.\n");
                return 1;
            }
            else if (firstroll2 > firstroll1)
            {
                Console.WriteLine(name2 + " rolls first.\n");
                return 2;
            }
            else
            {
                Console.WriteLine("TIED! Roll again!\n");
                return GetFirstWinner(name1, name2);
            }
        }

        /**
         * This method gets the first-roll score for a player
         */
        public static int GetFirstRoll(String name)
        {
            Console.WriteLine(name + ", it's your turn to take the first roll!");
            Console.WriteLine("Please type \"roll\" to roll!");
            while (!Console.ReadLine().ToLower().Equals("roll"))
            {
                Console.WriteLine("Please type \"roll\" to roll!");
            }

            Random rnd = new Random();
            int roll = rnd.Next(1, 7);
            Console.WriteLine(name + ", you rolled a " + roll + "\n");

            return roll;
        }

        /**
         * This method gets the rolls for each player and then displays the winner
         */
        public static void GetWinner(String name1, String name2)
        {
            Console.WriteLine(name1 + ", it's your turn to roll!");
            int roll1 = GetRoll(name1);
            Console.WriteLine(name2 + ", it's your turn to roll!");
            int roll2 = GetRoll(name2);

            if (roll1 > roll2)
            {
                Console.WriteLine(name1 + " wins!\n");
            }
            else if (roll2 > roll1)
            {
                Console.WriteLine(name2 + " wins!\n");
            }
            else
            {
                Console.WriteLine("TIED! Roll again!\n");
                GetWinner(name2, name1);
            }
        }

        /**
         * This method rolls the dice and gives the player a score, as long as their roll was valid
         */
        public static int GetRoll(String name)
        {
            Console.WriteLine("Please type \"roll\" to roll!");
            while (!Console.ReadLine().ToLower().Equals("roll"))
            {
                Console.WriteLine("Please type \"roll\" to roll!");
            }

            Random rnd = new Random();
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            int dice3 = rnd.Next(1, 7);

            Console.WriteLine("\n" + dice1 + " " + dice2 + " " + dice3 + "\n");     // Display the dice roll

            Console.WriteLine(name + ", you rolled " + getRollName(dice1, dice2, dice3) + "!\n");

            int score = getRollScore(dice1, dice2, dice3);

            if (score != -1)    // As long as it is a valid roll
                return score;

            return GetRoll(name);   // Otherwise, roll again
        }

        /**
         * This method determines the name for a roll, so that it can be understood by the player
         */
        public static String getRollName(int dice1, int dice2, int dice3)
        {
            if (dice1 == dice2 && dice2 == dice3)   // All dice are the same
            {
                return "Trip " + dice1 + "'s";
            }

            if (dice1 == 4 || dice2 == 4 || dice3 == 4)             // One of the dice is a 4
                if (dice1 == 5 || dice2 == 5 || dice3 == 5)         // One of the dice is a 5
                    if (dice1 == 6 || dice2 == 6 || dice3 == 6)     // One of the dice is a 6
                        return "4-5-6";

            if (dice1 == 1 || dice2 == 1 || dice3 == 1)             // One of the dice is a 1
                if (dice1 == 2 || dice2 == 2 || dice3 == 2)         // One of the dice is a 2
                    if (dice1 == 3 || dice2 == 3 || dice3 == 3)     // One of the dice is a 3
                        return "1-2-3";

            if (dice1 == dice2)
                return "a " + dice3;    // dice3 is the odd die out
            if (dice2 == dice3)
                return "a " + dice1;    // dice1 is the odd die out
            if (dice1 == dice3)
                return "a " + dice2;    // dice2 is the odd die out

            return "nothing";   // Roll is invalid
        }

        /**
         * This method assigns an integer score to each roll so the computer can compare scores
         */
        public static int getRollScore(int dice1, int dice2, int dice3)
        {
            if (dice1 == dice2 && dice2 == dice3)   // All dice are the same
            {
                return dice1 * 10;
            }

            if (dice1 == 4 || dice2 == 4 || dice3 == 4)             // One of the dice is a 4
                if (dice1 == 5 || dice2 == 5 || dice3 == 5)         // One of the dice is a 5
                    if (dice1 == 6 || dice2 == 6 || dice3 == 6)     // One of the dice is a 6
                        return 100;

            if (dice1 == 1 || dice2 == 1 || dice3 == 1)             // One of the dice is a 1
                if (dice1 == 2 || dice2 == 2 || dice3 == 2)         // One of the dice is a 2
                    if (dice1 == 3 || dice2 == 3 || dice3 == 3)     // One of the dice is a 3
                        return 0;

            if (dice1 == dice2)
                return dice3;    // dice3 is the odd die out
            if (dice2 == dice3)
                return dice1;    // dice1 is the odd die out
            if (dice1 == dice3)
                return dice2;    // dice2 is the odd die out

            return -1;   // Roll is invalid
        }
    }
}

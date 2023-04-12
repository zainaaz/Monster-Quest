using System;
using System.Collections.Generic;

namespace MonsterQuest
{
    public class DiceHelper
    {
        private static readonly Random rng = new Random();


        public static int DiceRoll(int numberOfDice, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int result = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                result += random.Next(1, diceSides + 1);
            }
            result += fixedBonus;
            return result;
        }


        public static int DiceRoll(string diceNotation)
        {
            var (numberOfRolls, diceSides, fixedBonus) = ParseDiceNotation(diceNotation);
            int total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                total += rng.Next(1, diceSides + 1);
            }
            total += fixedBonus;
            return total;
        }

        private static (int, int, int) ParseDiceNotation(string diceNotation)
        {
            string[] parts = diceNotation.Split('d', '+', '-');
            int numberOfRolls = int.Parse(parts[0]);
            int diceSides = int.Parse(parts[1]);
            int fixedBonus = 0;
            if (parts.Length == 3)
            {
                fixedBonus = int.Parse(parts[2]);
            }
            else if (parts.Length == 4 && parts[2] == "")
            {
                fixedBonus = -1 * int.Parse(parts[3]);
            }
            else if (parts.Length == 4 && parts[2] == "+")
            {
                fixedBonus = int.Parse(parts[3]);
            }
            else if (parts.Length == 4 && parts[2] == "-")
            {
                fixedBonus = -1 * int.Parse(parts[3]);
            }
            return (numberOfRolls, diceSides, fixedBonus);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Rolling 10d6:");
            for (int i = 0; i < 10; i++)
            {
                int result = DiceRoll("1d6");
                Console.Write(result + " ");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Rolling 3d4+2:");
            for (int i = 0; i < 10; i++)
            {
                int result = DiceRoll("3d4+2");
                Console.Write(result + " ");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Rolling 5d8-3:");
            for (int i = 0; i < 10; i++)
            {
                int result = DiceRoll("5d8-3");
                Console.Write(result + " ");
            }
            Console.WriteLine(" ");
        }
    }
}















using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

namespace MonsterQuest
{
    public class DiceHelper
    {



        static int DiceRoll(string diceNotation)
        {
            // Parse the dice notation string to get the number of rolls, the number of sides on the die, and any fixed bonus.
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

            // Roll the dice and apply any fixed bonus or penalty.
            Random rng = new Random();
            int total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                total += rng.Next(1, diceSides + 1);
            }
            total += fixedBonus;

            // Return the result.
            return total;
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















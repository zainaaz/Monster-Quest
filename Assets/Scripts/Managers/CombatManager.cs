using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

namespace MonsterQuest
{
    public class CombatManager : MonoBehaviour
    {
        static Random rnd = new Random();

        static void Start()
        {
            List<string> characters = new List<string> { "Jazlyn", "Theron", "Dayana", "Roland" };

            Simulate(characters, "Orc", DiceRoll(2, 8, 6), 10);
            Simulate(characters, "Azer", DiceRoll(6, 8, 12), 18);
            Simulate(characters, "Troll", DiceRoll(8, 10, 40), 16);
        }

        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int sum = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                sum += rnd.Next(1, diceSides + 1);
            }
            return sum + fixedBonus;
        }

        public static void Simulate(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            Console.WriteLine($"Watch out," + monsterName + " with" +  monsterHP + "HP!");
            while (monsterHP > 0 && characterNames.Count > 0)
            {
                foreach (string character in characterNames)
                {
                    int damage = DiceRoll(2, 6);
                    Console.WriteLine($"{character} hits the  for {damage} the {monsterName}  has {monsterHP} HP left.");
                    monsterHP -= damage;
                    if (monsterHP <= 0)
                    {
                       // Console.WriteLine($"The {monsterName} ");
                        break;
                    }
                }

                if (monsterHP <= 0)
                {
                    break;
                }

                int saveRoll = DiceRoll(1, 20);
                Console.WriteLine($"The {monsterName} attacks the party! Saving throw DC is {savingThrowDC}.");
                if (saveRoll >= savingThrowDC)
                {
                    Console.WriteLine($"The  {monsterName}'s attack!");
                }
                else
                {
                   // Console.WriteLine($"The {monsterName}'s attack hits the party!");
                    int indexToRemove = rnd.Next(characterNames.Count);
                    Console.WriteLine($"{characterNames[indexToRemove]} is killed by the {monsterName}!");
                    characterNames.RemoveAt(indexToRemove);
                    if (characterNames.Count == 0)
                    {
                        Console.WriteLine("All characters are dead! Combat simulation over.");
                        return;
                    }
                }
            }

            //Console.WriteLine("Combat simulation over.");
        }
    }
}
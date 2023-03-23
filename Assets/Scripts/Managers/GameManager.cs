using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;
using Random = System.Random;

namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {
        static void simulateBottle(List<string> heroes,
                                   string monster,
                                   int monsterHP,
                                   int savingThrowDC)
        {
            var random = new Random();
            Console.WriteLine($"Watch out," + monster + "  with " + monsterHP + " HP appears! ");

            while (monsterHP > 0)
            {
                int damage = 0;
                foreach (var name in heroes)
                {
                    Console.Write($"{name} hits the {monster} for.");
                    for (int attacks = 0; attacks < 2; attacks++)
                    {
                        damage += random.Next(1, 7);
                    }
                    monsterHP -= damage;
                    Console.WriteLine($"{damage} damage");

                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                        Console.WriteLine($"The {monster} has {monsterHP} HP left");
                        Console.WriteLine($"The heroes celebrate their victory! {monster}!");
                        break;
                    }
                    Console.WriteLine(($"The {monster} has {monsterHP} HP left"));
                    damage = 0;
                }
                if (monsterHP <= 0)
                {
                    break;
                }

                var monsterAttack = heroes[random.Next(0, heroes.Count)];
                Console.WriteLine($"The {monster} attacks {monsterAttack}");

                int savingThrow = random.Next(1, 21);
                savingThrow += 5;

                if (savingThrow < savingThrowDC)
                {
                    Console.WriteLine($"{monsterAttack} rolled a {savingThrow} and failed, the hero dies!.");
                    heroes.Remove(monsterAttack);
                }
                else
                {
                    Console.WriteLine($"{monsterAttack} rolled a {savingThrow} and made the save! Hurray!");
                }
                if (heroes.Count == 0)
                {
                    Console.WriteLine($"The party has perished. You Lose!");
                    break;
                }
            }
        }
        private void Start()

        {
            var random = new Random();
            var party = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };
            Console.Write("A party of worriors (");
            Console.Write(string.Join(",", party));
            Console.WriteLine(") descends\n into the dungeon");
            Console.WriteLine("");

            simulateBottle(party, "Ore", 15, 12);
            Console.WriteLine("");

            simulateBottle(party, "Mage", 40, 20);
            Console.WriteLine("");

            simulateBottle(party, "Troll", 84, 18);
            Console.WriteLine("");

            //Console.ReadKey(true);
        }


    }
}

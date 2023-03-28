using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {
        static Random rnd = new Random();

        private void Awake()
        {
            Transform combatTransform = transform.Find("Combat");
            CombatManager combatManager = combatTransform.GetComponent<CombatManager>();


        }


        private  void Start()
        {
            List<string> characters = new List<string> { "Jazlyn", "Theron", "Dayana", "Roland" };

            SimulateCombat(characters, "Orc", DiceRoll(2, 8, 6), 10);
            SimulateCombat(characters, "Azer", DiceRoll(6, 8, 12), 18);
            SimulateCombat(characters, "Troll", DiceRoll(8, 10, 40), 16);
        }

        static int DiceRoll(int numberOfDice, int diceSides, int fixedBonus = 0)
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

        static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            Console.WriteLine($"Watch out, {monsterName} appears with {monsterHP} HP!");
            while (monsterHP > 0 && characterNames.Count > 0)
            {
                foreach (string character in characterNames)
                {
                   int damage = DiceRoll(2, 6);
                    Console.WriteLine($"{character} hits the {monsterName} {damage} damage the {monsterName} has {monsterHP} HP appears!");
                    monsterHP -= damage;
                    if (monsterHP <= 0)
                    {
                        Console.WriteLine($"The {monsterName} rolls a {savingThrowDC} and fails to be saved!");
                        break;
                    }
                }

                if (monsterHP <= 0)
                {
                    break;
                }

                int saveRoll = DiceRoll(1, 20);
                Console.WriteLine($"The {monsterName} Saved {savingThrowDC} from the attack.");
                if (saveRoll >= savingThrowDC)
                {
                    
                    Console.WriteLine($"The party dodges the {monsterName}'s attack!");
                }
                else
                {
                    Console.WriteLine($"The {monsterName}'s attack hits the party!");
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

            Console.WriteLine("Combat simulation over.");
        }
    }
}

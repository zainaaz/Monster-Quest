using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class CombatManager : MonoBehaviour
    {
        private GameState _gameState;

        public IEnumerator Simulate(GameState gameState)
        {
            var monster = gameState.Combat.Monster;
            var characters = gameState.Party.Members;
            Console.WriteLine($"Watch out, {monster.DisplayName} appears with {monster.HitPoints} HP!");
            while (monster.HitPoints > 0 && characters.Count > 0)
            {
                foreach (var character in characters)
                {
                    int damage = DiceHelper.DiceRoll(2, 6);
                    yield return monster.ReactToDamage(damage);
                    Console.WriteLine($"{character.DisplayName} hits the {monster.DisplayName} {damage} damage, the {monster.DisplayName} has {monster.HitPoints} HP left!");
                    if (monster.HitPoints <= 0)
                    {
                        Console.WriteLine($"The {monster.DisplayName} fails to be saved with a DC of {monster.SavingThrowDC}!");
                        break;
                    }
                }

                if (monster.HitPoints <= 0)
                {
                    break;
                }

                int saveRoll = DiceHelper.DiceRoll("1d20");
                Console.WriteLine($"The {monster.DisplayName} makes a saving throw of {monster.SavingThrowDC}.");
                if (saveRoll >= monster.SavingThrowDC)
                {
                    Console.WriteLine($"The party dodges the {monster.DisplayName}'s attack!");
                }
                else
                {
                    Console.WriteLine($"The {monster.DisplayName}'s attack hits the party!");
                    int indexToRemove = Random.Range(0, characters.Count);
                    yield return characters[indexToRemove].ReactToDamage(1000);
                    Console.WriteLine($"{characters[indexToRemove].DisplayName} is killed by the {monster.DisplayName}!");
                    characters.RemoveAt(indexToRemove);
                    if (characters.Count == 0)
                    {
                        Console.WriteLine("All characters are dead! Combat simulation over.");
                        yield break;
                    }
                }
            }
            Console.WriteLine("Combat simulation over.");
        }
    }
}

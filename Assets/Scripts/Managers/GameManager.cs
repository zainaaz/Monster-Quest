using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {
        private CombatManager combatManager;

        private void Awake()
        {
            Transform combatTransform = transform.Find("Combat");
            combatManager = combatTransform.GetComponent<CombatManager>();
        }

        private void Start()
        {
            List<Character> characters = PartyManager.CreateParty();

            GameState gameState = new GameState(new Party(characters));


            Monster orc = new Monster("Orc", "A fierce orc", DiceHelper.DiceRoll(2, 8, 6), 10, new ArmorInformation { Class = 1, Type = "Leather" });
            Monster azer = new Monster("Azer", "A fiery azer", DiceHelper.DiceRoll(6, 8, 12), 18, new ArmorInformation { Class = 4, Type = "Plate" });
            Monster troll = new Monster("Troll", "A regenerating troll", DiceHelper.DiceRoll(8, 10, 40), 16, new ArmorInformation { Class = 3, Type = "Chainmail" });

            combatManager.Simulate(gameState.EnterCombatWithMonster(orc));
            combatManager.Simulate(gameState.EnterCombatWithMonster(azer));
            combatManager.Simulate(gameState.EnterCombatWithMonster(troll));
        }
    }

}
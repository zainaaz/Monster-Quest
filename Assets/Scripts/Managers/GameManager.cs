using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private Sprite[] characterSprites;
        [SerializeField] private Sprite[] monsterSprites;

        private CombatManager combatManager;
        private CombatPresenter combatPresenter;
        


        private void Awake()
        {
            Transform combatTransform = transform.Find("Combat");
            combatManager = combatTransform.GetComponent<CombatManager>();
            combatPresenter = combatTransform.GetComponent<CombatPresenter>();
           

        }

        private IEnumerator Start()
        {
            List<Character> characters = PartyManager.CreateParty();

            GameState gameState = new GameState(new Party(characters));

            combatPresenter.InitializeParty(gameState);


            Monster orc = new Monster("Orc", "Orc", 10, SizeCategory.Medium, new ArmorInformation { Class = 1, Type = "Leather" }, DiceHelper.DiceRoll(2, 8, 6));
            Monster azer = new Monster("Azer", "Azer", 18, SizeCategory.Medium, new ArmorInformation { Class = 4, Type = "Plate" }, DiceHelper.DiceRoll(6, 8, 12));
            Monster troll = new Monster("Troll", "Troll", 16, SizeCategory.Large, new ArmorInformation { Class = 3, Type = "Chainmail" }, DiceHelper.DiceRoll(8, 10, 40));
             
            gameState.EnterCombatWithMonster(orc);
            combatPresenter.InitializeMonster(gameState);
            yield return combatManager.Simulate(gameState);
            gameState.EnterCombatWithMonster(azer);
            combatPresenter.InitializeMonster(gameState);
            yield return combatManager.Simulate(gameState);
            gameState.EnterCombatWithMonster(troll);
            combatPresenter.InitializeMonster(gameState);
            yield return combatManager.Simulate(gameState);
        }
    }

}
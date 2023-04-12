using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class GameState
    {
        public Combat Combat { get; private set; }
        public Party Party { get; private set; }

        public GameState(Party party)
        {
            Party = party;

        }

        public GameState EnterCombatWithMonster(Monster monster)
        {
            Combat = new Combat(monster);
            return this;
        }

    }
}
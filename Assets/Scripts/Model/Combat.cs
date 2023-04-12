using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class Combat : MonoBehaviour
    {
        public Monster Monster { get; private set; }

        public Combat(Monster monster)
        {
            Monster = monster;

        }

    }
}
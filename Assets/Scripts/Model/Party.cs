using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class Party
    {
        public List<Character> Members { get; private set; }

        public Party(List<Character> members)
        {
            Members = members;
        }
    }
}


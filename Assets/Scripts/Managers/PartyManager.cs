using System.Collections.Generic;

namespace MonsterQuest
{
    public class PartyManager
    {
        public static List<Character> CreateParty()
        {
            return new List<Character>
            {
                new Character("Jazlyn",null,null),
                new Character("Theron",null,null),
                new Character("Dayana",null,null),
                new Character("Roland",null,null),
            };


        }
    }
}

using System.Collections.Generic;

namespace MonsterQuest
{
    public class PartyManager
    {
        public static List<Character> CreateParty()
        {
            return new List<Character>
            {
                new Character("Jazlyn","Assassin",10,SizeCategory.Medium,null),
                new Character("Theron","Mage",10,SizeCategory.Medium,null),
                new Character("Dayana","Paladin",10,SizeCategory.Medium,null),
                new Character("Roland","Warrior",10,SizeCategory.Medium,null),
            };


        }
    }
}

using UnityEngine;

namespace MonsterQuest
{
    public class Character
    {
        public string DisplayName { get; private set; }
        public ArmorInformation ArmorInformation { get; private set; }
        public string Description { get; private set; }
        public string TypeArmor { get; private set; }

        public Character(string displayName, string description, ArmorInformation armorInformation)
        {

            Description = description;
            DisplayName = displayName;
            ArmorInformation = armorInformation;

        }




        public static ArmorInformation GetArmorInformation(string str)
        {
            var armorInformation = new ArmorInformation();

            armorInformation.Class = int.Parse(str.Substring(0, 2));

            var typeStr = str.Substring(3).Trim().Replace("(", "").Replace(")", "").Replace(" ", "").Replace("Armor", "");

            if (typeStr.Contains(','))
            {
                typeStr = typeStr.Substring(0, typeStr.IndexOf(','));
            }

            armorInformation.Type = typeStr;

            return armorInformation;
        }


    }
    public class ArmorInformation
    {
        public int Class { get; set; }
        public string Type { get; set; }
    }
}




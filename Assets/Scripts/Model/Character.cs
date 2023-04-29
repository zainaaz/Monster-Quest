using UnityEngine;

namespace MonsterQuest
{
    public class Character : Creature
    {


        public Character(string displayName, string bodySpritePath, int hitPointsMaximum, SizeCategory sizeCategory, ArmorInformation armorInformation)
            : base(displayName, bodySpritePath, hitPointsMaximum, sizeCategory, armorInformation)
        {
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





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class Character : MonoBehaviour
    {
        public string displayName { get; set; }
        public ArmorInformation armorInformation { get; set; }
        public string Description { get; set; }
        public string TypeArmor { get; set; }

        public Character(string displayName, string description)
        {

            Description = description;
            this.displayName = displayName;
            this.armorInformation = armorInformation;


        }
        private static ArmorInformation getArmInfo(string str)
        {
            ArmorInformation armorInformation = new ArmorInformation();

            armorInformation.Class = int.Parse(str.Substring(0, 2));
            if (str.Length > 3)
            {
                string typeStr = str.Substring(3);
                typeStr = typeStr.Trim().Replace("(", "");
                typeStr = typeStr.Replace(")", "");
                typeStr = typeStr.Replace(" ", "");
                typeStr = typeStr.Replace("Armor", "");
                if (typeStr.Contains(','))
                    typeStr = typeStr.Substring(0, typeStr.IndexOf(','));

                armorInformation.Type = typeStr;
            }
            else
                armorInformation.Type = "";
            return armorInformation;
        }


    }
    public class ArmorInformation
    {
        public int Class { get; set; }
        public string Type { get; set; }
    }
}




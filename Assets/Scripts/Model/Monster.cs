using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class Monster : MonoBehaviour
    {
       
        public string Description { get; private set; }
        public string displayName { get; private set; }
        public int hitPoints { get; private set; }
        public int savingThrowDC { get; private set; }
        public ArmorInformation armorInformation { get; set; }
        public string TypeArmor { get; set; }
        public string stringLine { get; private set; }
        List<Monster> list = new List<Monster>();
        public Monster()
        { }
        public  Monster(string displayName, string description, int HitPoints, int savingThrowDC, ArmorInformation armorInformation)
        {
            displayName = displayName;
            Description = description;
            savingThrowDC = savingThrowDC;
            HitPoints = hitPoints;
            
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


    
}


using UnityEngine;

namespace MonsterQuest
{
    public class Monster : Creature
    {
        public int SavingThrowDC { get; private set; }

        public Monster(string displayName, string bodySpritePath, int hitPointsMaximum, SizeCategory sizeCategory, ArmorInformation armorInformation, int savingThrowDC)
            : base(displayName, bodySpritePath, hitPointsMaximum, sizeCategory, armorInformation)
        {
            SavingThrowDC = savingThrowDC;
        }


    }
}
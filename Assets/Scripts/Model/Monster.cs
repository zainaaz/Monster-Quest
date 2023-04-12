using UnityEngine;

namespace MonsterQuest
{
    public class Monster : Character
    {
        public int HitPoints { get; private set; }
        public int SavingThrowDC { get; private set; }

        public Monster(string displayName, string description, int hitPoints, int savingThrowDC, ArmorInformation armorInformation)
            : base(displayName, description, armorInformation)
        {
            HitPoints = hitPoints;
            SavingThrowDC = savingThrowDC;
        }


        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}

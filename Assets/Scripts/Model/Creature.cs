using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    //Base class to represent a creature in a game
    public abstract class Creature
    {
        protected string displayName;
        protected string bodySpritePath;
        protected int hitPointsMaximum;
        protected SizeCategory sizeCategory;
        protected CreaturePresenter creaturePresenter;
        public ArmorInformation ArmorInformation { get; private set; }
        public int HitPoints { get; protected set; }
        public float SpaceInFeet => SizeHelper.spaceInFeetPerSizeCategory[sizeCategory];


        #region [Getters and Setters]
        public string DisplayName => displayName;
        public string BodySpritePath => bodySpritePath;
        public int HitPointsMaximum => hitPointsMaximum;
        public SizeCategory SizeCategory => sizeCategory;
        #endregion

        public Creature(string displayName, string bodySpritePath, int hitPointsMaximum, SizeCategory sizeCategory, ArmorInformation armorInformation)
        {
            this.displayName = displayName;
            this.bodySpritePath = bodySpritePath;
            this.hitPointsMaximum = hitPointsMaximum;
            this.sizeCategory = sizeCategory;
            HitPoints = hitPointsMaximum;
            ArmorInformation = armorInformation;
        }
        public void InitializeCreaturePresenter(CreaturePresenter creaturePresenter) => this.creaturePresenter = creaturePresenter;
        public virtual IEnumerator ReactToDamage(int damageAmount)
        {
            HitPoints -= damageAmount;
            yield return creaturePresenter.TakeDamage();
            if (HitPoints <= 0)
            {
                yield return creaturePresenter.Die();
            }
        }
    }
}

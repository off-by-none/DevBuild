using System;
using System.Collections.Generic;
using System.Text;

namespace Lab51_RPG
{
    class Warrior : GameCharacter
    {
        #region fields
        private string weaponType;
        #endregion fields

        #region properties
        public string WeaponType { get => weaponType; set => weaponType = value; }
        #endregion properties

        #region constructors
        public Warrior(string name, int strength, int intelligence, string weaponType)
            : base(name, strength, intelligence)
        {
            this.weaponType = weaponType;
        }
        #endregion constructors

        #region methods
        public override void Play()
        {
            Console.WriteLine($"{base.Name}\nStrength: {base.Strength}\nIntelligence: {base.Intelligence}\nWeapon: {weaponType}\n");
        }
        #endregion methods
    }
}

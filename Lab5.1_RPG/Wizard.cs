using System;
using System.Collections.Generic;
using System.Text;

namespace Lab51_RPG
{
    class Wizard : MagicUsingCharacter
    {
        #region fields
        private int spellNumber;
        #endregion fields

        #region properties
        public int SpellNumber { get => spellNumber; set => spellNumber = value; }
        #endregion properties

        #region constructors
        public Wizard(string name, int strength, int intelligence, int magicalEnergy, int spellNumber)
            : base(name, strength, intelligence, magicalEnergy)
        {
            this.spellNumber = spellNumber;
        }
        #endregion constructors

        #region methods
        public override void Play()
        {
            Console.WriteLine($"{base.Name}\nStrength: {base.Strength}\nIntelligence: {base.Intelligence}\nMagic: {base.MagicalEnergy}\n{spellNumber} spells\n");
        }
        #endregion methods
    }
}

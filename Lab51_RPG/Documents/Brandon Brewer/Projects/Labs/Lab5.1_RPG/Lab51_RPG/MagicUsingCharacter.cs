using System;
using System.Collections.Generic;
using System.Text;

namespace Lab51_RPG
{
    class MagicUsingCharacter : GameCharacter
    {
        #region fields
        private int magicalEnergy;
        #endregion fields

        #region properties
        public int MagicalEnergy { get => magicalEnergy; set => magicalEnergy = value; }
        #endregion properties

        #region constructors
        public MagicUsingCharacter(string name, int strength, int intelligence, int magicalEnergy)
            : base(name, strength, intelligence)
        {
            this.magicalEnergy = magicalEnergy;
        }
        #endregion constructors

        #region methods
        public override void Play()
        {
            Console.WriteLine($"{base.Name}\nStrength: {base.Strength}\nIntelligence: {base.Intelligence}\nMagic: {magicalEnergy}\n");
        }
        #endregion methods
    }
}

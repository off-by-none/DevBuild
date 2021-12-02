using System;
using System.Collections.Generic;
using System.Text;

namespace Lab51_RPG
{
    class GameCharacter
    {
        #region fields
        private string name;
        private int strength;
        private int intelligence;
        #endregion fields

        #region properties
        public string Name { get => name; set => name = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        #endregion properties

        #region constructors
        public GameCharacter(string name, int strength, int intelligence)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
        }
        #endregion constructors

        #region methods
        public virtual void Play()
        {
            Console.WriteLine($"{name}\nStrength: {strength}\nIntelligence: {intelligence}\n");
        }
        #endregion methods
    }
}

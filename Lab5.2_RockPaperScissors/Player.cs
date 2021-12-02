using System;
using System.Collections.Generic;
using System.Text;

namespace Lab52_RockPaperScissors
{
    abstract class Player
    {
        #region fields
        protected string name;
        protected RoshamboEnum roshamboValue;
        protected int wins, losses, draws;
        #endregion fields

        #region properties
        public string Name { get => name; set => name = value; }
        public RoshamboEnum RoshamboValue { get => roshamboValue; set => roshamboValue = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Losses { get => losses; set => losses = value; }
        public int Draws { get => draws; set => draws = value; }
        #endregion properties

        #region constructors
        public Player(string name, RoshamboEnum roshamboValue, int wins, int losses, int draws)
        {
            this.name = name;
            this.roshamboValue = roshamboValue;
            this.wins = wins;
            this.losses = losses;
            this.draws = draws;
        }
        #endregion constructors

        #region methods
        public abstract RoshamboEnum GenerateRoshambo();
        #endregion methods
    }
}
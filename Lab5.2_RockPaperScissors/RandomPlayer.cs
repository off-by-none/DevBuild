using System;
using System.Collections.Generic;
using System.Text;

namespace Lab52_RockPaperScissors
{
    class RandomPlayer : Player
    {   
        public RandomPlayer(string name, RoshamboEnum roshamboValue, int wins, int losses, int draws) 
            : base(name, roshamboValue, wins, losses, draws) { }

        public override RoshamboEnum GenerateRoshambo()
        {
            var rand = new Random();
            roshamboValue = (RoshamboEnum)(rand.Next(0, 3));
            return RoshamboValue;
        }
    }
}

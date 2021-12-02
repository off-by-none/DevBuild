using System;
using System.Collections.Generic;
using System.Text;

namespace Lab52_RockPaperScissors
{
    class RockPlayer : Player
    {
        public RockPlayer(string name, RoshamboEnum roshamboValue, int wins, int losses, int draws) 
            : base(name, roshamboValue, wins, losses, draws) { }

        public override RoshamboEnum GenerateRoshambo()
        {
            return RoshamboEnum.Rock;
        }
    }
}
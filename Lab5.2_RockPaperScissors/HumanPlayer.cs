using System;
using System.Collections.Generic;
using System.Text;

namespace Lab52_RockPaperScissors
{
    class HumanPlayer : Player
    {
        #region constructors
        public HumanPlayer(string name, RoshamboEnum roshamboValue, int wins, int losses, int draws) : base(name, roshamboValue, wins, losses, draws)
        {
        }
        #endregion constructors

        #region methods
        public override RoshamboEnum GenerateRoshambo()
        {
            char rpsInput;

            do
            {
                Console.Write("\nRock, paper, or scissors? (r/p/s): ");
                rpsInput = Console.ReadKey().KeyChar;
            } while (rpsInput != 'r' && rpsInput != 'R' && rpsInput != 'p' && rpsInput != 'P' && rpsInput != 's' && rpsInput != 'S');
            
            if (rpsInput == 'r' || rpsInput == 'R')
            {
                roshamboValue = RoshamboEnum.Rock;
                return RoshamboEnum.Rock;
            }
            else if (rpsInput == 'p' || rpsInput == 'P')
            {
                roshamboValue = RoshamboEnum.Paper;
                return RoshamboEnum.Paper;
            }
            else
            {
                roshamboValue = RoshamboEnum.Scissors;
                return RoshamboEnum.Scissors;
            }
        }
        #endregion methods
    }
}

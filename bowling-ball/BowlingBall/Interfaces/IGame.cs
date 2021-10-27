using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public interface IGame
    {
        /// <summary>
        /// takes pins score for bowling game for each roll.
        /// </summary>
        /// <param name="pins"></param>
        void Roll(int pins);

        /// <summary>
        /// Calculates score for 10 pins bowling game
        /// </summary>
        /// <returns></returns>
        int GetScore();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game : IGame
    {
        /// <summary>
        /// Encapsulated Pins score collection.
        /// </summary>
        private List<int> pincollection = new List<int>();

        public void Roll(int pins)
        {
            // Add your logic here. Add classes as needed.
            // add all pins and create private collection of all pins count for every roll chance given to player
            pincollection.Add(pins);
        }

        public int GetScore()
        {
            // Make Use of Custom Extension method on Collection of pins and create another collection of Framescores(scores by frame)
            var Framescores = pincollection.calculatescores();
            // Returns the final score of the game.
            return Framescores.Take(10).Sum();
        }
        
    }
}

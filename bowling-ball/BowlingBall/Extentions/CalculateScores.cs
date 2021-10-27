using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    static class CalculateScores
    {
        /// <summary>
        /// Extention method on List of pin scores. Prepare List of frame scores.
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public static IEnumerable<int> calculatescores(this IList<int> pins)
        {
            // Take two rolls which is equal to one frame at a time and 
            // iterate through below conditions and yeild return so as to maintain state of iterator and  
            // calculate pins score count per frame and store in return collection
            for (int i = 0; i + 1 < pins.Count; i += 2)
            {
                // Condition = when player hits Neither strike nor spare create frame result with 2 rolls
                if (pins[i] + pins[i + 1] < 10)
                {
                    yield return pins[i] + pins[i + 1];
                    continue;
                }

                // Condition = Break the loop on tenth frame.
                if (i + 2 >= pins.Count)
                    yield break;

                // For all other remaining condition Player have scored spare or strike so add bonuses.
                yield return pins[i] + pins[i + 1] + pins[i + 2];

                // Condition = In case of strike, iterate only by one (i.e. reduce one here)
                if (pins[i] == 10)
                    i--;
            }
        }
    }
}

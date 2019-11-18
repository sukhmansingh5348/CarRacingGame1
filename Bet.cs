using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingGame
{
    public class Bet
    {
        public int Amounts; //The amount of cash that was bet
        public int Cars; //The number of the car the bet is on
        public Punter Punter; //the guy who placed the bet

        public string GetTheDescription()
        {
            string description = "";
            description = this.Punter.PunterName + " bets " + this.Amounts + " dollars on Car #" + Cars;
            return description;
        }

        public int PayOut(int winner)
        {
            if (Cars == winner)
            {
                return this.Amounts;
            }
            else
            {
                return -this.Amounts;
            }
        }
    }
}

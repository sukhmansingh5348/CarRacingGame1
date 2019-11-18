using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacingGame
{
    public class Punter
    {
        public string PunterName; //the punter's name
        public Bet MyBetForCars; //an istance of Bet that has his bet
        public int Cashes; //how much cash he has

        //punter's control on the form

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdatingLabels()
        {
            MyRadioButton.Text = PunterName + " has " + Cashes + " quids";
            MyLabel.Text = PunterName + " hasn't place a bet";

            if (Cashes == 0)//Code When bettor has no money to bet then it gets destroy
            {
                MyLabel.Text = String.Format("BUSTED");
                MyLabel.ForeColor = System.Drawing.Color.Red;
                MyRadioButton.Enabled = false;
            }

        }

        public void ClearTheBet()
        {
            MyBetForCars.Amounts = 0;
            MyBetForCars.Cars = 0;
            MyBetForCars.Punter = this;
        }

        public bool PlaceBet(int BetAmount, int CarToWin)
        {
            if (Cashes >= BetAmount)
            {
                MyBetForCars.Amounts = BetAmount;
                MyBetForCars.Cars = CarToWin;
                MyBetForCars.Punter = this;
                return true;
            }
            else return false;
        }

        public void Collect(int winner)
        {
            Cashes += MyBetForCars.PayOut(winner);
            this.UpdatingLabels();
        }
    }
}

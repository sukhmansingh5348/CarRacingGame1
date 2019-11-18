using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacingGame
{
    public class Cars
    {
        public int CarStartingPosition; // where my PictureBox Starts
        public int TrackLength; //How long the racetrack is
        public PictureBox MyPictureBox = null; //My PictureBox object
        public Random Randomizer; //An integer random
        public int Loc = 0; //My Location on the track

        public bool CarRunning()
        {
            Loc += Randomizer.Next(1, 5);
            MyPictureBox.Left = Loc;
            if (MyPictureBox.Left >= TrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CarsStartingPosition()
        {
            Loc = 0;
            MyPictureBox.Left = CarStartingPosition;
        }
    }
}

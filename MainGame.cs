using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacingGame
{
    public partial class MainGame : Form
    {
        Cars[] sukhmanCarArray = new Cars[4]; // creates one array of 4 cars objects 
        Punter[] sukhmanPuntersArray = new Punter[3]; // creates one array of 3 guy objects
        Random rnd = new Random();
        public MainGame()
        {
            InitializeComponent();

            settingTheRaceTrack();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cars take starting position
            sukhmanCarArray[0].CarsStartingPosition();
            sukhmanCarArray[1].CarsStartingPosition();
            sukhmanCarArray[2].CarsStartingPosition();
            sukhmanCarArray[3].CarsStartingPosition();

            //disable race button till the end of the race
            bettingParlor.Enabled = false;

            //start timer
            timer1.Start();
        }

        private void Bets_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                if (sukhmanPuntersArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    joeBetLabel.Text = sukhmanPuntersArray[0].MyBetForCars.GetTheDescription();
                }
            }
            else if (bobRadioButton.Checked)
            {
                if (sukhmanPuntersArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    bobBetLabel.Text = sukhmanPuntersArray[1].MyBetForCars.GetTheDescription();
                }
            }
            else if (alRadioButton.Checked)
            {
                if (sukhmanPuntersArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    alBetLabel.Text = sukhmanPuntersArray[2].MyBetForCars.GetTheDescription();
                }
            }
        }


        private void settingTheRaceTrack()//this funtion is for setting the race track
        {
            joeRadioButton.Checked = true;
            // initialize minimum bet label
            minimumBetLabel.Text = "Minimum Bet : " + numericUpDown1.Minimum.ToString() + " dollars";

            // initialize all 4 elements of the CarArray
            sukhmanCarArray[0] = new Cars()
            {
                MyPictureBox = Car1,
                CarStartingPosition = Car1.Left,
                TrackLength = pictureBox1.Width - Car1.Width,
                Randomizer = rnd
            };

            sukhmanCarArray[1] = new Cars()
            {
                MyPictureBox = Car2,
                CarStartingPosition = Car2.Left,
                TrackLength = pictureBox1.Width - Car2.Width,
                Randomizer = rnd
            };

            sukhmanCarArray[2] = new Cars()
            {
                MyPictureBox = Car3,
                CarStartingPosition = Car3.Left,
                TrackLength = pictureBox1.Width - Car3.Width,
                Randomizer = rnd
            };

            sukhmanCarArray[3] = new Cars()
            {
                MyPictureBox = Car4,
                CarStartingPosition = Car4.Left,
                TrackLength = pictureBox1.Width - Car4.Width,
                Randomizer = rnd
            };

            //initialize all 3 elements of the GuysArray
            sukhmanPuntersArray[0] = new Punter()
            {
                PunterName = "Sukhman",
                MyBetForCars = null,
                Cashes = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };

            sukhmanPuntersArray[1] = new Punter()
            {
                PunterName = "Sid",
                MyBetForCars = null,
                Cashes = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };

            sukhmanPuntersArray[2] = new Punter()
            {
                PunterName = "Ajay",
                MyBetForCars = null,
                Cashes = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };

            for (int i = 0; i <= 2; i++)
            {
                sukhmanPuntersArray[i].UpdatingLabels();
                sukhmanPuntersArray[i].MyBetForCars = new Bet();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (sukhmanCarArray[i].CarRunning())
                {
                    timer1.Stop();
                    bettingParlor.Enabled = true;
                    i++;
                    MessageBox.Show("Car " + i + " won the race");
                    for (int j = 0; j <= 2; j++)
                    {
                        sukhmanPuntersArray[j].Collect(i);
                        sukhmanPuntersArray[j].ClearTheBet();
                    }

                    foreach (Cars car in sukhmanCarArray)
                    {
                        car.CarsStartingPosition();
                    }
                    break;
                }
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Sukhman";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Sid";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Ajay";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        }
    }
}

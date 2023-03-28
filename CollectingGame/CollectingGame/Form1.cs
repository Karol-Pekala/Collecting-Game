using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollectingGame
{
    public partial class Form1 : Form
    {
        GameController Controller;
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            Controller = new GameController();
            SetupBoard();

            Controller.ResetBoard();
            Controller.SetEnabledFields(true);
            DisplayResources(Controller.playersResources);
            DisplayWinConditions(Controller.winningResources);
            WinLabel.Visible = false;
        }
        #endregion

        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            Controller.SetEnabledFields(false);
            Controller.SetCurrentField(tableLayoutPanel1.GetRow(((Button)sender)), 
                tableLayoutPanel1.GetColumn(((Button)sender)));
            Controller.SetEnabledFields(true);
            Controller.UpdateResources(((Button)sender).Text);
            DisplayResources(Controller.playersResources);
            if(Controller.HasWon())
            {
                Controller.SetEnabledFields(false);
                WinLabel.Visible = true;
            }
        }
               
        private void button1_EnabledChanged(object sender, EventArgs e)
        {
            if(((Button)sender).Enabled)
            {
                ((Button)sender).BackColor = Color.FromArgb(
                    (((Button)sender).BackColor.A),
                    (byte)(((Button)sender).BackColor.R / 1.3),
                    (byte)(((Button)sender).BackColor.G / 1.3),
                    (byte)(((Button)sender).BackColor.B / 1.3)
                );
            }
            else
            {
                ((Button)sender).BackColor = Color.FromArgb(
                    (((Button)sender).BackColor.A),
                    (byte)(((Button)sender).BackColor.R * 1.3),
                    (byte)(((Button)sender).BackColor.G * 1.3),
                    (byte)(((Button)sender).BackColor.B * 1.3)
                );
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Controller.ResetBoard();
            Controller.SetEnabledFields(true);
            DisplayResources(Controller.playersResources);
            DisplayWinConditions(Controller.winningResources);
            WinLabel.Visible = false;
        }
        #endregion

        #region Helpers
        private void SetupBoard()
        {
            Button[,] buttons = new Button[8, 8];
            #region GetButtons
            buttons[0, 0] = button1; buttons[0, 1] = button2; buttons[0, 2] = button3; buttons[0, 3] = button4;
            buttons[0, 4] = button5; buttons[0, 5] = button6; buttons[0, 6] = button7; buttons[0, 7] = button8;
            buttons[1, 0] = button9; buttons[1, 1] = button10; buttons[1, 2] = button11; buttons[1, 3] = button12;
            buttons[1, 4] = button13; buttons[1, 5] = button14; buttons[1, 6] = button15; buttons[1, 7] = button16;
            buttons[2, 0] = button17; buttons[2, 1] = button18; buttons[2, 2] = button19; buttons[2, 3] = button20;
            buttons[2, 4] = button21; buttons[2, 5] = button22; buttons[2, 6] = button23; buttons[2, 7] = button24;
            buttons[3, 0] = button25; buttons[3, 1] = button26; buttons[3, 2] = button27; buttons[3, 3] = button28;
            buttons[3, 4] = button29; buttons[3, 5] = button30; buttons[3, 6] = button31; buttons[3, 7] = button32;
            buttons[4, 0] = button33; buttons[4, 1] = button34; buttons[4, 2] = button35; buttons[4, 3] = button36;
            buttons[4, 4] = button37; buttons[4, 5] = button38; buttons[4, 6] = button39; buttons[4, 7] = button40;
            buttons[5, 0] = button41; buttons[5, 1] = button42; buttons[5, 2] = button43; buttons[5, 3] = button44;
            buttons[5, 4] = button45; buttons[5, 5] = button46; buttons[5, 6] = button47; buttons[5, 7] = button48;
            buttons[6, 0] = button49; buttons[6, 1] = button50; buttons[6, 2] = button51; buttons[6, 3] = button52;
            buttons[6, 4] = button53; buttons[6, 5] = button54; buttons[6, 6] = button55; buttons[6, 7] = button56;
            buttons[7, 0] = button57; buttons[7, 1] = button58; buttons[7, 2] = button59; buttons[7, 3] = button60;
            buttons[7, 4] = button61; buttons[7, 5] = button62; buttons[7, 6] = button63; buttons[7, 7] = button64;
            #endregion
            Controller.SetGameBoard(buttons);
        }

        private void DisplayResources(int[] res)
        {
            wood.Text = res[0].ToString();
            stone.Text = res[1].ToString();
            drink.Text = res[2].ToString();
            food.Text = res[3].ToString();
        }

        private void DisplayWinConditions(int[] res)
        {
            woodNeeded.Text = res[0].ToString();
            stoneNeeded.Text = res[1].ToString();
            drinkNeeded.Text = res[2].ToString();
            foodNeeded.Text = res[3].ToString();
        }
        #endregion


    }
}

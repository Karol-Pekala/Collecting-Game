using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CollectingGame
{
    class GameController
    {
        int[] currentField;
        Button[,] gameBoard;
        Dictionary<int, string> fields;
        Dictionary<char, int> resources;
        Dictionary<int, Color> colors;
        public int[] playersResources;
        public int[] winningResources;

        public GameController()
        {
            currentField = new int[2];
            SetCurrentField(3, 3);

            fields = new Dictionary<int, string>{
                {0, "+w\n-s"}, {1, "+s\n-d"},
                {2, "+d\n-f"}, {3, "+f\n-w"}
            };
            colors = new Dictionary<int, Color>{
                {0, Color.Peru}, {1, Color.DarkGray},
                {2, Color.LightSkyBlue}, {3, Color.LightGreen}
            };
            resources = new Dictionary<char, int>{
                {'w', 0}, {'s', 1},
                {'d', 2}, {'f', 3}
            };

            playersResources = new int[4];
            winningResources = new int[4];
        }

        #region Setters
        public void SetGameBoard(Button[,] buttons)
        {
            gameBoard = buttons;
        }

        public void SetEnabledFields(bool enabled)
        {
            gameBoard[currentField[0] > 5 ? 7 : currentField[0] + 1, currentField[1]].Enabled = enabled;
            gameBoard[currentField[0] < 2 ? 0 : currentField[0] - 1, currentField[1]].Enabled = enabled;
            gameBoard[currentField[0], currentField[1] > 5 ? 7 : currentField[1] + 1].Enabled = enabled;
            gameBoard[currentField[0], currentField[1] < 2 ? 0 : currentField[1] - 1].Enabled = enabled;
            gameBoard[currentField[0], currentField[1]].Enabled = false;
        }

        public void SetCurrentField(int row, int column)
        {
            currentField[0] = row;
            currentField[1] = column;
        }
        #endregion

        #region Helpers
        public void ResetBoard()
        {
            Random random = new Random();
            foreach (var field in gameBoard)
            {
                field.Enabled = false;
                int rand = random.Next(4);
                field.Text = fields[rand];
                field.BackColor = colors[rand];
            }
            SetCurrentField(3, 3);
            for (int i = 0; i < 4; ++i)
            {
                playersResources[i] = 0;
            }
            for (int i = 0; i < 4; ++i)
            {
                winningResources[i] = random.Next(6);
            }
        }

        public void UpdateResources(string res)
        {
            string[] splited = res.Split('\n');
            ++playersResources[resources[splited[0][1]]];
            playersResources[resources[splited[1][1]]] = 
                playersResources[resources[splited[1][1]]] > 0 
                ? playersResources[resources[splited[1][1]]] - 1 : 0;
        }

        public bool HasWon()
        {
            for (int i = 0; i < 4; ++i)
            {
                if (playersResources[i] < winningResources[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}

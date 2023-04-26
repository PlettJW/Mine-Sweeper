using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace mineSweeperDemo2018_19_S1
{
    public partial class Form1 : Form
    {
        enum cellTypes { blank, one, two, three, four, five, six, seven, eight, mine = 10,check = 13 }



        Size gridSize = new Size(9, 9);
        Size cellSize = new Size(25, 25);

        //the underlying value of each cell eg: mine, number, blank
        cellTypes[,] gameData;

        //the covers on the cells, true = covered, false = uncovered
        bool[,] covered;

        //the flags over the cells
        bool[,] flaged;

        //number of mines and thus how many flags
        int numMines = 10;
        int flags = 10;

        //seconds and minets for the timer
        int timeS = 0;
        int timeM = 0;

        //keeps track of the difficulty
        int difficulty = 1;

        string highscore = "";

        //the graphics
        Bitmap graphics = new Bitmap(typeof(Form1), "minesweeper_graphics.png");

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            //sets size
            ClientSize = new Size(gridSize.Width * cellSize.Width, gridSize.Height * cellSize.Height + menuStrip1.Height);

            //sets the arrays
            gameData = new cellTypes[gridSize.Width, gridSize.Height];
            covered = new bool[gridSize.Width, gridSize.Height];
            flaged = new bool[gridSize.Width, gridSize.Height];

            CoverAll();

            SetMines();

            //sets the number of flags you can use and updates the lable
            flags = numMines;
            lblFlags.Text = "Flags:" + flags;
            
            //sets the time too 0
            timeS = 0;
            timeM = 0;

            //starts the timer
            timer.Enabled = true;

            CalculateMinesInNeighbourhood();

            Invalidate();
        }

        private void CoverAll()
        {
            //loop through every cell and set the cover to true
            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    covered[i, j] = true;
                }
            }
        }

        private void SetMines()
        {
            //place the appropriate number of mines randomly

            Random r = new Random();

            int minesPlaced = 0;


            do
            {
                int x = r.Next(0, gridSize.Width); //pick a random x-coordinate
                int y = r.Next(0, gridSize.Height); //pick a random y-coordinate

                if (gameData[x, y] != cellTypes.mine)
                {
                    gameData[x, y] = cellTypes.mine;
                    minesPlaced++;
                }

            } while (minesPlaced < numMines);



            Invalidate();

        }

        private bool CheckBounds(int x, int y)
        {
            //check to make sure this cell is in bounds
            //true = inbounds, false = out of bounds

            bool inBounds = false;

            if (x < 0 || x >= gridSize.Width || y < 0 || y >= gridSize.Height)
                inBounds = false;
            else
                inBounds = true;

            return inBounds;

        }

        private void CalculateMinesInNeighbourhood()
        {
            //this function will calculate the number that goes in a cell that isn't a mine

            //loop through the entire game board
            //count the mines that are near a blank cell
            //that number is the value of the cell

            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    if (gameData[i, j] != cellTypes.mine) //not a mine, so what is it?
                    {
                        int count = 0; //the number of mines touching this cell
                        for (int x = i - 1; x <= i + 1; x++) //look left and right
                        {
                            for (int y = j - 1; y <= j + 1; y++)//look up and down
                            {
                                if (i == x && j == y)
                                    continue; //skip this cell
                                if (CheckBounds(x, y) && gameData[x, y] == cellTypes.mine)
                                    count++;
                            }
                        }

                        //set the gameData array of the cell to the number of mines counted
                        gameData[i, j] = (cellTypes)count;

                    }
                }
            }
            Invalidate();
            int a = 0;
        }

        #region MenuStrip Stuff
        private void easy9X910MinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sets it to the correct size with the correct amount of mines and flags
            gridSize = new Size(9, 9);
            numMines = 10;
            flags = 10;

            //marks the difficulty
            difficulty = 1;

            //restarts the game
            StartGame();
        }

        //same as prevous
        private void medium16X940MinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = new Size(16, 16);
            numMines = 40;
            flags = 40;
            difficulty = 2;

            StartGame();
        }

        //same as prevous
        private void difficult32X1699MinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = new Size(32, 16);
            numMines = 99;
            flags = 99;
            difficulty = 3;

            StartGame();
        }

        //shows you the current highscore
        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //vairables needed to record and convert the different highscores
            int Escore;
            int EscoreM = 0;
            int Nscore;
            int NscoreM = 0;
            int Hscore;
            int HscoreM = 0;

            //reads the easy highscore
            StreamReader sr = new StreamReader("EHighScore.txt");

            Escore = Convert.ToInt16(sr.ReadLine());

            sr.Close();

            //reads the normal highscore
            sr = new StreamReader("NHighScore.txt");

            Nscore = Convert.ToInt16(sr.ReadLine());

            sr.Close();

            //read the heroic highscore
            sr = new StreamReader("HHighScore.txt");

            Hscore = Convert.ToInt16(sr.ReadLine());

            sr.Close();

            //converts each highscore from just seconds to seconds and minutes
            while (Escore >= 60)
            {
                //if there is more than 60 seconds converet them into a minute 
                Escore -= 60;
                EscoreM++;

            }

            //converts each highscore from just seconds to seconds and minutes
            while (Nscore >= 60)
            {
                Nscore -= 60;
                NscoreM++;

            }

            //converts each highscore from just seconds to seconds and minutes
            while (Hscore >= 60)
            {
                Hscore -= 60;
                HscoreM++;

            }

            //displays the different highscores
            MessageBox.Show("Easy-     " + EscoreM + ":" + Escore + Environment.NewLine + "Normal- " + NscoreM + ":" + Nscore + Environment.NewLine + "Heroic-  " + HscoreM + ":" + Hscore, "Current HighScores", MessageBoxButtons.OK);
        }
        #endregion


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //shift the graphics down by the menustrip height
            e.Graphics.TranslateTransform(0, menuStrip1.Height);

            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    //which graphic to draw from the strip
                    Rectangle srcRect = new Rectangle();

                    //what is the value of this cell?
                    int imageNum;

                    if (flaged[i, j])
                        imageNum = 11;
                    else if (covered[i, j])
                        imageNum = 9; //the correct graphic from the strip
                    else
                        imageNum = (int)gameData[i, j];

                    //where to draw the graphic on the board
                    Rectangle destRect = new Rectangle(i * cellSize.Width, j * cellSize.Height, cellSize.Width, cellSize.Height);

                    srcRect = new Rectangle(imageNum * cellSize.Width, 0, cellSize.Width, cellSize.Height);

                    //draw the graphics
                    e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point cellSelected = new Point(e.X / cellSize.Width, (e.Y - menuStrip1.Height) / cellSize.Height);



            if (e.Button == MouseButtons.Left)//left click removes blanks
            {
                //if you uncover a blank
                if (gameData[cellSelected.X, cellSelected.Y] == cellTypes.blank && covered[cellSelected.X, cellSelected.Y] == true && flaged[cellSelected.X, cellSelected.Y] == false)
                {
                    ClearBlanks(cellSelected.X, cellSelected.Y);

                }
                else if (flaged[cellSelected.X, cellSelected.Y] == false)
                {
                    //uncovers the clicked cell
                    covered[cellSelected.X, cellSelected.Y] = false;

                    //if its a mine you die
                    if (gameData[cellSelected.X, cellSelected.Y] == cellTypes.mine)
                    {
                        
                        Death();
                    }
                   

                }

            }
            else if (e.Button == MouseButtons.Right)//right click places and removes flags from covered spaces
            {
                if (flags > 0)
                {

                    //if its flagged remove the flag
                    if (flaged[cellSelected.X, cellSelected.Y] == true)
                    {
                        flaged[cellSelected.X, cellSelected.Y] = false;
                        flags++;
                    }
                    else if (covered[cellSelected.X, cellSelected.Y] == true)//if its not flaged and covered flag it
                    {
                        flaged[cellSelected.X, cellSelected.Y] = true;
                        flags--;
                    }
                    else
                        return;

                    //updates the flag display
                    lblFlags.Text = "Flags:" + flags;
                }
            }


            Invalidate();
            CheckWin();
        }

        private void CheckWin()
        {
            bool gonnaWin = true;//if it finds no problems you win

            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    if (gameData[i, j] == cellTypes.mine && flaged[i, j] == false)//if any mines are not flaged
                    {
                        for (int h = 0; h < gridSize.Width; h++)
                        {
                            for (int k = 0; k < gridSize.Height; k++)
                            {
                                if (gameData[h, k] != cellTypes.mine && covered[h, k])//and cells that arnt mines are covered you dont win
                                {
                                    gonnaWin = false;
                                }
                            }
                        }
                    }
                }
            }
            //if gonna win is still true you win
            if (gonnaWin)
            {
                Victory();
            }
        }

        private void ClearBlanks(int X, int Y)
        {//when a blank is uncovered it looks for blanks all around it
            for (int i = X - 1; i <= X + 1; i++)
            {
                for (int j = Y - 1; j <= Y + 1; j++)
                {
                    if (CheckBounds(i, j) && gameData[i, j] != cellTypes.mine && covered[i, j] == true)
                    {
                        //clears a cell thats not a mine
                        covered[i, j] = false;

                        if (gameData[i, j] == cellTypes.blank)
                        {
                            //if the cell is another blank it continues the process from there
                            Thread.Sleep(50);
                            this.Refresh();

                            ClearBlanks(i, j);
                        }



                    }
                }
            }
        }

        private void Death()
        {
            //reveals all the mines
            ShowMines();

            //ends timer
            timer.Enabled = false;
            
            //option to play again
            DialogResult d =MessageBox.Show("Game over!, play again?", "You Are Dead! :p", MessageBoxButtons.YesNo);

            if (d == DialogResult.Yes)
            {
                StartGame();
            }
            else
                Application.Exit();

        }

        private void Victory()
        {
            //end timer
            timer.Enabled = false;

            //check for highscore
            Highscore();

            //option to play again
            DialogResult d = MessageBox.Show("Congradulations you have won" + Environment.NewLine + "Play Agian?","Victory",MessageBoxButtons.YesNo);

            if (d == DialogResult.Yes)
            {
                StartGame();
            }
            else
                Application.Exit();
        }

        private void Highscore()
        {
            //checks what difficulty your on
            if (difficulty == 1)
            {

                //reads the correct highscore
                StreamReader r = new StreamReader("EHighScore.txt");

                highscore = r.ReadLine();

                r.Close();

                //converts your time to seconds too compair
                if (timeM * 60 + timeS < Convert.ToInt32(highscore) || Convert.ToInt32(highscore) == 0)
                {
                    // if your time is quicker or their is no highscore you get the new highscore
                    MessageBox.Show("new high score!");

                    //writes in the new highscore
                    StreamWriter sw = new StreamWriter("EHighscore.txt");

                    sw.Write(Convert.ToString(timeM * 60 + timeS));

                    sw.Close();
                }
            }

            //same as prevous
            else if (difficulty == 2)
            {
                StreamReader r = new StreamReader("NHighScore.txt");

                highscore = r.ReadLine();

                r.Close();

                if (timeM * 60 + timeS < Convert.ToInt32(highscore) || Convert.ToInt32(highscore) == 0)
                {
                    MessageBox.Show("new high score!");

                    StreamWriter sw = new StreamWriter("NHighscore.txt");

                    sw.Write(Convert.ToString(timeM * 60 + timeS));

                    sw.Close();
                }
            }

            //same as prevoud
            else if (difficulty == 3)
            {
                StreamReader r = new StreamReader("HHighScore.txt");

                highscore = r.ReadLine();

                r.Close();

                if (timeM * 60 + timeS < Convert.ToInt32(highscore) || Convert.ToInt32(highscore) == 0)
                {
                    MessageBox.Show("new high score!");

                    StreamWriter sw = new StreamWriter("HHighscore.txt");

                    sw.Write(Convert.ToString(timeM * 60 + timeS));

                    sw.Close();
                }
            }
        }

        private void ShowMines()
        {
            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    if (gameData[i,j] == cellTypes.mine)//uncovers all mines
                    {
                        if (flaged[i,j])
                        {
                            //flaged mines become checkmarks
                            gameData[i, j] = cellTypes.check;
                            flaged[i, j] = false;
                        }
                        covered[i, j] = false;

                        //slows the proccess for visual effect
                        Thread.Sleep(50);
                        this.Refresh();
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //every tick ads a second if there is more than 60 they become a minute
            timeS++;
            if (timeS >= 60)
            {
                timeM++;
                timeS -= 60;
            }
            lblTime.Text = timeM + ":" + timeS;//updates the label
        }

        private void butReset_Click(object sender, EventArgs e)
        {
            StartGame();
        }

      
    }
}


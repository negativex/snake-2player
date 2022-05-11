using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class frmGame : Form
    {
        // snake is a list implementation.
        private List<Circle> snake = new List<Circle>();
        private List<Circle> snake2 = new List<Circle>();
        // food are circles.
        private Circle food = new Circle();

        public frmGame()
        {
            InitializeComponent();
        }

        private void startGame()
        {
            // disable the controls.
            lblGameOver.Visible = false;
            btnPlay.Enabled = false;
            newGameToolStripMenuItem.Enabled = false;
            // initialize with default settings.
            new Settings();
            new SettingsP2();
            // set game timer.
            tmrTimer.Interval = 1000 / Settings.speed;
            tmrTimer2.Interval = 1000 / Settings.speed;
            tmrTimer.Tick += updateScreen;
            tmrTimer2.Tick += updateScreen2;
            tmrTimer.Start();
            tmrTimer2.Start();
            // remove the whole snake.
            snake.Clear();
            snake2.Clear();
            // create the snake head node.
            Circle snakeHead = new Circle() { x = 6, y = 10 };
            Circle snakeHead2 = new Circle() { x = 18, y = 10 };
            // add the head to the body.
            snake.Add(snakeHead);
            snake2.Add(snakeHead2);
            lblScore.Text = Settings.score.ToString();
            lbldiemp2.Text = SettingsP2.score.ToString();
            generateFood();
        }

        /// <summary>
        /// Places random food objects in the game.
        /// </summary>
        private void generateFood()
        {
            // get the max x and y positions.
            int maxXPos = (picCanvas.Size.Width / Settings.width);
            int maxYPos = (picCanvas.Size.Height / Settings.height);

            // create a random food object.
            Random random = new Random();
            food = new Circle() { x = random.Next(0, maxXPos),
                y = random.Next(0, maxYPos) };
        }

        private void updateScreen(object sender, EventArgs e)
        {
            // check for game over.
            if (Settings.gameOver) {
                // check if Enter is pressed.
                if (Input.KeyPressed(Keys.Return)) { startGame(); }
            }
            else {

                Settings.duration += 1;

                if (Input.KeyPressed(Keys.D) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.A) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.W) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.S) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                movePlayer();
                lblTimer.Text = TimeSpan.FromSeconds(Settings.duration / Settings.speed).ToString();
                lblScore.Text = Settings.score.ToString();
            }

            picCanvas.Refresh();
        }
        private void updateScreen2(object sender, EventArgs e)
        {
            // check for game over.
            if (SettingsP2.gameOver)
            {
                // check if Enter is pressed.
                if (Input.KeyPressed(Keys.Return)) { startGame(); }
            }
            else
            {

                SettingsP2.duration += 1;

                if (Input.KeyPressed(Keys.L) && SettingsP2.direction != Direction.Left)
                    SettingsP2.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.J) && SettingsP2.direction != Direction.Right)
                    SettingsP2.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.I) && SettingsP2.direction != Direction.Down)
                    SettingsP2.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.K) && SettingsP2.direction != Direction.Up)
                    SettingsP2.direction = Direction.Down;

                movePlayer2();
                //lblTimer.Text = TimeSpan.FromSeconds(SettingsP2.duration / SettingsP2.speed).ToString();
                lbldiemp2.Text = SettingsP2.score.ToString();
            }

            picCanvas.Refresh();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.gameOver)
            {
                string msg = "Ket thuc,\nDiem cua nguoi choi 1 la: " + Settings.score + "." + "\nDiem cua nguoi choi 2 la: " +SettingsP2.score + ".";
                msg += "\nNhan Enter de choi lai.";
                lblGameOver.Text = msg;
                lblGameOver.Visible = true;
            }
            else
            {
                Brush snakeColour;
                // draw the snake.
                for (int i = 0; i < snake.Count; ++i)
                {
                    // draw and colour head black.
                    if (i == 0)
                        snakeColour = Brushes.Black;
                    // draw and colour rest of body green.
                    else
                        snakeColour = Brushes.Green;
                    // draw the whole snake.
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(snake[i].x * Settings.width,
                        snake[i].y * Settings.height,
                        Settings.width, Settings.height));
                    // draw food.
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.x * Settings.width,
                        food.y * Settings.height, Settings.width,
                        Settings.height));
                    
                    Brush snakeColour2;
                    //draw the snake.
                    for (int q = 0; q < snake2.Count; ++q)
                    {
                        // draw and colour head black.
                        if (q == 0)
                            snakeColour2 = Brushes.Black;
                        // draw and colour rest of body green.
                        else
                            snakeColour2 = Brushes.Blue;
                        // draw the whole snake.
                        canvas.FillEllipse(snakeColour2,
                            new Rectangle(snake2[q].x * SettingsP2.width,
                            snake2[q].y * SettingsP2.height,
                            SettingsP2.width, SettingsP2.height));
                        //draw food.
                        canvas.FillEllipse(Brushes.Red,
                            new Rectangle(food.x * SettingsP2.width,
                            food.y * SettingsP2.height, SettingsP2.width,
                            SettingsP2.height));
                    }
                }
            }

        }
        
        
        private void movePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--) {
                // move the head.
                if (i == 0) {
                    switch (Settings.direction) {
                        case Direction.Right:
                            snake[i].x++;
                            break;
                        case Direction.Left:
                            snake[i].x--;
                            break;
                        case Direction.Up:
                            snake[i].y--;
                            break;
                        case Direction.Down:
                            snake[i].y++;
                            break;
                    }
                    // get max X and Y positions.
                    int maxXPos = (picCanvas.Size.Width / Settings.width);
                    int maxYPos = (picCanvas.Size.Height / Settings.height);
                    // detect collision with game boundaries.
                    if (snake[i].x < 0 || snake[i].y < 0
                        || snake[i].x >= maxXPos || snake[i].y >= maxYPos) {
                        die();
                    }
                    // detect collision with body.
                    for (int j = 1; j < snake.Count; ++j) {
                        if ((snake[i].x == snake[j].x && snake[i].y == snake[j].y)) {
                            die();
                        }
                    }
                    for (int k = 1; k < snake2.Count; ++k)
                    {
                        if ((snake[0].x == snake2[k].x && snake[0].y == snake2[k].y))
                        {
                            die();
                        }
                    }
                    // detect collision with food.
                    if (snake[i].x == food.x && snake[i].y == food.y) {
                        eat();
                    }
                }
                // move the rest of the body.
                else {
                    // set current node to previous node's position.
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }

            }
        }
        private void movePlayer2()
        { 
            for (int i = snake2.Count - 1; i >= 0; i--)
            {
                // move the head.
                if (i == 0)
                {
                    switch (SettingsP2.direction)
                    {
                        case Direction.Right:
                            snake2[i].x++;
                            break;
                        case Direction.Left:
                            snake2[i].x--;
                            break;
                        case Direction.Up:
                            snake2[i].y--;
                            break;
                        case Direction.Down:
                            snake2[i].y++;
                            break;
                    }
                    // get max X and Y positions.
                    int maxXPos = (picCanvas.Size.Width / SettingsP2.width);
                    int maxYPos = (picCanvas.Size.Height / SettingsP2.height);
                    // detect collision with game boundaries.
                    if (snake2[i].x < 0 || snake2[i].y < 0
                        || snake2[i].x >= maxXPos || snake2[i].y >= maxYPos)
                    {
                        die();
                    }
                    // detect collision with body.
                    for (int j = 1; j < snake2.Count; ++j)
                    {
                        if ((snake2[i].x == snake2[j].x && snake2[i].y == snake2[j].y) )
                        {
                            die();
                        }
                    }
                    for (int k = 1; k < snake.Count; ++k)
                    {
                        if ((snake2[0].x == snake[k].x && snake2[0].y == snake[k].y))
                        {
                            die();
                        }
                    }
                    // detect collision with food.
                    if (snake2[i].x == food.x && snake2[i].y == food.y)
                    {
                        eat2();
                    }
                }
                // move the rest of the body.
                else
                {
                    // set current node to previous node's position.
                    snake2[i].x = snake2[i - 1].x;
                    snake2[i].y = snake2[i - 1].y;
                }

            }
        }

        private void eat2()
        {
            // add circle to the body.
            Circle food = new Circle();
            food.x = snake2[snake2.Count - 1].x;
            food.y = snake2[snake2.Count - 1].y;
            snake2.Add(food);
            // update score
            SettingsP2.score += SettingsP2.points;
            // create a new food object.
            generateFood();
        }
        private void eat()
        {
            // add circle to the body.
            Circle food = new Circle();
            food.x = snake[snake.Count - 1].x;
            food.y = snake[snake.Count - 1].y;
            snake.Add(food);
            // update score
            Settings.score += Settings.points;
            // create a new food object.
            generateFood();
        }
        private void die()
        {
            Settings.gameOver = true;
            tmrTimer.Tick -= updateScreen;
            tmrTimer2.Tick -= updateScreen2;
            tmrTimer.Stop();
            tmrTimer2.Stop();
            btnPlay.Enabled = true;
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void frmGame_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Focus();
            startGame();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            btnPlay.Text = "Retry";
            tmrTimer.Enabled = false;
            tmrTimer2.Enabled = false; 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Tran Bao Ngoc, ";
            msg += "30/3/2022.";
            msg += "\nCoded in C# in Visual Studio.";
            MessageBox.Show(msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlay_Click(sender, e);
        }
    }
}

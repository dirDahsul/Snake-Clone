using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SnakeGameFormsV2
{
    public partial class SnakeGame : Form
    {
        // Random number generator
        Random rnd;

        // Some data field variables
        private int TimePassed;
        private int Score;
        private readonly int Speed;
        private readonly int BodyLength;
        private bool IsPaused;
        private bool HasMoved;
        private bool IsGameOver;

        // The integrity of the snake's body
        List<PictureBox> SnakeBody;

        // Snake moving direction
        Keys Movement;
        Keys WantsMovement;

        // Constructor
        public SnakeGame(int bl, int shs, int sfs)
        {
            // Default Component Initializer by Forms
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen; // Center the window

            SnakeHead.Size = new Size(shs, shs); // Make sure the snake's head is a square
            SnakeFood.Size = new Size(sfs, sfs); // Make sure the food is a square as well

            // Set up intro
            WelcomeToGame.Location = new Point(0, 0);
            WelcomeToGame.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);

            // Set up game over screen location and visibility to false
            DrawGameOver.Location = new Point(0, 0);
            DrawGameOver.Visible = false;

            // Set every wall's parameters according to the window and snake size
            int WallThickness = SnakeHead.Width / 2;
            Wall1.Location = new Point(0, ClientRectangle.Height - WallThickness);
            Wall1.Size = new Size(ClientRectangle.Width, WallThickness);
            Wall2.Location = new Point(ClientRectangle.Width - WallThickness, 0);
            Wall2.Size = new Size(WallThickness, ClientRectangle.Height);
            Wall3.Location = new Point(0, 0);
            Wall3.Size = new Size(ClientRectangle.Width, WallThickness);
            Wall4.Location = new Point(0, 0);
            Wall4.Size = new Size(WallThickness, ClientRectangle.Height);

            // Set all label's locations
            ScoreLabel.Location = new Point(3, 0);
            TimeLabel.Location = new Point(3, ScoreLabel.Bottom);

            // Set the data field variables to their default states (without the need to be changed later on)
            rnd = new Random();
            Speed = SnakeHead.Width; // Speed is considered to be the width/height of the snake's squared head
            BodyLength = bl; // Set by Constructor value
            IsPaused = false; // The default pause state

            SnakeBody = new List<PictureBox>(); // The snake's body
            SnakeBody.Add(SnakeHead); // Add the snake's head to the SnakeBody list as default (unique and undeletable part of the snake's body structure)
                                      // Can't have a snake without atleast a head

            InitializeDefaults(); // Initialize Startup/Restart game function
            KeyDown += KeyDown_Event; // KeyDown event for the snake's movement direction
            Resize += Window_Resize; // Resize picture boxes based on screen size
        }

        // Startup/Restart game function
        private void InitializeDefaults()
        {
            // Some cvars that need to be changed during every startup/restart of the game
            ScoreLabel.Text = "Score: 0";
            TimeLabel.Text = "Time: 0";
            TimePassed = 0;
            Score = 0;

            // Game over screen is drawed -- hide it
            if (IsGameOver)
            {
                IsGameOver = false; // Game is no longer over
                DrawGameOver.Visible = false; // Hides the game over picture box
                SnakeHead.Image = Properties.Resources.SnakeHead; // Reset the snake head's image (in case it was rotated the wrong way)
            }

            SnakeHead.Location = new Point(Wall4.Width, Wall3.Height); // Set snake location to default one

            // Create the default snake body length
            for (int i = 0; i < BodyLength; i++)
            {
                PictureBox BodyPart = new PictureBox
                {
                    Name = "SnakeBodyPart" + (i + 1),
                    Image = Properties.Resources.SnakeBody,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(SnakeHead.Width, SnakeHead.Height),
                    Tag = "body"
                    //Location = new Point()
                };

                // Add the newly created body part to the SnakeBody list and to the controls
                Controls.Add(BodyPart);
                SnakeBody.Add(BodyPart);
            }

            HasMoved = false; // Whether the snake made a move (prevents double movement!!)
            Movement = Keys.Down; // Snake is moving down
            WantsMovement = Keys.Down; // Snake desires to move down
        }

        // Resize the walls according to the window (use by your own risk!)
        void Window_Resize(object sender, EventArgs e)
        {
            // Resize game over and welcome
            if (WelcomeToGame != null)
                WelcomeToGame.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
            else if (IsGameOver)
                DrawGameOver.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);

            // Set every wall's parameters according to the window and snake size
            int WallThickness = SnakeHead.Width / 2;
            Wall1.Location = new Point(0, ClientRectangle.Height - WallThickness);
            Wall1.Width = ClientRectangle.Width;
            Wall2.Location = new Point(ClientRectangle.Width - WallThickness, 0);
            Wall2.Height = ClientRectangle.Height;
            Wall3.Width = ClientRectangle.Width;
            Wall4.Height = ClientRectangle.Height;
        }

        // Stops all timers in the application
        private void StopTimers()
        {
            GameTime.Stop();
            SnakeMovement.Stop();
            FoodTimer.Stop();
        }

        // Starts all timers in the application
        private void StartTimers()
        {
            GameTime.Start();
            SnakeMovement.Start();
            FoodTimer.Start();
        }

        // Pause or 'un'pause the game
        private void PauseGame()
        {
            // Make sure you can't pause during the Game Over or Welcoming screen .... obviously
            if (IsGameOver || WelcomeToGame != null)
                return;

            // If the game is paused -- 'un'pause it
            if (IsPaused)
            {
                // Start the timers
                StartTimers();

                // Make onscreen resources visiable again
                ScoreLabel.Visible = true;
                TimeLabel.Visible = true;
                SnakeFood.Visible = true;
                foreach (PictureBox BodyPart in SnakeBody)
                    BodyPart.Visible = true;

                Control[] control = Controls.Find("GamePausedLabel", true);
                foreach (Control c in control)
                {
                    Controls.Remove(c);
                    c.Dispose();
                }

                // The game is no longer paused
                IsPaused = false;
            }
            // Game is not paused -- pause it
            else
            {
                // Stop the timers
                StopTimers();

                // Hide all onscreen items
                ScoreLabel.Visible = false;
                TimeLabel.Visible = false;
                SnakeFood.Visible = false;
                foreach (PictureBox BodyPart in SnakeBody)
                    BodyPart.Visible = false;

                // Create a label that shows 'GAME PAUSED'
                Label label = new Label()
                {
                    Name = "GamePausedLabel",
                    Text = "GAME PAUSED",
                    Size = new Size(200,500),
                    TextAlign = ContentAlignment.TopLeft,
                    Location = new Point(ClientRectangle.Width/2, ClientRectangle.Height/2),
                    AutoSize = true,
                    Tag = "pause_label",
                    ForeColor = Color.White,
                    //Visible = true,
                };
                Controls.Add(label);

                // Game is paused
                IsPaused = true;
            }
        }

        // Checks if snake is trying to do 180 degrees turns by checking which keys were pressed
        private bool Is180Movement(Keys received, Keys used)
        {
            return (received == Keys.Right && used == Keys.Left || received == Keys.Left && used == Keys.Right
            || received == Keys.Up && used == Keys.Down || received == Keys.Down && used == Keys.Up);
        }

        // Simple GameRestart function
        private void RestartGame()
        {
            // Can't restart a game that's not over yet
            if (!IsGameOver)
                return;

            // Just initialize the default values
            InitializeDefaults();

            // And make sure the snake can move again
            StartTimers();
        }

        // Flip snake head image, depending on the desired movement
        private void RotateSnakeHead()
        {
            // Reset the snake head's image
            SnakeHead.Image = Properties.Resources.SnakeHead;

            switch (Movement)
            {
                case Keys.Left:
                    {
                        // Flip the Snake Head's image
                        Image flipImage = SnakeHead.Image;
                        flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        SnakeHead.Image = flipImage;

                        break;
                    }
                case Keys.Right:
                    {
                        // Flip the Snake Head's image
                        Image flipImage = SnakeHead.Image;
                        flipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        SnakeHead.Image = flipImage;

                        break;
                    }
                case Keys.Up:
                    {
                        // Flip the Snake Head's image
                        Image flipImage = SnakeHead.Image;
                        flipImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        SnakeHead.Image = flipImage;

                        break;
                    }
            }
        }

        // Some key is pressed
        private void KeyDown_Event(object sender, KeyEventArgs e)
        {
            // If the user presses escape -- quit the game
            if (e.KeyCode == Keys.Escape)
                QuitGame();
            // If the user presses P -- pause the game
            else if (e.KeyCode == Keys.P)
                PauseGame();
            // If the user presses R -- restart the game
            else if (e.KeyCode == Keys.R)
                RestartGame();

            // Snake is moving in this direction already (no need to move towards it again)
            // Block 180 degree turns .... cuz the snake bites itself this way
            else if (e.KeyCode == Movement || Is180Movement(e.KeyCode, Movement))
                return;

            // Allows you to add future 'movement decision' almost simultaneously to the one that is already 'decided', which makes snake movement wayyyyyy smoother
            switch (e.KeyCode)
            {
                case Keys.Left: WantsMovement = Keys.Left; break;
                case Keys.Right: WantsMovement = Keys.Right; break;
                case Keys.Up: WantsMovement = Keys.Up; break;
                case Keys.Down: WantsMovement = Keys.Down; break;
                default: return;
            }

            // Prevents double direction movement/changing direction multiple times before the snake makes a move
            if (!HasMoved)
                return;

            //RotateSnakeHead(); // Rotates the snake's head to the direction you desire to go
            Movement = WantsMovement; // Change the movement to the desired movement
            HasMoved = false; // Make sure the snake can't change movement untill the body has moved
        }

        // Game over event
        private void GameOver()
        {
            IsGameOver = true; // Make game over variable to true
            StopTimers(); // Game is over -- stop all timers

            // Delete every part of the snake's body except the head (if they even exist)
            // Free memory, cuz there might be quite some instances if we don't ... can cause memory leak otherwise
            for (int i = SnakeBody.Count - 1; i > 0; i--)
            {
                Controls.Remove(SnakeBody[i]);
                SnakeBody[i].Dispose();
                SnakeBody.Remove(SnakeBody[i]);
            }

            // Draw game over
            // And since game over screen will be used again, when the user restarts the game, don't delete it ... keep it
            // Instead of dynamically creating and deleting it every time, load it up from the start ... and use it every time it's game over
            // No need to free the memory for such ... 'undemanding' process ... it might even cause more lag spikes when it's deleted and created dynamically all the time
            DrawGameOver.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
            DrawGameOver.Visible = true;

            if (Score > 0) // Make sure the user did something ... no need to save if he didn't
                SaveGameResults(); // Save the current game's results
        }

        // Save the current game's results
        private void SaveGameResults()
        {
            // Create a window to enter your name
            string promptValue = Prompt.InputBox("Score: " + Score, "Enter your name: ", "UNNAMED");

            promptValue.Trim(); // Trim the name
            if (promptValue == "") promptValue = "UNNAMED"; // Set default name if it was deleted from the input box

            // Now the hard part ... save score to a .txt file
            using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\SnakeGame.txt", true))
                writer.WriteLine($"{Score} {promptValue}"); // Write results to a .txt
        }

        // Just basic application exit
        private void QuitGame()
        {
            //MessageBox.Show("Goodbye");
            //Application.Exit(); // Closes the whole application instead of SnakeForm only
            this.Close(); // Closes only SnakeForm ... application execution continues
        }

        // Every second inside the game is being shown (how long you have survived)
        private void GameTime_Tick(object sender, EventArgs e)
        {
            TimePassed++;
            TimeLabel.Text = "Time: " + TimePassed;
        }

        private void EatFood()
        {
            // Update the score and the label's text
            Score += 100;
            ScoreLabel.Text = "Score: " + Score;

            // Create a new body part and add it to the project's controls
            PictureBox BodyPart = new PictureBox
            {
                Name = "SnakeBodyPart" + (SnakeBody.Count + 1),
                Image = Properties.Resources.SnakeBody,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(SnakeHead.Width, SnakeHead.Height),
                Tag = "body"
                //Location = new Point()
            };
            Controls.Add(BodyPart);

            // Set the new body part's location to the last body part's location in the BodyPart list and then add it as last to the BodyPart list
            BodyPart.Location = SnakeBody[SnakeBody.Count - 1].Location;
            SnakeBody.Add(BodyPart);
        }

        private void SnakeMovement_Tick(object sender, EventArgs e)
        {
            // Move each snake body part to the next body part's location
            // While also maintaining body part integrity (explanation: BodyPart6 can't move infront of BodyPart5)
            for (int i = SnakeBody.Count - 1; i > 0; i--)
                SnakeBody[i].Location = SnakeBody[i - 1].Location;

            // Heavier method to do the same as above
            /*for (int i = SnakeBody.Count - 1; i > 0; i--)
            {
                if (SnakeBody[i - 1].Location.X > SnakeBody[i].Location.X) SnakeBody[i].Left += Speed;
                else if (SnakeBody[i - 1].Location.X < SnakeBody[i].Location.X) SnakeBody[i].Left -= Speed;
                else if (SnakeBody[i - 1].Location.Y > SnakeBody[i].Location.Y) SnakeBody[i].Top += Speed;
                else if (SnakeBody[i - 1].Location.Y < SnakeBody[i].Location.Y) SnakeBody[i].Top -= Speed;
            }*/

            // Move the snake's head to the new position
            switch (Movement)
            {
                case Keys.Left: SnakeHead.Left -= Speed; break;
                case Keys.Right: SnakeHead.Left += Speed; break;
                case Keys.Up: SnakeHead.Top -= Speed; break;
                case Keys.Down: SnakeHead.Top += Speed; break;
            }

            HasMoved = true; // The snake moved (allow movement changing)
            RotateSnakeHead(); // Rotates the snake's head image to the direction you moved
            Movement = WantsMovement; // Change the movement to the desired movement (for the next tick ... unless it gets changed again, which is fine as well)

            // Check to see whether the snake's head collides with certain PictureBoxes
            foreach (PictureBox pictureBox in Controls.OfType<PictureBox>())
            {
                // Head doesn't collide with PictureBox -- return
                if (!SnakeHead.Bounds.IntersectsWith(pictureBox.Bounds))
                    continue;

                // Head collides with PictureBox with tag 'food'
                if ((string)pictureBox.Tag == "food")
                {
                    // Everything that needs to be done when the food is eaten
                    EatFood();

                    // Create food at random location within the walls and NOT inside the snake
                    FoodTimer_Tick(sender, e);
                    FoodTimer.Stop(); // This stops the food spawning timer
                    FoodTimer.Start(); // This starts the food spawning timer ... both of them combined 'restart' the timer
                }
                // If the snake bites it's own tail or the wall -- Game Over
                else if ((string)pictureBox.Tag == "wall" || (string)pictureBox.Tag == "body")
                    GameOver();
            }
        }

        // Spawn food at random location that is WITHIN the walls and NOT inside the snake
        private void FoodTimer_Tick(object sender, EventArgs e)
        {
            // Whether the food spawned inside the snake
            bool interacts;
            do
            {
                // Make sure the food spawns inside the walls
                var rnd1 = rnd.Next(Wall4.Right + SnakeFood.Size.Width, Wall2.Left - SnakeFood.Size.Width);
                var rnd2 = rnd.Next(Wall3.Bottom + SnakeFood.Size.Height, Wall1.Top - SnakeFood.Size.Height);
                SnakeFood.Location = new Point(rnd1, rnd2);

                // Check if the spawn location is inside the snake
                // And if it is, spawn food again
                interacts = false;
                foreach (PictureBox pb in SnakeBody)
                    if (pb.Bounds.IntersectsWith(SnakeFood.Bounds))
                    {
                        interacts = true;
                        break;
                    }
            } while (interacts);
            //MessageBox.Show("Distance of pixels horizontally: " + Food.Size.Height + " " + Food.Right + " " + Food.Top + " " + Food.Bottom);
        }

        // When the Welcome to Game intro is shown long enough ... delete it .. it won't be ever used again
        private void IntroTimer_Tick(object sender, EventArgs e)
        {
            IntroTimer.Dispose();
            Controls.Remove(WelcomeToGame);
            WelcomeToGame.Dispose();
            WelcomeToGame = null;
            GameTime.Start();
            SnakeMovement.Start();
            FoodTimer.Start();
        }
    }

    // A class defining different Prompts inside the current Form
    public static class Prompt
    {
        // Input prompt
        public static string InputBox(string title, string promptText, string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonOk.Click += (sender, e) => { form.Close(); };
            buttonOk.DialogResult = DialogResult.OK;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;

            form.ShowDialog();
            return textBox.Text;
        }
        
        // Output prompt --- not in use
        /*public static void OutputBox(string title, string promptText, string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 200);

            label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;

            form.ClientSize = new Size(816, 489);
            form.Controls.AddRange(new Control[] { label, textBox });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.ShowDialog();
        }*/
    }
}
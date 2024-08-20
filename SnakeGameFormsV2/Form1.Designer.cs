namespace SnakeGameFormsV2
{
    partial class SnakeGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Wall4 = new System.Windows.Forms.PictureBox();
            this.Wall3 = new System.Windows.Forms.PictureBox();
            this.Wall2 = new System.Windows.Forms.PictureBox();
            this.Wall1 = new System.Windows.Forms.PictureBox();
            this.SnakeFood = new System.Windows.Forms.PictureBox();
            this.SnakeHead = new System.Windows.Forms.PictureBox();
            this.IntroTimer = new System.Windows.Forms.Timer(this.components);
            this.SnakeMovement = new System.Windows.Forms.Timer(this.components);
            this.FoodTimer = new System.Windows.Forms.Timer(this.components);
            this.GameTime = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.WelcomeToGame = new System.Windows.Forms.PictureBox();
            this.DrawGameOver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wall4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeToGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawGameOver)).BeginInit();
            this.SuspendLayout();
            // 
            // Wall4
            // 
            this.Wall4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Wall4.Location = new System.Drawing.Point(0, 0);
            this.Wall4.Name = "Wall4";
            this.Wall4.Size = new System.Drawing.Size(50, 553);
            this.Wall4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall4.TabIndex = 5;
            this.Wall4.TabStop = false;
            this.Wall4.Tag = "wall";
            // 
            // Wall3
            // 
            this.Wall3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Wall3.Location = new System.Drawing.Point(0, 0);
            this.Wall3.Name = "Wall3";
            this.Wall3.Size = new System.Drawing.Size(1052, 50);
            this.Wall3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall3.TabIndex = 4;
            this.Wall3.TabStop = false;
            this.Wall3.Tag = "wall";
            // 
            // Wall2
            // 
            this.Wall2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Wall2.Location = new System.Drawing.Point(1002, 0);
            this.Wall2.Name = "Wall2";
            this.Wall2.Size = new System.Drawing.Size(50, 553);
            this.Wall2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall2.TabIndex = 3;
            this.Wall2.TabStop = false;
            this.Wall2.Tag = "wall";
            // 
            // Wall1
            // 
            this.Wall1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Wall1.Location = new System.Drawing.Point(0, 503);
            this.Wall1.Name = "Wall1";
            this.Wall1.Size = new System.Drawing.Size(1052, 50);
            this.Wall1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall1.TabIndex = 2;
            this.Wall1.TabStop = false;
            this.Wall1.Tag = "wall";
            // 
            // SnakeFood
            // 
            this.SnakeFood.Image = global::SnakeGameFormsV2.Properties.Resources.Food;
            this.SnakeFood.Location = new System.Drawing.Point(795, 243);
            this.SnakeFood.Name = "SnakeFood";
            this.SnakeFood.Size = new System.Drawing.Size(15, 15);
            this.SnakeFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SnakeFood.TabIndex = 1;
            this.SnakeFood.TabStop = false;
            this.SnakeFood.Tag = "food";
            // 
            // SnakeHead
            // 
            this.SnakeHead.Image = global::SnakeGameFormsV2.Properties.Resources.SnakeHead;
            this.SnakeHead.Location = new System.Drawing.Point(598, 116);
            this.SnakeHead.Name = "SnakeHead";
            this.SnakeHead.Size = new System.Drawing.Size(50, 50);
            this.SnakeHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SnakeHead.TabIndex = 0;
            this.SnakeHead.TabStop = false;
            this.SnakeHead.Tag = "head";
            // 
            // IntroTimer
            // 
            this.IntroTimer.Enabled = true;
            this.IntroTimer.Interval = 5000;
            this.IntroTimer.Tag = "intro";
            this.IntroTimer.Tick += new System.EventHandler(this.IntroTimer_Tick);
            // 
            // SnakeMovement
            // 
            this.SnakeMovement.Interval = 250;
            this.SnakeMovement.Tick += new System.EventHandler(this.SnakeMovement_Tick);
            // 
            // FoodTimer
            // 
            this.FoodTimer.Interval = 5000;
            this.FoodTimer.Tick += new System.EventHandler(this.FoodTimer_Tick);
            // 
            // GameTime
            // 
            this.GameTime.Interval = 1000;
            this.GameTime.Tick += new System.EventHandler(this.GameTime_Tick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.Color.White;
            this.TimeLabel.Location = new System.Drawing.Point(3, 24);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(73, 24);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "Time: 0";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreLabel.Location = new System.Drawing.Point(3, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(80, 24);
            this.ScoreLabel.TabIndex = 8;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // WelcomeToGame
            // 
            this.WelcomeToGame.Image = global::SnakeGameFormsV2.Properties.Resources.WelcomeToGame;
            this.WelcomeToGame.Location = new System.Drawing.Point(98, 79);
            this.WelcomeToGame.Name = "WelcomeToGame";
            this.WelcomeToGame.Size = new System.Drawing.Size(309, 179);
            this.WelcomeToGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WelcomeToGame.TabIndex = 10;
            this.WelcomeToGame.TabStop = false;
            this.WelcomeToGame.Tag = "welcome_screen";
            // 
            // DrawGameOver
            // 
            this.DrawGameOver.Image = global::SnakeGameFormsV2.Properties.Resources.GameOver;
            this.DrawGameOver.Location = new System.Drawing.Point(98, 296);
            this.DrawGameOver.Name = "DrawGameOver";
            this.DrawGameOver.Size = new System.Drawing.Size(309, 179);
            this.DrawGameOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawGameOver.TabIndex = 11;
            this.DrawGameOver.TabStop = false;
            this.DrawGameOver.Tag = "game_over_screen";
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1052, 554);
            this.Controls.Add(this.DrawGameOver);
            this.Controls.Add(this.WelcomeToGame);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.Wall4);
            this.Controls.Add(this.Wall3);
            this.Controls.Add(this.Wall2);
            this.Controls.Add(this.Wall1);
            this.Controls.Add(this.SnakeFood);
            this.Controls.Add(this.SnakeHead);
            this.Name = "SnakeGame";
            this.Tag = "window1";
            this.Text = "Snake Game";
            ((System.ComponentModel.ISupportInitialize)(this.Wall4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeToGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawGameOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SnakeHead;
        private System.Windows.Forms.PictureBox SnakeFood;
        private System.Windows.Forms.PictureBox Wall1;
        private System.Windows.Forms.PictureBox Wall2;
        private System.Windows.Forms.PictureBox Wall3;
        private System.Windows.Forms.PictureBox Wall4;
        private System.Windows.Forms.Timer IntroTimer;
        private System.Windows.Forms.Timer SnakeMovement;
        private System.Windows.Forms.Timer FoodTimer;
        private System.Windows.Forms.Timer GameTime;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.PictureBox WelcomeToGame;
        private System.Windows.Forms.PictureBox DrawGameOver;
    }
}


namespace SnakeGameFormsV2
{
    partial class ResultsWindow
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
            System.Windows.Forms.Label GameResultsLabel;
            this.GameResultsTextBox = new System.Windows.Forms.TextBox();
            GameResultsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameResultsLabel
            // 
            GameResultsLabel.AutoSize = true;
            GameResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GameResultsLabel.Location = new System.Drawing.Point(12, 88);
            GameResultsLabel.Name = "GameResultsLabel";
            GameResultsLabel.Size = new System.Drawing.Size(90, 25);
            GameResultsLabel.TabIndex = 0;
            GameResultsLabel.Tag = "results_label";
            GameResultsLabel.Text = "Results:";
            // 
            // GameResultsTextBox
            // 
            this.GameResultsTextBox.Location = new System.Drawing.Point(108, 12);
            this.GameResultsTextBox.Multiline = true;
            this.GameResultsTextBox.Name = "GameResultsTextBox";
            this.GameResultsTextBox.ReadOnly = true;
            this.GameResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GameResultsTextBox.Size = new System.Drawing.Size(680, 426);
            this.GameResultsTextBox.TabIndex = 1;
            this.GameResultsTextBox.Tag = "results_text_box";
            // 
            // ResultsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameResultsTextBox);
            this.Controls.Add(GameResultsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ResultsWindow";
            this.Tag = "window2";
            this.Text = "SnakeGame Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox GameResultsTextBox;
    }
}
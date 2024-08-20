using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace SnakeGameFormsV2
{
    public partial class ResultsWindow : Form
    {
        static List<ScoreBy> RecordsList = new List<ScoreBy>();

        public ResultsWindow()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // Center the window
            ReadFile();
        }

        private void ReadFile()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\SnakeGame.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line == "")
                            continue;

                        string[] duo = line.Split(new char[] { ' ' }, 2);
                        RecordsList.Add(new ScoreBy(Convert.ToInt32(duo[0]), duo[1]));
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                MessageBox.Show("The file could not be read:\n"+e.Message);
                return;
            }

            RecordsList.Sort();
            for (int i = 0; i < RecordsList.Count; i++)
            {
                GameResultsTextBox.Text += $"{i + 1}. " + RecordsList[i] + Environment.NewLine;
                //GameResultsTextBox.SelectionStart = GameResultsTextBox.TextLength;
                //GameResultsTextBox.ScrollToCaret();
            }
        }
    }

    public class ScoreBy : IEquatable<ScoreBy>, IComparable<ScoreBy>
    {
        private readonly int Score;
        private readonly string Name;

        public ScoreBy(int sc, string nm)
        {
            Score = sc;
            Name = nm;
        }

        public override int GetHashCode()
        {
            return Score;
        }
        public override string ToString()
        {
            return "Score: " + Score + ", by: " + Name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ScoreBy objAsPart = obj as ScoreBy;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        // Default comparer for Part type.
        public int CompareTo(ScoreBy compareObj)
        {
            // A null value means that this object is greater.
            if (compareObj == null)
                return 1;
            else
                return compareObj.Score.CompareTo(Score);
        }
        public bool Equals(ScoreBy other)
        {
            if (other == null) return false;
            return (Score.Equals(other.Score));
        }
        // Should also override == and != operators.
    }
}

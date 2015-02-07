using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Codestars_02
{
    public partial class mainForm : Form
    {
        enum State { MakingLetter, MakedLetter, MakedWord };

        public mainForm()
        {
            InitializeComponent();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = File.OpenText(openFileDialog.FileName);
                char start = 'a';
                start--;
                string line;
                State state = State.MakedWord;
                var yo = new Regex(@"Yo");
                var nice = new Regex(@"Nice");
                var count = 0;
                while ((line = file.ReadLine()) != null)
                {
                    var words = line.Split(' ');
                    foreach (var word in words)
                    {
                        if (yo.IsMatch(word)) {
                            count++;
                            state = State.MakingLetter;
                        }
                        else if (nice.IsMatch(word))
                        {
                            switch (state)
                            {
                                case State.MakingLetter:
                                    tbHit.Text += (char)(start + count);
                                    count = 0;
                                    state = State.MakedLetter;
                                    break;
                                case State.MakedLetter:
                                    tbHit.Text += ' ';
                                    state = State.MakedWord;
                                    break;
                                case State.MakedWord:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                file.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

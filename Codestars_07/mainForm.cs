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

namespace Codestars_07
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var file = File.OpenText(openFileDialog.FileName);
            string line;
            char[] starPart = { 'a', 'b', 'c', 'd' };
            char[] myPart = { 'w', 'x', 'y', 'z' };
            int[] maxs = { 0, 0 };
            int[] currents = { 0, 0 };
            bool isMyPart = false;

            while ((line = file.ReadLine()) != null)
            {
                foreach (var ch in line)
                {
                    if (isMyPart)
                    {
                        if (myPart.Contains(ch)) currents[1]++;
                        if (starPart.Contains(ch))
                        {
                            if (maxs[1] < currents[1]) maxs[1] = currents[1];
                            isMyPart = false;
                            currents[0]++;
                            currents[1] = 0;
                        }
                    }
                    else
                    {
                        if (myPart.Contains(ch))
                        {
                            if (maxs[0] < currents[0]) maxs[0] = currents[0];
                            isMyPart = true;
                            currents[1]++;
                            currents[0] = 0;
                        }
                        if (starPart.Contains(ch)) currents[0]++;
                    }
                }
            }

            file.Close();

            if (maxs[0] < currents[0]) maxs[0] = currents[0];
            if (maxs[1] < currents[1]) maxs[1] = currents[1];

            tbPercents.Text = ((float)maxs[1] / (float)(maxs[0] + maxs[1]) * 100).ToString() + "%";
        }
    }
}

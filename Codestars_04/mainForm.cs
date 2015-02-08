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

namespace Codestars_04
{
    public partial class mainForm : Form
    {
        Graph graph = null;
        
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
            graph = new Graph();
            while ((line = file.ReadLine()) != null)
            {
                var languages = line.Split(' ');
                graph.CreateLink(languages[1], languages[2]);
            }
            file.Close();
            string[] langs = graph.GetPointsAsObjects();
            Array.Sort(langs);
            cbFirstLanguage.Items.AddRange(langs);
            if (cbFirstLanguage.Items.Count != 0) cbFirstLanguage.SelectedIndex = 0;
            cbSecondLanguage.Items.AddRange(langs);
            if (cbSecondLanguage.Items.Count != 0) cbSecondLanguage.SelectedIndex = 0;
        }

        private void CalculateShortcut()
        {
            int count = -1;
            List<string> shortcut = null;
            if (graph != null) shortcut = graph.GetShortcut(cbFirstLanguage.SelectedItem.ToString(),
                    cbSecondLanguage.SelectedItem.ToString());
            if (shortcut != null) count = shortcut.Count - 1;
            switch (count)
            {
                case -1:
                    tbTranslators.Text = "Невозможно перевести";
                    break;
                case 0:
                    tbTranslators.Text = "Один и тот же язык";
                    break;
                default:
                    tbTranslators.Text = count.ToString();
                    break;
            }
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFirstLanguage.SelectedItem != null && cbSecondLanguage.SelectedItem != null) CalculateShortcut();
        }
    }
}

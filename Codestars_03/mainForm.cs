using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Codestars_03
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
            var languages = new List<HashSet<int>>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var fairies = new HashSet<int>();
                foreach (var fairy in line.Split(' ')) fairies.Add(int.Parse(fairy));
                var currentLanguages = new List<HashSet<int>>();
                foreach (var fairy in fairies)
                    foreach (var language in languages)
                        if (language.Contains(fairy))
                            currentLanguages.Add(language);
                if (currentLanguages.Count == 0) languages.Add(fairies);
                else
                {
                    for (int i = 1; i < currentLanguages.Count; i++)
                    {
                        if (currentLanguages[0] != currentLanguages[1])
                        {
                            currentLanguages[0].UnionWith(currentLanguages[i]);
                            languages.Remove(currentLanguages[i]);
                        }
                    }
                    foreach (var fairy in fairies)
                        if (!currentLanguages[0].Contains(fairy)) currentLanguages[0].Add(fairy);
                }
            }

            nudCount.Value = languages.Count;
            file.Close();
        }
    }
}

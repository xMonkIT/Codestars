using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codestars_01
{
    public partial class mainForm : Form
    {
        static BigInteger getCount(BigInteger count)
        {
            if (count == 1) return 1;
            else return count * getCount(count - 1);
        }

        public mainForm()
        {
            InitializeComponent();
        }

        private void nudGirlsCount_ValueChanged(object sender, EventArgs e)
        {
            tbTime.Text = "";
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            tbTime.Text = (getCount((BigInteger)nudGirlsCount.Value) / 360).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalRangeSelection
{


    public partial class Form1 : Form
    {
        private Form childForm;


        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            var solver = new Solver("pants", "jackets");

            if (int.TryParse(tb21x.Text, out int argx1) &&
                int.TryParse(tb22x.Text, out int argx2) &&
                int.TryParse(tb21y.Text, out int argy1) &&
                int.TryParse(tb22y.Text, out int argy2) &&
                int.TryParse(tb21result.Text, out int wyn1) &&
                int.TryParse(tb22result.Text, out int wyn2))
            {
                solver.AddProductionContraints(argx1, argy1, argx2, argy2, wyn1, wyn2);
            };

            if (int.TryParse(tb31result.Text, out int res1) &&
                int.TryParse(tb32result.Text, out int res2))
            {
                solver.AddNonNegativeVariables(res1, res2);
            }

            if (int.TryParse(tb1x.Text, out int argx) &&
                int.TryParse(tb1y.Text, out int argy))
            {
                solver.AddGoal(argx, argy);
            }

            solver.Solve();
            solver.PrintResults(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}

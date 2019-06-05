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
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button3.Visible = false;
            var solver = new Solver(textBox2.Text, textBox3.Text);

            if (int.TryParse(tb21x.Text, out int argx1) &&
                int.TryParse(tb22x.Text, out int argx2) &&
                int.TryParse(tb21y.Text, out int argy1) &&
                int.TryParse(tb22y.Text, out int argy2) &&
                int.TryParse(textBox4.Text, out int argx3) &&
                int.TryParse(textBox5.Text, out int argy3) &&
                int.TryParse(tb21result.Text, out int wyn1) &&
                int.TryParse(tb22result.Text, out int wyn2) &&
                int.TryParse(textBox6.Text, out int wyn3))
            {
                solver.AddProductionContraints(argx1, argy1, argx2, argy2, argx3, argy3, wyn1, wyn2, wyn3);
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

        private void Button4_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            tb1x.Visible = true;
            tb1y.Visible = true;
            //textBox2.ReadOnly = true;
            //textBox3.ReadOnly = true;
            button2.Visible = true;
            button4.Visible = false;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            label5.Text = label8.Text = label9.Text = textBox2.Text;
            label6.Text = label7.Text = label17.Text = textBox3.Text;
            //tb1x.ReadOnly = tb1y.ReadOnly = true;
            button2.Visible = false;
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            label10.Text = textBox2.Text;
            label11.Text = textBox3.Text;
            button3.Visible = false;
        }
    }
}

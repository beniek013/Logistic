using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransportotationAndProductionIssue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var textBoxes = new List<TextBox>() { textBox1, textBox2 };
            ListViewItem item = new ListViewItem();
            item.SubItems[0] = new ListViewItem.ListViewSubItem(item, textBox1.Text);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, textBox2.Text));
            listView1.Items.Add(item);
            textBoxes.ForEach(x => x.Clear());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var textBoxes = new List<TextBox>() { textBox3, textBox4, textBox5, textBox6 };
            ListViewItem item = new ListViewItem();
            item.SubItems[0] = new ListViewItem.ListViewSubItem(item, textBox4.Text);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, textBox3.Text));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, textBox6.Text));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, textBox5.Text));
            listView2.Items.Add(item);
            textBoxes.ForEach(x => x.Clear());
        }
    }
}

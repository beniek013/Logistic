using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logistyka;

namespace Logistyka
{
    public partial class Form1 : Form
    {
        public List<Activity> activities;
        public Form1()
        {
            InitializeComponent();
            activities = new List<Activity>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var textBoxes = new List<TextBox>() { textBoxName, textBoxDuration, textBoxPrecessorId };
            if (!String.IsNullOrWhiteSpace(textBoxId.Text) &&
                !String.IsNullOrWhiteSpace(textBoxName.Text) &&
                !String.IsNullOrWhiteSpace(textBoxDuration.Text)&&
                int.TryParse(textBoxId.Text, out int Id))
            {
                label1.Visible = false;
                ListViewItem item = new ListViewItem(textBoxId.Text);
                item.SubItems.AddRange(textBoxes.Select(x => x.Text).ToArray());
                var test = textBoxes.Select(x => x.Text).ToArray();
                listView1.Items.Add(item);
                activities.Add(new Activity(Id, textBoxName.Text, textBoxDuration.Text, textBoxPrecessorId.Text));
                textBoxId.Clear();
                textBoxes.ForEach(x => x.Clear());
            }
            else {
                label1.Visible = true;
            }
        }   

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void bt3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count > 0)
                listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var duration = new int[] { 5,3,4,6,4,3};
            var names = "ABCDEF";
            var preccessorId = new List<string>() {"","1", "","1","4","2;3;4" };
            for (int i = 0; i < 6; i++)
            {
                ListViewItem item = new ListViewItem((i+1).ToString());
                item.SubItems.Add(names[i].ToString());
                item.SubItems.Add(duration[i].ToString());
                item.SubItems.Add(preccessorId[i].ToString());
                listView1.Items.Add(item);
                activities.Add(new Activity(i + 1, names[i].ToString(), duration[i].ToString(), preccessorId[i].ToString()));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = activities.ToList().First().Duration;
        }
    }
}

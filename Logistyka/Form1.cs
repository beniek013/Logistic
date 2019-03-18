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
        TextBox txtLog;
        GanttChart ganttChart1;



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

        

        private void button4_Click(object sender, EventArgs e)
        {
            

            txtLog = new TextBox();
            txtLog.Dock = DockStyle.Fill;
            txtLog.Multiline = true;
            txtLog.Enabled = false;
            txtLog.ScrollBars = ScrollBars.Horizontal;
            tableLayoutPanel1.Controls.Add(txtLog, 0, 3);

            //first Gantt Chart
            ganttChart1 = new GanttChart();
            ganttChart1.AllowChange = false;
            ganttChart1.Dock = DockStyle.Fill;
            ganttChart1.FromDate = new DateTime(2015, 12, 12, 0, 0, 0);
            ganttChart1.ToDate = new DateTime(2015, 12, 24, 0, 0, 0);
            tableLayoutPanel1.Controls.Add(ganttChart1, 0, 1);

            ganttChart1.MouseMove += new MouseEventHandler(ganttChart1.GanttChart_MouseMove);
            ganttChart1.MouseMove += new MouseEventHandler(GanttChart1_MouseMove);
            ganttChart1.MouseDragged += new MouseEventHandler(ganttChart1.GanttChart_MouseDragged);
            ganttChart1.MouseLeave += new EventHandler(ganttChart1.GanttChart_MouseLeave);
            ganttChart1.ContextMenuStrip = ContextMenuGanttChart1;

            List<BarInformation> lst1 = new List<BarInformation>();

            foreach(Activity act in activities)
            {
                lst1.Add(new BarInformation());
            }


            lst1.Add(new BarInformation("Row 1", new DateTime(2015, 12, 12), new DateTime(2015, 12, 16), Color.Aqua, Color.Khaki, 0));
            lst1.Add(new BarInformation("Row 2", new DateTime(2015, 12, 13), new DateTime(2015, 12, 20), Color.AliceBlue, Color.Khaki, 1));
            lst1.Add(new BarInformation("Row 3", new DateTime(2015, 12, 14), new DateTime(2015, 12, 24), Color.Violet, Color.Khaki, 2));
            lst1.Add(new BarInformation("Row 2", new DateTime(2015, 12, 21), new DateTime(2015, 12, 22, 12, 0, 0), Color.Yellow, Color.Khaki, 1));
            lst1.Add(new BarInformation("Row 1", new DateTime(2015, 12, 17), new DateTime(2015, 12, 24), Color.LawnGreen, Color.Khaki, 0));

            foreach (BarInformation bar in lst1)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }

        }

        private void GanttChart1_MouseMove(Object sender, MouseEventArgs e)
        {
            List<string> toolTipText = new List<string>();

            if (ganttChart1.MouseOverRowText.Length > 0)
            {
                BarInformation val = (BarInformation)ganttChart1.MouseOverRowValue;
                toolTipText.Add("[b]Date:");
                toolTipText.Add("From ");
                toolTipText.Add(val.FromTime.ToLongDateString() + " - " + val.FromTime.ToString("HH:mm"));
                toolTipText.Add("To ");
                toolTipText.Add(val.ToTime.ToLongDateString() + " - " + val.ToTime.ToString("HH:mm"));
            }
            else
            {
                toolTipText.Add("");
            }

            ganttChart1.ToolTipTextTitle = ganttChart1.MouseOverRowText;
            ganttChart1.ToolTipText = toolTipText;

        }


    }
}

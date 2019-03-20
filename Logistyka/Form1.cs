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
        List<BarInformation> lst1 = new List<BarInformation>();

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
            var duration = new int[] { 5,3,4,6};
            var names = "ABCD";
            var preccessorId = new List<string>() {"","1", "1,2","2,3"};
            for (int i = 0; i < 4; i++)
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
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

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
            ganttChart1.FromDate = new DateTime(2015, 12, 1, 0, 0, 0);
            ganttChart1.ToDate = ganttChart1.FromDate.AddDays(20);
            tableLayoutPanel1.Controls.Add(ganttChart1, 0, 1);

            ganttChart1.MouseMove += new MouseEventHandler(ganttChart1.GanttChart_MouseMove);
            ganttChart1.MouseMove += new MouseEventHandler(GanttChart1_MouseMove);
            ganttChart1.MouseDragged += new MouseEventHandler(ganttChart1.GanttChart_MouseDragged);
            ganttChart1.MouseLeave += new EventHandler(ganttChart1.GanttChart_MouseLeave);
            ganttChart1.ContextMenuStrip = ContextMenuGanttChart1;

            
            lst1.Clear();

            
            foreach(ListViewItem lst in listView1.Items)
            {
                string tmp = lst.SubItems[3].Text;
                int X = 0;
                if (tmp != "")
                {
                    string[] array = tmp.Split(',');
                    
                    int fes = 0;
                    foreach (String ar in array)
                    {
                        fes = Int32.Parse(ar);
                        if (fes >= X)
                            X = fes;
                    }
                }

                
                if (lst.SubItems[3].Text == "")
                {
                    lst1.Add(new BarInformation("Row " + lst.SubItems[0].Text,
                        new DateTime(2015, 12, 1), new DateTime(2015, 12, 1).AddDays(Int32.Parse(lst.SubItems[2].Text)),
                        Color.Blue, Color.Red,
                        Int32.Parse(lst.SubItems[0].Text),
                         lst.SubItems[3].Text));
                }
                else
                {
                    label1.Visible = true;
                    lst1.Add(new BarInformation("Row " + lst.SubItems[0].Text,
                        new DateTime(2015, 12, 1).AddDays(lst1[X-1].ToTime.Day-1),
                        new DateTime(2015, 12, 1).AddDays(lst1[X-1].ToTime.Day+ Int32.Parse(lst.SubItems[2].Text)-1),
                        Color.Blue,
                        Color.Red,
                         Int32.Parse(lst.SubItems[0].Text),
                         lst.SubItems[3].Text));
                }
            }

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
                toolTipText.Add("Precessors:");
                toolTipText.Add(val.Precessors);
                
            }
            else
            {
                toolTipText.Add("");
            }

            ganttChart1.ToolTipTextTitle = ganttChart1.MouseOverRowText;
            ganttChart1.ToolTipText = toolTipText;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
        }
    }
}

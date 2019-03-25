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

        public List<Activity> allActivieties;
        public List<Event> allEvents;


        public Form1()
        {
            InitializeComponent();
            allActivieties = new List<Activity>();
            allEvents = new List<Event>();
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
                allActivieties.Add(new Activity(Id, textBoxName.Text, textBoxDuration.Text, textBoxPrecessorId.Text));
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
            allActivieties = new List<Activity>();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var duration = new int[] { 15,9,7,8,15,17,18,11,9,11,13,10,4,6};
            var names = "ABCDEFGHIJKLMN";
            var preccessorId = new List<string>() {"","", "1","1,2", "1,2", "3,4", "3,4", "5,7", "5,7", "6,9", "6,9", "8", "10", "11,12,13" };
            for (int i = 0; i < names.Length; i++)
            {
                ListViewItem item = new ListViewItem((i+1).ToString());
                item.SubItems.Add(names[i].ToString());
                item.SubItems.Add(duration[i].ToString());
                item.SubItems.Add(preccessorId[i].ToString());
                listView1.Items.Add(item);
                allActivieties.Add(new Activity(i + 1, names[i].ToString(), duration[i].ToString(), preccessorId[i].ToString()));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
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
            ganttChart1.FromDate = new DateTime(2015, 03, 1, 0, 0, 0);
            ganttChart1.ToDate = ganttChart1.FromDate.AddDays(70);
            tableLayoutPanel1.Controls.Add(ganttChart1, 0, 1);

            ganttChart1.MouseMove += new MouseEventHandler(ganttChart1.GanttChart_MouseMove);
            ganttChart1.MouseMove += new MouseEventHandler(GanttChart1_MouseMove);
            ganttChart1.MouseDragged += new MouseEventHandler(ganttChart1.GanttChart_MouseDragged);
            ganttChart1.MouseLeave += new EventHandler(ganttChart1.GanttChart_MouseLeave);
            ganttChart1.ContextMenuStrip = ContextMenuGanttChart1;

            
            lst1.Clear();

            var list = new List<int>();
            
            foreach(ListViewItem lst in listView1.Items)
            {
                string tmp = lst.SubItems[3].Text;
                int X = 0;
                list.Add(int.Parse(lst.SubItems[2].Text));
                if (tmp != "")
                {
                    int max = 0;
                    int id = 0;
                    string[] array = tmp.Split(',');
                    foreach(string m in array)
                    {
                       if((list[int.Parse(m)-1]+ int.Parse(lst.SubItems[2].Text)) > max)
                        {
                            max = list[int.Parse(m) - 1]+int.Parse(lst.SubItems[2].Text);
                            id = int.Parse(m);         
                         }
                    }
                    list[int.Parse(lst.SubItems[0].Text) - 1] += (max- int.Parse(lst.SubItems[2].Text));
                    X = id;
                    //var test = allActivieties.FindAll(x => array.Contains(x.Id.ToString()));
                    
                    //var find = allActivieties.FindAll(x => array.Contains(x.Id.ToString())).OrderBy(x => x.Duration).First();
                    //list[listView1.Items.IndexOf(lst)] += int.Parse(find.Duration);
                    //X = find.Id;
                    //t fes = 0;
                }

                
                if (lst.SubItems[3].Text == "")
                {
                    lst1.Add(new BarInformation(
                        "Row " + lst.SubItems[0].Text,
                        new DateTime(2015, 03, 01),
                        new DateTime(2015, 03, 01).AddDays(Int32.Parse(lst.SubItems[2].Text)),
                        Color.Blue, Color.Red,
                        Int32.Parse(lst.SubItems[0].Text),
                         lst.SubItems[3].Text));
                }
                else
                {
                    //problemem jest to, że jeśli liczba dni przekroczy 30 dni, miesiąc nie przeskakuje na następny 
                    int number_of_days_in_months=0;
                    for(int i=0;i< lst1[X - 1].ToTime.Month;i++)
                    {
                        number_of_days_in_months += DateTime.DaysInMonth(2015, i+1);

                    }
                    //minus days to March
                    number_of_days_in_months -= (31+28+31);
                    lst1.Add(new BarInformation("Row " + lst.SubItems[0].Text,
                        new DateTime(2015, 03, 01).AddDays(lst1[X-1].ToTime.Day+number_of_days_in_months-1),
                        new DateTime(2015, 03, 01).AddDays(lst1[X-1].ToTime.Day+ Int32.Parse(lst.SubItems[2].Text)+number_of_days_in_months),
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

        private void LOAD2_Click(object sender, EventArgs e)
        {
            var duration = new int[] { 5, 3, 4, 6, 4, 3 };
            var names = "ABCDEF";
            var preccessorId = new List<string>() { "", "1", "", "1", "4", "2,3,4" };
            for (int i = 0; i < names.Length; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(names[i].ToString());
                item.SubItems.Add(duration[i].ToString());
                item.SubItems.Add(preccessorId[i].ToString());
                listView1.Items.Add(item);
                allActivieties.Add(new Activity(i + 1, names[i].ToString(), duration[i].ToString(), preccessorId[i].ToString()));
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            CalculateCriticalPath();
            /*var criticalPath = new List<Activity>();
            var firsts = allActivieties.Where(x => String.IsNullOrWhiteSpace(x.PrecessorId)).ToList();
            criticalPath.Add(LongestPath(firsts));
            while (allActivieties.Any(x => x.PrecessorId.Contains(criticalPath.Last().Id.ToString()))) {
                var concerned = allActivieties.Where(x => x.PrecessorId.Contains(criticalPath.Last().Id.ToString())).ToList();
                criticalPath.Add(LongestPath(concerned));
            }
            criticalPathTxt.Text = criticalPath.Sum(x => int.Parse(x.Duration)).ToString();
            List<string> toolTipText = new List<string>();
            lst1.ToList();
            var critical = lst1.Where(y => criticalPath.Select(x => x.Id).Contains(y.Index)).ToList();
            foreach (var row in critical) {
                ganttChart1.AddChartBar($"Row {row.Index}", row, row.FromTime, row.ToTime, Color.Black, Color.Red, row.Index);
            }
            ganttChart1.PaintChart();*/
        }

        private void CalculateCriticalPath()
        {
            var criticalPath = new List<Activity>();
            var last = lst1.ToList().OrderByDescending(x => x.ToTime).First();
            criticalPath.Add(allActivieties.Find(x => x.Id == last.Index));
            while (allActivieties.Any(x => criticalPath.Last().PrecessorId.Contains(x.Id.ToString()))) {
                var concerned = allActivieties.Where(x => criticalPath.Last().PrecessorId.Contains(x.Id.ToString())).ToList();
                criticalPath.Add(LongestPath(concerned));
            }
            criticalPathTxt.Text = criticalPath.Sum(x => int.Parse(x.Duration)).ToString();
            List<string> toolTipText = new List<string>();
            lst1.ToList();
            var critical = lst1.Where(y => criticalPath.Select(x => x.Id).Contains(y.Index)).ToList();
            criticalTxt.Text = String.Join(" - ", criticalPath.Select(x => x.Name).OrderBy(y => y));
            foreach (var row in critical)
            {
                ganttChart1.AddChartBar($"Row {row.Index}", row, row.FromTime, row.ToTime, Color.Black, Color.Red, row.Index);
            }
            ganttChart1.PaintChart();
        }



        private static Activity LongestPath(List<Activity> activities) {
            return activities.OrderByDescending(x => x.Duration).First();
        }
    }
}

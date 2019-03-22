namespace Logistyka
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.textBoxPrecessorId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.criticalPathTxt = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.LOAD2 = new System.Windows.Forms.Button();
            this.CalculateCriticlal = new System.Windows.Forms.Button();
            this.criticalTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Prestige Elite Std", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(17, 17);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(751, 24);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Logistyka w hutnictwie. Wykres Gantta i sciezka krytyczna";
            this.lb1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 73);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(531, 149);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // column1
            // 
            this.column1.Text = "ID";
            this.column1.Width = 108;
            // 
            // column2
            // 
            this.column2.Text = "Name";
            this.column2.Width = 108;
            // 
            // column3
            // 
            this.column3.Text = "Duration";
            this.column3.Width = 86;
            // 
            // column4
            // 
            this.column4.Text = "Precessor ID";
            this.column4.Width = 93;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(22, 228);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(91, 20);
            this.textBoxId.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(119, 228);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(86, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(211, 228);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(83, 20);
            this.textBoxDuration.TabIndex = 5;
            // 
            // textBoxPrecessorId
            // 
            this.textBoxPrecessorId.Location = new System.Drawing.Point(300, 228);
            this.textBoxPrecessorId.Name = "textBoxPrecessorId";
            this.textBoxPrecessorId.Size = new System.Drawing.Size(74, 20);
            this.textBoxPrecessorId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(35, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID, name i duration są wymagane!!";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // bt2
            // 
            this.bt2.Location = new System.Drawing.Point(549, 199);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(192, 23);
            this.bt2.TabIndex = 8;
            this.bt2.Text = "Wyczyść wszystko";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt3
            // 
            this.bt3.Location = new System.Drawing.Point(549, 157);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(192, 23);
            this.bt3.TabIndex = 9;
            this.bt3.Text = "Usuń zaznaczone";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Załaduj przykładowy zestaw";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // criticalPathTxt
            // 
            this.criticalPathTxt.Location = new System.Drawing.Point(540, 322);
            this.criticalPathTxt.Name = "criticalPathTxt";
            this.criticalPathTxt.Size = new System.Drawing.Size(100, 20);
            this.criticalPathTxt.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 319);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Rysuj wykres Gantta";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.10714F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8928571F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 348);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.941176F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.05882F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1030, 228);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(199, 319);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Wyczyść wykres";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // LOAD2
            // 
            this.LOAD2.Location = new System.Drawing.Point(549, 115);
            this.LOAD2.Name = "LOAD2";
            this.LOAD2.Size = new System.Drawing.Size(192, 23);
            this.LOAD2.TabIndex = 16;
            this.LOAD2.Text = "Załaduj przykładowy zestaw 2";
            this.LOAD2.UseVisualStyleBackColor = true;
            this.LOAD2.Click += new System.EventHandler(this.LOAD2_Click);
            // 
            // CalculateCriticlal
            // 
            this.CalculateCriticlal.Location = new System.Drawing.Point(366, 319);
            this.CalculateCriticlal.Name = "CalculateCriticlal";
            this.CalculateCriticlal.Size = new System.Drawing.Size(157, 23);
            this.CalculateCriticlal.TabIndex = 17;
            this.CalculateCriticlal.Text = "Ścieżka krytyczna";
            this.CalculateCriticlal.UseVisualStyleBackColor = true;
            this.CalculateCriticlal.Click += new System.EventHandler(this.Button6_Click);
            // 
            // criticalTxt
            // 
            this.criticalTxt.Location = new System.Drawing.Point(646, 322);
            this.criticalTxt.Name = "criticalTxt";
            this.criticalTxt.Size = new System.Drawing.Size(175, 20);
            this.criticalTxt.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Prestige Elite Std", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Prestige Elite Std", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(413, 593);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(408, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Aplikacje wykonali: Pałucki Mateusz, Słonina Paweł";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 648);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.criticalTxt);
            this.Controls.Add(this.CalculateCriticlal);
            this.Controls.Add(this.LOAD2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.criticalPathTxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrecessorId);
            this.Controls.Add(this.textBoxDuration);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.ColumnHeader column4;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.TextBox textBoxPrecessorId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox criticalPathTxt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        internal System.Windows.Forms.ContextMenuStrip ContextMenuGanttChart1;
        internal System.Windows.Forms.ToolStripMenuItem SaveImageToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button LOAD2;
        private System.Windows.Forms.Button CalculateCriticlal;
        private System.Windows.Forms.TextBox criticalTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


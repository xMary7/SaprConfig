namespace WindowsFormsApp1
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.refPageTB = new System.Windows.Forms.TextBox();
            this.testedPageTB = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataTypeCB = new System.Windows.Forms.ComboBox();
            this.accuracyLb = new System.Windows.Forms.Label();
            this.timeProfit = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "C:\\Users\\User\\Documents\\data4.txt";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(300, 458);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "20";
            // 
            // refPageTB
            // 
            this.refPageTB.Location = new System.Drawing.Point(659, 42);
            this.refPageTB.Name = "refPageTB";
            this.refPageTB.Size = new System.Drawing.Size(100, 26);
            this.refPageTB.TabIndex = 2;
            // 
            // testedPageTB
            // 
            this.testedPageTB.Location = new System.Drawing.Point(659, 99);
            this.testedPageTB.Name = "testedPageTB";
            this.testedPageTB.Size = new System.Drawing.Size(100, 26);
            this.testedPageTB.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Lance-Wiliams",
            "FastLance-Wiliams"});
            this.comboBox1.Location = new System.Drawing.Point(228, 302);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Lance-Wiliams";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "nearest neightbor",
            "furthest neightbor",
            "average",
            "centroid",
            "Wards"});
            this.comboBox2.Location = new System.Drawing.Point(228, 358);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(172, 28);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "nearest neighbor";
            // 
            // dataTypeCB
            // 
            this.dataTypeCB.FormattingEnabled = true;
            this.dataTypeCB.Items.AddRange(new object[] {
            "dichotomic",
            "numeric"});
            this.dataTypeCB.Location = new System.Drawing.Point(229, 402);
            this.dataTypeCB.Name = "dataTypeCB";
            this.dataTypeCB.Size = new System.Drawing.Size(172, 28);
            this.dataTypeCB.TabIndex = 6;
            this.dataTypeCB.Text = "numeric";
            // 
            // accuracyLb
            // 
            this.accuracyLb.AutoSize = true;
            this.accuracyLb.Location = new System.Drawing.Point(745, 366);
            this.accuracyLb.Name = "accuracyLb";
            this.accuracyLb.Size = new System.Drawing.Size(14, 20);
            this.accuracyLb.TabIndex = 8;
            this.accuracyLb.Text = "-";
            // 
            // timeProfit
            // 
            this.timeProfit.AutoSize = true;
            this.timeProfit.Location = new System.Drawing.Point(745, 302);
            this.timeProfit.Name = "timeProfit";
            this.timeProfit.Size = new System.Drawing.Size(14, 20);
            this.timeProfit.TabIndex = 9;
            this.timeProfit.Text = "-";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(410, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 40);
            this.button4.TabIndex = 10;
            this.button4.Text = "Choose";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 525);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 32);
            this.button3.TabIndex = 11;
            this.button3.Text = "Execute";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "File with data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Algorithm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Distance between clusters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Data type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Random n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Reference page";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(538, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tested page";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(578, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Time Profit, per";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(578, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Accuracy, per";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Industry1",
            "Industry2",
            "Industry3",
            "Industry4",
            "Industry5",
            "Industry6",
            "Others"});
            this.comboBox3.Location = new System.Drawing.Point(228, 105);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(172, 28);
            this.comboBox3.TabIndex = 22;
            this.comboBox3.Text = "Industry1";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Industry of design";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(228, 165);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(173, 26);
            this.textBox3.TabIndex = 24;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(228, 240);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(172, 26);
            this.textBox4.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Cost of the project";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Design duration";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 580);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.timeProfit);
            this.Controls.Add(this.accuracyLb);
            this.Controls.Add(this.dataTypeCB);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.testedPageTB);
            this.Controls.Add(this.refPageTB);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox refPageTB;
        private System.Windows.Forms.TextBox testedPageTB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox dataTypeCB;
        private System.Windows.Forms.Label accuracyLb;
        private System.Windows.Forms.Label timeProfit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}


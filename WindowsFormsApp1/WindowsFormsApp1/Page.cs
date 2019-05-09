using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Page : Form
    {
        //private PictureBox pictureBox = new PictureBox();
        //private TextBox countOfClustersTB = new TextBox();
        //private RichTextBox infoOfClustersRTB = new RichTextBox();
       // private Label F1Lb = new Label();
        //private Label F2Lb = new Label();

        int number;
        Dendogram d;
        private PictureBox pictureBox;
        private TextBox countOfClustersTB;
        private RichTextBox infoOfClustersRTB;
        private Label F1Lb;
        private Label F2Lb;
        private Button executeBtn;
        private CheckBox manualCB;
        private Button Export;
        private Label label1;
        private Label label2;
        private Label label3;
        Bitmap btm;
        public void ChangeNumber(int Number)
        {
            number = Number;
            Text = "Page " + Number;
        }
        public Page(int Number, Dendogram Out, Double cost, Double duration)
        {

            InitializeComponent();
            ChangeNumber(Number);
            Out = PostAnalysis(Out, cost, duration);
            d = Out;
            if (d.fullData.Count > 1)
            {
               // btm = d.GetPicture(d.AutoCount);
               // pictureBox.Width = btm.Width;
                //pictureBox.Height = btm.Height;
                //pictureBox.Image = btm;
                //countOfClustersTB.Text = d.AutoCount.ToString();
                infoOfClustersRTB.Text = GetInfoOfClusters();
                //pictureBox.Show();
                //double F1 = (AnalysisOfClustering.F1(d.fullData, d.clusters));
                //double F2 = (AnalysisOfClustering.F4(d.fullData, d.clusters));
                //F1Lb.Text = F1.ToString();
                //F2Lb.Text = F2.ToString() + "\n" + (F1 / F2).ToString();
                //string s1 = ""; string s2 = "";
                //for (int i = 1; i <= d.fullData.Count; i++)
                //{
                //    btm = d.GetPicture(i);
                //    s1 += (AnalysisOfClustering.F1(d.fullData, d.clusters)).ToString() + "\t";
                //    s2 += (AnalysisOfClustering.F4(d.fullData, d.clusters)).ToString() + "\t";
                //}
                //infoOfClustersRTB.Text += "F1:" + s1 + "\n";
                //infoOfClustersRTB.Text += "F2:" + s2 + "\n";
            }
            else
            {
                //countOfClustersTB.Text = d.AutoCount.ToString();
                countOfClustersTB.Text = d.fullData.Count.ToString();
                infoOfClustersRTB.Text = GetInfoOfClusters();
            }
        }

        private string GetInfoOfClusters()
        {
            

            string str = "";
            if (d.fullData.Count > 1)
            {
                for (int i = 0; i < d.clusters.Count; i++)
                {
                    List<Object> temp = new List<Object>();
                    d.clusters[i].Sort();                  
                    
                    //str += d.clusters[i][0] + ": " + d.fullData[i][0] + " ";
                    for (int elem = 0; elem < d.clusters[i].Count; elem++)
                    {
                        
                       // str += d.clusters[i][elem] + ": ";
                        for (int n = 0; n < d.fullData[d.clusters[i][elem]].Count; n++) {
                            Type t = d.fullData[d.clusters[i][elem]][n].GetType();
                            if (!t.Equals(typeof(Double)))
                            {
                                temp.Add(d.fullData[d.clusters[i][elem]][n]);
                                //str += d.fullData[elem][n] + " ";
                            }
                        }
                        //str += "\n";
                    }
                    if (temp.Count != 0)
                    {
                        str += "Cluster " + (i + 1) + ":\n{";
                        IEnumerable<Object> subsystems = temp.Distinct();
                        foreach (var ss in subsystems)
                        {
                            str += ss + " \n";
                        }

                        str += "}\n";
                    }
                    temp.Clear();
                }
            }
            else
            {
                List<Object> temp = new List<Object>();
                str += "Cluster 1: {";
               // str += d.fullData[0][0];
                for (int elem = 0; elem < d.fullData[0].Count; elem++)
                {
                    Type t = d.fullData[0][elem].GetType();
                    if (!t.Equals(typeof(Double)))
                    {
                        temp.Add(d.fullData[0][elem]);
                        //str += d.fullData[0][elem] + " ";
                    }
                }
                IEnumerable<Object> subsystems = temp.Distinct();
                foreach (var ss in subsystems)
                {
                    str += ss + " \n";
                }
                str += "}\n";
            }

            return str;
        }
        private void Page_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.Delete(number);
        }

        //private void Export_Click(object sender, EventArgs e)
        //{
        //    btm.Save(Text, System.Drawing.Imaging.ImageFormat.Jpeg);
        //}

        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.countOfClustersTB = new System.Windows.Forms.TextBox();
            this.infoOfClustersRTB = new System.Windows.Forms.RichTextBox();
            this.F1Lb = new System.Windows.Forms.Label();
            this.F2Lb = new System.Windows.Forms.Label();
            this.executeBtn = new System.Windows.Forms.Button();
            this.manualCB = new System.Windows.Forms.CheckBox();
            this.Export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(269, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(513, 459);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // countOfClustersTB
            // 
            this.countOfClustersTB.Enabled = false;
            this.countOfClustersTB.Location = new System.Drawing.Point(173, 36);
            this.countOfClustersTB.Name = "countOfClustersTB";
            this.countOfClustersTB.Size = new System.Drawing.Size(36, 26);
            this.countOfClustersTB.TabIndex = 1;
            // 
            // infoOfClustersRTB
            // 
            this.infoOfClustersRTB.Location = new System.Drawing.Point(12, 106);
            this.infoOfClustersRTB.Name = "infoOfClustersRTB";
            this.infoOfClustersRTB.Size = new System.Drawing.Size(149, 190);
            this.infoOfClustersRTB.TabIndex = 2;
            this.infoOfClustersRTB.Text = "";
            // 
            // F1Lb
            // 
            this.F1Lb.AutoSize = true;
            this.F1Lb.Location = new System.Drawing.Point(62, 372);
            this.F1Lb.Name = "F1Lb";
            this.F1Lb.Size = new System.Drawing.Size(14, 20);
            this.F1Lb.TabIndex = 3;
            this.F1Lb.Text = "-";
            // 
            // F2Lb
            // 
            this.F2Lb.AutoSize = true;
            this.F2Lb.Location = new System.Drawing.Point(62, 430);
            this.F2Lb.Name = "F2Lb";
            this.F2Lb.Size = new System.Drawing.Size(14, 20);
            this.F2Lb.TabIndex = 4;
            this.F2Lb.Text = "-";
            // 
            // executeBtn
            // 
            this.executeBtn.Location = new System.Drawing.Point(12, 68);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(91, 33);
            this.executeBtn.TabIndex = 5;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.ExecuteBtn_Click_1);
            // 
            // manualCB
            // 
            this.manualCB.AutoSize = true;
            this.manualCB.Location = new System.Drawing.Point(22, 3);
            this.manualCB.Name = "manualCB";
            this.manualCB.Size = new System.Drawing.Size(139, 24);
            this.manualCB.TabIndex = 6;
            this.manualCB.Text = "Manual setting";
            this.manualCB.UseVisualStyleBackColor = true;
            this.manualCB.CheckedChanged += new System.EventHandler(this.ManualCB_CheckedChanged_1);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(47, 302);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(76, 31);
            this.Export.TabIndex = 7;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Number of clusters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sum of average inner distances";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sum of intercluster distances";
            // 
            // Page
            // 
            this.ClientSize = new System.Drawing.Size(827, 515);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.manualCB);
            this.Controls.Add(this.executeBtn);
            this.Controls.Add(this.F2Lb);
            this.Controls.Add(this.F1Lb);
            this.Controls.Add(this.infoOfClustersRTB);
            this.Controls.Add(this.countOfClustersTB);
            this.Controls.Add(this.pictureBox);
            this.Name = "Page";
            this.Load += new System.EventHandler(this.Page_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Page_Load(object sender, EventArgs e)
        {

        }

        private void ExecuteBtn_Click_1(object sender, EventArgs e)
        {
            int countOfClusters;
            if (Int32.TryParse(countOfClustersTB.Text, out countOfClusters))
            {   if (d.fullData.Count > 1)
                {
                    btm = d.GetPicture(countOfClusters);
                    pictureBox.Image = d.GetPicture(countOfClusters);
                }
                // To enter function
                Double cost = MainWindow.theCost();
                Double dur = MainWindow.theDur();
                d = PostAnalysis(d, cost, dur);
                infoOfClustersRTB.Text = GetInfoOfClusters();
                double F1 = (AnalysisOfClustering.F1(d.fullData, d.clusters));
                double F2 = (AnalysisOfClustering.F4(d.fullData, d.clusters));
                F1Lb.Text = F1.ToString();
                F2Lb.Text = F2.ToString() + "\n" + (F1 / F2).ToString();
            }
            else
                MessageBox.Show("Not digital count of clusters");
        }

        private void ManualCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
                countOfClustersTB.Enabled = true;
            else
            {
                countOfClustersTB.Enabled = false;
                countOfClustersTB.Text = d.AutoCount.ToString();
            }
        }

        public Dendogram DeleteClusters(Dendogram d, List<int> pos)
        {
            Dendogram newD = d;
            foreach (int a in pos)
            {
                newD.DeleteClust(a);
            }
            return newD;
        }

        public Dendogram PostAnalysis(Dendogram den, Double cost, Double duration)
        {
            List<Double> avgCost = new List<Double>();
            List<Double> avgDuration = new List<Double>();

            for (int i = 0; i<den.clusters.Count; i++)
            {
                double sumCost = 0;
                double sumDuration = 0;
                den.clusters[i].Sort();
                // str += "Cluster " + (i + 1) + ":\n{";
                //str += d.clusters[i][0] + ": " + d.fullData[i][0] + " ";
                for (int elem = 0; elem<den.clusters[i].Count; elem++)
                {                
                    double m = 0;                    
                    // str += d.clusters[i][elem] + ": ";
                    for (int k = 0; k<den.fullData[den.clusters[i][elem]].Count; k++)
                    {
                        Type t = den.fullData[den.clusters[i][elem]][k].GetType();
                        if (t.Equals(typeof(Double)))
                        {
                            if (m == 0)
                            {
                                sumCost += den.fullData[den.clusters[i][elem]][k];
                                m = 1;
                            }
                            else
                            {
                                sumDuration += den.fullData[den.clusters[i][elem]][k];
                                m = 0;
                            }
                        }

                    }
                }
                avgCost.Add(Math.Abs((double)(sumCost / den.clusters[i].Count) - cost));
                avgDuration.Add(Math.Abs((double)(sumDuration / den.clusters[i].Count) - duration));
            }
            // Dendogram final;
            List<int> ind = new List<int>();
            List<int> ind1 = new List<int>();
            List<int> ind2 = new List<int>();
            double minCost = avgCost.Min();
            double minDuration = avgDuration.Min();
            for (int m = 0; m<avgCost.Count; m++)
            {
                if (avgCost[m] == minCost)
                    ind1.Add(avgCost.IndexOf(minCost, m));
            }
            for (int l = 0; l<avgDuration.Count; l++)
            {
                if (avgDuration[l] == minDuration)
                    ind2.Add(avgDuration.IndexOf(minDuration, l));
            }
            ind = ind1.Union(ind2).ToList();
            int met = 0;
            List<int> toDelete = new List<int>();
            for (int i = 0; i<den.clusters.Count; i++)
            {
                met = 0;
                for (int j = 0; j<ind.Count; j++)
                {
                    if (i == ind.ElementAt(j))
                    {
                        met = 1;
                    }
                }
                if (met == 0)
                {
                    toDelete.Add(i);
                }
            }
            Dendogram toOutput;
            if (toDelete.Count != 0)
            {
                toOutput = DeleteClusters(den, toDelete);
            }
            else
            {
                toOutput = den;
            }
            return toOutput;
    }

        private void Export_Click_1(object sender, EventArgs e)
        {
            btm.Save(Text, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }

}

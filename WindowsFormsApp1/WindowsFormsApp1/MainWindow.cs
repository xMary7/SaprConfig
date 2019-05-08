using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {
        // private TextBox textBox1 = new TextBox();
        //private TextBox textBox2 = new TextBox();
        //private TextBox refPageTB = new TextBox();
        //private TextBox testedPageTB = new TextBox();
        //private ComboBox comboBox1 = new ComboBox();
        //private ComboBox comboBox2 = new ComboBox();
        //private ComboBox dataTypeCB = new ComboBox();
        //private Label label4 = new Label();
        //private Label accuracyLb = new Label();
        //private Label timeProfit = new Label();
        public MainWindow()
        {
            InitializeComponent();
            Repository.Initialize();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 0)
            {
                comboBox1.SelectedIndex = 4;
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            FileAnalizer fa = new FileAnalizer();
            Algorithms a;
            if (dataTypeCB.Text == "dichotomic")
                a = new AlgorithmForString(fa.GetStringData(textBox1.Text));
            else
                a = new AlgorithmForDouble(fa.GetNumericData(textBox1.Text, comboBox3.Text));
            //if (fa.GetNumericData(textBox1.Text, comboBox3.Text).Count > 1)
            //{
                Repository.AddPicture(a.Algorithm(comboBox2.Text, comboBox1.Text, Int32.Parse(textBox2.Text)), Double.Parse(textBox3.Text), Double.Parse(textBox4.Text));
            //}
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            int refPage, testedPage;
            try
            {
                refPage = Int32.Parse(refPageTB.Text) - 1;
                testedPage = Int32.Parse(testedPageTB.Text) - 1;
                List<List<int>> refClusters = Repository.pictures[refPage].clusters;
                List<List<int>> testedClusters = Repository.pictures[testedPage].clusters;

                int[][] contains = new int[refClusters.Count][];
                bool[] refClusterIsNeededToCheck = new bool[refClusters.Count];
                int error = 0;
                for (int i = 0; i < refClusters.Count; i++)
                {
                    refClusterIsNeededToCheck[i] = true;
                    contains[i] = new int[2];
                }
                foreach (List<int> testedCluster in testedClusters)
                {
                    for (int r = 0; r < refClusters.Count; r++)
                    {
                        if (refClusterIsNeededToCheck[r])
                        {
                            foreach (int elem in testedCluster)
                            {
                                if (refClusters[r].Contains(elem))
                                    contains[r][0]++;
                            }
                            contains[r][1] = testedCluster.Count - contains[r][0];
                        }
                    }
                    int max = Int32.MinValue;
                    int index = 0;
                    for (int ind = 0; ind < refClusterIsNeededToCheck.Length; ind++)
                    {
                        if (refClusterIsNeededToCheck[ind] && contains[ind][0] > max)
                        {
                            max = contains[ind][0];
                            index = ind;
                        }
                    }
                    refClusterIsNeededToCheck[index] = false;
                    error += contains[index][1];
                    for (int i = 0; i < refClusters.Count; i++)
                    {
                        if (refClusterIsNeededToCheck[i])
                            contains[i][0] = 0;// содержаться
                        contains[i][1] = 0; // несодежраться
                    }
                }
                int commonCount = refClusters[0].Count + refClusters[1].Count;
                int per = 100 * (commonCount - error) / commonCount;
                accuracyLb.Text = per.ToString();
                timeProfit.Text = (100 * (Repository.pictures[refPage].time - Repository.pictures[testedPage].time) / Repository.pictures[refPage].time).ToString();
            }
            catch
            {
                MessageBox.Show("EnterPages");
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

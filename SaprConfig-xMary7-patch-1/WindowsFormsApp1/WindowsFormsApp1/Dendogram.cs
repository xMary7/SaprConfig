using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DendogramString : Dendogram
    {
        public DendogramString(List<List<string>> FullData, int ObjectsIndent, int DistanceIndent, int TopIndent, int LeftIndent) : base(ObjectsIndent, DistanceIndent, TopIndent, LeftIndent, FullData.Count, FullData[0].Count)
        {
            fullData = FullData;
        }
    }
    class DendogramDouble : Dendogram
    {
        public DendogramDouble(List<List<Object>> FullData, int ObjectsIndent, int DistanceIndent, int TopIndent, int LeftIndent) : base(ObjectsIndent, DistanceIndent, TopIndent, LeftIndent, FullData.Count, FullData[0].Count)
        {
            fullData = FullData;
        }
    }
    public class Dendogram
    {
        static Pen[] pens = new Pen[3] { new Pen(Color.Black), new Pen(Color.Green), new Pen(Color.Blue) };
        static Brush[] brushs = new Brush[3] { new SolidBrush(Color.Black), new SolidBrush(Color.Green), new SolidBrush(Color.Blue) };
        static Font font = new Font("Arial", 8);
        Graphics gr;
        public Bitmap btm;
        int objectsIndent = 20;
        int distanceIndent = 20;
        int topIndent = 15;
        int leftIndent = 30;
        public long time;
        double prevR = 0;
        double maxGapR;
        double autoBestDivision;
        int maxGapN;
        int autoCount;
        public int AutoCount { get { return autoCount; } }
        public Dictionary<int, Set> set;
        public List<List<int>> clusters;
        public dynamic fullData;
        int pen = 1;
        public Dendogram(int ObjectsIndent, int DistanceIndent, int TopIndent, int LeftIndent, int countData, int countParam)
        {
            objectsIndent = ObjectsIndent;
            distanceIndent = DistanceIndent;
            topIndent = TopIndent;
            leftIndent = LeftIndent;
            set = new Dictionary<int, Set>();
            btm = new Bitmap(countData * distanceIndent + leftIndent + 200, countData * objectsIndent + topIndent + 50);
            maxGapR = Int32.MinValue;
            clusters = new List<List<int>>();

        }
        private int GetGrapthDistance(double r)
        {
            return (int)(r * distanceIndent + leftIndent);
        }
        public void AddUnion(int Number, double R, int[] keys)
        {
            if (prevR != 0 && R - prevR >= maxGapR)
            {
                maxGapR = R - prevR;
                maxGapN = Number;
                autoBestDivision = prevR + maxGapR / 2;
            }
            prevR = R;

            Set s1 = set[keys[0]];
            Set s2 = set[keys[1]];
            set.Add(Number, new Set(Number, R, s1, s2, s1.countOfElem + s2.countOfElem));
        }
        private int ChangePen()
        {
            if (pen == 1)
                return pen++;
            else
                return pen--;
        }
        private float DrawIteration(ref int iteration, Set set, ref int autoCount, int idxPen, int maxGapN, Graphics gr, float midMaxGap)
        {
            int i = 0;
            int idxPen2 = 0;
            if (set.Number < maxGapN && idxPen == 0)
            {
                if (set.Number == maxGapN - 1) midMaxGap = (float)set.r + (midMaxGap - (float)set.r) / 2;
                idxPen2 = ChangePen();
                idxPen = idxPen2;
                autoCount++;
                clusters.Add(new List<int>());
            }
            else
            {
                if (set.Number == maxGapN)
                {
                    midMaxGap = (float)set.r;
                }
                idxPen2 = idxPen;
            }
            foreach (Set s in set.elements.Values)
            {

                if (s.elements == null)//Листдерева
                {
                    s.points[0].X = leftIndent - 3;
                    s.points[0].Y = topIndent + iteration * objectsIndent;
                    s.points[1].X = leftIndent + 3;
                    s.points[1].Y = topIndent + iteration * objectsIndent;
                    gr.DrawLine(pens[0], s.points[0], s.points[1]);
                    if (idxPen2 == 0)
                    {
                        idxPen2 = ChangePen();
                        autoCount++;
                        clusters.Add(new List<int>());
                    }
                    clusters.Last().Add(s.Number);
                    gr.DrawString(s.Number.ToString(), font, brushs[idxPen2], leftIndent - 18, s.points[0].Y - 5);
                    iteration++;
                    if (idxPen == 0) idxPen2 = 0;
                }
                else
                {
                    midMaxGap = DrawIteration(ref iteration, s, ref autoCount, idxPen2, maxGapN, gr, midMaxGap);
                }
                set.points[i].X = GetGrapthDistance(s.r);
                set.points[i++].Y = (s.points[0].Y + s.points[1].Y) / 2;
            }
            gr.DrawLine(pens[idxPen], set.points[0].X, set.points[0].Y, GetGrapthDistance(set.r), set.points[0].Y);
            gr.DrawLine(pens[idxPen], set.points[1].X, set.points[1].Y, GetGrapthDistance(set.r), set.points[1].Y);
            gr.DrawLine(pens[idxPen], GetGrapthDistance(set.r), set.points[0].Y, GetGrapthDistance(set.r), set.points[1].Y);
            return midMaxGap;
        }
        public void DrawDendogram(int gap, Graphics gr)
        {
            autoCount = 0;
            // Координатныелинии
            gr.DrawLine(pens[0], leftIndent, topIndent, btm.Width, topIndent);
            gr.DrawLine(pens[0], leftIndent, topIndent, leftIndent, btm.Height);
            //подпись R
            for (int n = (btm.Width - leftIndent) / distanceIndent, i = 1, r = leftIndent; i < n; i++)
            {
                r += distanceIndent;
                gr.DrawLine(pens[0], r, topIndent - 3, r, topIndent + 3);
                gr.DrawString(i.ToString(), font, brushs[0], r - 4, topIndent - 15);
            }
            int iteration = 1;
            float midMaxGap = 0;
            midMaxGap = DrawIteration(ref iteration, set.Last().Value, ref autoCount, 0, gap, gr, midMaxGap);
            gr.DrawLine(new Pen(Color.Red), midMaxGap * distanceIndent + leftIndent, 0, midMaxGap * distanceIndent + leftIndent, btm.Height);
        }
        public Bitmap GetPicture(int usersCountOfClusters)
        {
            pen = 1;
            clusters.Clear();
            if (gr == null)
            {
                btm = new Bitmap((int)set.Last().Value.r * distanceIndent + 100, btm.Height);
                gr = Graphics.FromImage(btm);
                gr.Clear(Color.White);
                DrawDendogram(maxGapN, gr);
            }
            else
            {
                gr.Clear(Color.White);
                 DrawDendogram(set.ElementAt(0).Key - usersCountOfClusters + 2, gr);
                //DrawDendogram(usersCountOfClusters, gr);
            }
            return btm;
        }
        private double GetR(Set s, int i)
        {

            if (i != 1)
            {
                if (s.elements[0].countOfElem > s.elements[1].countOfElem)
                    return GetR(s.elements[0], --i);
                else
                    return GetR(s.elements[1], --i);
            }
            else
            {
                if (s.elements[0].countOfElem > s.elements[1].countOfElem)
                    return (s.elements[0].r + (s.r - s.elements[0].r) / 2);
                else
                    return (s.elements[1].r + (s.r - s.elements[1].r) / 2);
            }
        }
        public void DeleteClust(int i) 
        {
            //clusters.RemoveAt(i);
            clusters[i].Clear();
           
        }
    }

}

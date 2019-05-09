using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class Repository
    {
        public static int countOfPages;
        public static List<Dendogram> pictures;
        public static List<Page> pages;

        public static void Initialize()
        {
            countOfPages = 0;
            pictures = new List<Dendogram>();
            pages = new List<Page>();
        }

        //public static Dendogram DeleteClusters(Dendogram d, List<int> pos)
        //{
        //    Dendogram newD = d;
        //    foreach (int a in pos)
        //    {
        //        newD.DeleteClust(a);
        //    }
        //    return newD;
        //}

        public static void AddPicture(Dendogram d, Double cost, Double duration)
        {
            countOfPages++;
            if (d.fullData.Count > 1)
            {
                pictures.Add(d);
                Bitmap btm = d.GetPicture(0);
            }
            ////___________________________
            //List<Double> avgCost = new List<Double>();
            //List<Double> avgDuration = new List<Double>();

            //for (int i = 0; i < d.clusters.Count; i++)
            //{
            //    double sumCost = 0;
            //    double sumDuration = 0;
            //    d.clusters[i].Sort();
            //    // str += "Cluster " + (i + 1) + ":\n{";
            //    //str += d.clusters[i][0] + ": " + d.fullData[i][0] + " ";
            //    for (int elem = 0; elem < d.clusters[i].Count; elem++)
            //    {                
            //        double m = 0;                    
            //        // str += d.clusters[i][elem] + ": ";
            //        for (int k = 0; k < d.fullData[elem].Count; k++)
            //        {
            //            Type t = d.fullData[elem][k].GetType();
            //            if (t.Equals(typeof(Double)))
            //            {
            //                if (m == 0)
            //                {
            //                    sumCost += d.fullData[elem][k];
            //                    m = 1;
            //                }
            //                else
            //                {
            //                    sumDuration += d.fullData[elem][k];
            //                    m = 0;
            //                }
            //            }

            //        }
            //    }
            //    avgCost.Add(Math.Abs(sumCost / d.clusters[i].Count - cost));
            //    avgDuration.Add(Math.Abs(sumDuration / d.clusters[i].Count - duration));
            //}
            //// Dendogram final;
            //List<int> ind = new List<int>();
            //List<int> ind1 = new List<int>();
            //List<int> ind2 = new List<int>();
            //double minCost = avgCost.Min();
            //double minDuration = avgDuration.Min();
            //for (int m = 0; m < avgCost.Count; m++)
            //{
            //    if (avgCost[m] == minCost)
            //        ind1.Add(avgCost.IndexOf(minCost, m));
            //}
            //for (int l = 0; l < avgDuration.Count; l++)
            //{
            //    if (avgDuration[l] == minDuration)
            //        ind2.Add(avgDuration.IndexOf(minDuration, l));
            //}
            //ind = ind1.Union(ind2).ToList();
            //int met = 0;
            //List<int> toDelete = new List<int>();
            //for (int i = 0; i < d.clusters.Count; i++)
            //{
            //    met = 0;
            //    for (int j = 0; j < ind.Count; j++)
            //    {
            //        if (i == ind.ElementAt(j))
            //        {
            //            met = 1;
            //        }
            //    }
            //    if (met == 0)
            //    {
            //        toDelete.Add(i);
            //    }
            //}
            //Dendogram toOutput;
            //if (toDelete.Count != 0)
            //{
            //    toOutput = DeleteClusters(d, toDelete);
            //}
            //else
            //{
            //    toOutput = d;
            //}
            ////___________________________
            //Page page = new Page(countOfPages, toOutput, cost, duration);
            Page page = new Page(countOfPages, d, cost, duration);
            pages.Add(page);
            page.Show();

        }
        public static void Delete(int number)
        {
            pictures.RemoveAt(number - 1);
            pages.RemoveAt(number - 1);
            countOfPages--;
            for (int i = 1; i <= countOfPages; i++)
            {
                pages[i - 1].ChangeNumber(i);
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class AnalysisOfClustering
    {
        static private int RD(List<string> obj1, List<string> obj2)
        {
            int d = 0;
            for (int i = 0; i < obj1.Count; i++)
            {
                if (obj1[i] != obj2[i])
                    d++;
            }
            return d;
        }
        static private double RN(List<Object> obj1, List<Object> obj2)
        {
            double distance = 0;
            for (int k = 0; k < obj1.Count; k++)
            {
                Type t1 = obj1[k].GetType();
                Type t2 = obj2[k].GetType();
                if (t1.Equals(typeof(Double)))
                {
                    distance += Math.Abs(Convert.ToDouble(obj1[k]) - Convert.ToDouble(obj2[k]));
                }
            }
            return Math.Sqrt(distance);
        }
        static private List<List<string>> GetCentrOfClusterD(List<List<string>> data, List<List<int>> clusters)
        {
            List<List<string>> middleOfCluster = new List<List<string>>();
            for (int c = 0; c < clusters.Count; c++)
            {
                middleOfCluster.Add(new List<string>());
                //покаждомусвойству
                for (int property = 0; property < data[0].Count; property++)
                {
                    Dictionary<string, int> dic = new Dictionary<string, int>();
                    foreach (int elem in clusters[c])
                    {
                        if (!dic.ContainsKey(data[elem][property]))
                        {
                            dic.Add(data[elem][property], 1);
                        }
                        else
                            dic[data[elem][property]]++;
                    }
                    middleOfCluster[c].Add(dic.OrderByDescending(x => x.Value).FirstOrDefault().Key);
                }
            }
            return middleOfCluster;
        }
        static private List<List<Object>> GetCentrOfClusterN(List<List<Object>> data, List<List<int>> clusters)
        {
            List<List<Object>> middleOfCluster = new List<List<Object>>();
            for (int cluster = 0; cluster < clusters.Count; cluster++)
            {
                middleOfCluster.Add(new List<Object>());

                //покаждомусвойству
                for (int property = 0; property < data[0].Count; property++)
                {
                    double res = 0;
                    foreach (int elem in clusters[cluster])
                    {
                        Type t = data[elem][property].GetType();
                        if (t.Equals(typeof(Double)))
                        {
                            res += Convert.ToDouble(data[elem][property]);
                        }
                    }
                    
                    middleOfCluster[cluster].Add(res / clusters[cluster].Count);

                }
            }
            return middleOfCluster;
        }
        //сумма внутрикластерных отклонений от центров кластеров
        static public int F1(List<List<string>> data, List<List<int>> clusters)
        {

            int res = 0;
            List<List<string>> middleOfCluster = GetCentrOfClusterD(data, clusters);

            for (int c = 0; c < clusters.Count; c++)
            {
                foreach (int elem in clusters[c])
                {
                    int d = RD(data[elem], middleOfCluster[c]);
                    res += d * d;
                }
            }

            return res;
        }
        static public float F4(List<List<string>> data, List<List<int>> clusters)
        {
            int res = 0;
            List<List<string>> middleOfCluster = GetCentrOfClusterD(data, clusters);
            for (int c1 = 0; c1 < clusters.Count; c1++)
            {
                for (int c2 = c1 + 1; c2 < clusters.Count; c2++)
                {
                    int d = RD(middleOfCluster[c1], middleOfCluster[c2]);
                    res += d;
                }
            }
            return res;
        }
        static public float F1(List<List<Object>> data, List<List<int>> clusters)
        {
            double res = 0;
            List<List<Object>> middleOfCluster = GetCentrOfClusterN(data, clusters);

            for (int c = 0; c < clusters.Count; c++)
            {
                double sumOfCl = 0;
                foreach (int elem in clusters[c])
                {
                    
                    double d = RN(data[elem], middleOfCluster[c]);
                    sumOfCl += d * d;
                }
                res += sumOfCl / clusters[c].Count;
            }
            return (float)res;
        }
        static public float F4(List<List<Object>> data, List<List<int>> clusters)
        {
            double res = 0;
            List<List<object>> middleOfCluster = GetCentrOfClusterN(data, clusters);
            List<List<int>> common = new List<List<int>>();
            List<int> l = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                l.Add(i);
            }
            common.Add(l);
            List<List<Object>> middle = GetCentrOfClusterN(data, common);
            for (int c1 = 0; c1 < clusters.Count; c1++)
            {
                
                double d = RN(middleOfCluster[c1], middle[0]);
                res += d * d;

            }
            return (float)res;
        }
    }
}

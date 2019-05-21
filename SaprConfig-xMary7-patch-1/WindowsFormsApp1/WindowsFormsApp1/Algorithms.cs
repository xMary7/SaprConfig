﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AlgorithmForString : Algorithms
    {
        // protected List<List<string>> fullData;
        public AlgorithmForString(List<List<string>> data) : base()
        {
            type = "string";
            fullData = data;
        }
        public override double FindSimpleDistance(int index1, int index2)
        {
            List<string> obj1 = fullData[index1];
            List<string> obj2 = fullData[index2];
            int distance = 0;
            for (int k = 0; k < fullData[0].Count; k++)
                if (obj1[k] != obj2[k])
                    distance++;
            return distance;
        }
    }
    public class AlgorithmForDouble : Algorithms
    {
        public AlgorithmForDouble(List<List<Object>> data) : base()
        {
            fullData = data;
            type = "double";
        }
        public override double FindSimpleDistance(int index1, int index2)
        {
            List<Object> obj1 = fullData[index1];
            List<Object> obj2 = fullData[index2];
            double distance = 0;
            for (int k = 0; k < fullData[0].Count; k++)
            {
                Type t1 = obj1[k].GetType();
                Type t2 = obj2[k].GetType();
                if (t1.Equals(typeof(Double)) && t2.Equals(typeof(Double)))
                {
                    distance += Math.Pow(Math.Abs(Convert.ToDouble(obj1[k]) - Convert.ToDouble(obj2[k])), 2);
                }
            }
            return Math.Sqrt(distance);
        }
    }
    public class Algorithms
    {
        #region parametrs
        Dictionary<Tuple<int, int>, double> R;//= new SortedDictionary<Tuple<int, int>, double>();
        double b, g;
        double[] a;
        int n1 = 4;
        bool yorchil = false;
        protected dynamic fullData;
        protected string type;
        #endregion
        public Algorithms()
        {
            R = new Dictionary<Tuple<int, int>, double>();
            a = new double[2];
        }
        public virtual double FindSimpleDistance(int i, int j) { return 0; }
        private void InitSet(ref string log, Dictionary<int, Set> set)
        {
            //Вывод множеств и прорисовка вертикальных линий
            log += "C0={ ";
            for (int i = 0; i < fullData.Count; i++)
            {
                if (i != 0)
                {
                    log += "; ";
                }
                set.Add(i, new Set(i, 0, null, null, 1));
                log += i;
            }
            //Выводколичествамножеств
            log += "}" + "\r\n Count = " + set.Count + "\r\n";
        }
        private void OutputSets(ref string log, Dictionary<int, Set> set)
        {
            // выводмножеств
            log += "C" + (fullData.Count - set.Count).ToString() + "{";
            for (int i = 0; i < set.Count; i++)
            {
                if (i != 0) log += ";";
                log += " " + set.ElementAt(i).Key.ToString() + ":[";
                foreach (Set elem in set.Values)
                {
                    log += elem.Number + ", ";
                }
                log = log.Remove(log.Length - 2, 2);
                log += "]";
            }
            log += "} \r\n Count = " + set.Count + "\r\n";
        }
        private void CorrectDistances(Dictionary<int, Set> set, int[] key, int n, Dictionary<int, Set> s, Dictionary<int, Set> s1, Dictionary<Tuple<int, int>, double> P, double delta)
        {
            double[] r = new double[3];
            double d;
            // добавить расстояния от нового кластера до всех других кроме v1 и v2, т к они входят в состав объединенного
            foreach (int i in set.Keys)//= 0; i < set.Count; i++)
            {
                if (i != key[0] && i != key[1] && i != n)
                {
                    if (yorchil)//расстояниеуоршила
                    {
                        int icount = set[i].countOfElem;
                        a[0] = (double)(set[key[0]].countOfElem + icount) / (set[n].countOfElem + icount);
                        a[1] = (double)(set[key[1]].countOfElem + icount) / (set[n].countOfElem + icount);
                        b = (double)-icount / (set[n].countOfElem + icount);
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        r[j] = R[new Tuple<int, int>(Math.Min(i, key[j]), Math.Max(i, key[j]))];
                        R.Remove(new Tuple<int, int>(Math.Min(i, key[j]), Math.Max(i, key[j])));   //удалилирасстояниягдеестьобъединенныемножества
                    }
                    r[2] = R[new Tuple<int, int>(key[0], key[1])];
                    //посчиталирасстояние
                    d = a[0] * r[0] + a[1] * r[1] + b * r[2] + g * Math.Abs(r[0] - r[1]);
                    R.Add(new Tuple<int, int>(i, n), d);
                    if (s != null && d < delta && s.Keys.Contains(i))
                    {
                        s1.Add(i, s[i]);
                        P.Add(new Tuple<int, int>(i, n), d);
                        s.Remove(i);
                    }
                }
            }
        }
        public Dendogram Algorithm(string nameOfDistanceFunc, string nameOfFunction, int n)
        {
            n1 = n;
            if (nameOfDistanceFunc == "Уорда")
                yorchil = true;
            //Подготовили файл для записи
            File.Create("log1.txt").Close();
            //Имя расстояния добавили на вывод в файл
            string log = nameOfDistanceFunc + "\r\n";
            // определиликонстанты
            if (yorchil == false && nameOfDistanceFunc == "ближайшего соседа" || nameOfDistanceFunc == "дальнего соседа")
            {
                a[0] = a[1] = 0.5;
                switch (nameOfDistanceFunc)
                {
                    case "ближайшего соседа": g = -0.5; break;
                    case "дальнего соседа": g = 0.5; break;
                }
            }
            //Вызовфункции
            if (nameOfFunction == "Lance-Wiliams")
                return Lance_Wiliams(nameOfDistanceFunc, ref log);
            else
                return Fast_Lance_Wiliams(nameOfDistanceFunc, ref log);
        }

        //public Dendogram DeleteClusters(Dendogram d, List<int> pos)
        //{
        //    Dendogram newD = d;
        //    foreach (int a in pos)
        //    {
        //        newD.DeleteClust(a);
        //    }
        //    return newD;
        //}

        //public Dendogram Algorithm(string nameOfDistanceFunc, string nameOfFunction, int n, Double cost, Double duration)
        //{
        //    Dendogram toOutput = AlgorithmClustering(nameOfDistanceFunc, nameOfFunction, n);

        //    List<Double> avgCost = new List<Double>();
        //    List<Double> avgDuration = new List<Double>();

        //    for (int i = 0; i < toOutput.clusters.Count; i++)
        //    {
        //        toOutput.clusters[i].Sort();
        //        // str += "Cluster " + (i + 1) + ":\n{";
        //        //str += d.clusters[i][0] + ": " + d.fullData[i][0] + " ";
        //        for (int elem = 0; elem < toOutput.clusters[i].Count; elem++)
        //        {
        //            double sumCost = 0;
        //            double m = 0;
        //            double sumDuration = 0;
        //            // str += d.clusters[i][elem] + ": ";
        //            for (int k = 0; k < toOutput.fullData[elem].Count; k++)
        //            {
        //                Type t = toOutput.fullData[elem][k].GetType();
        //                if (t.Equals(typeof(Double)))
        //                {
        //                    if (m == 0)
        //                    {
        //                        sumCost += toOutput.fullData[elem][k];
        //                        m = 1;
        //                    }
        //                    else
        //                    {
        //                        sumDuration += toOutput.fullData[elem][k];
        //                        m = 0;
        //                    }
        //                }
        //                avgCost.Add(Math.Abs(sumCost / toOutput.clusters[i].Count - cost));
        //                avgDuration.Add(Math.Abs(sumDuration / toOutput.clusters[i].Count - duration));
        //            }

        //        }
        //    }
        //    // Dendogram final;
        //    List<int> ind = new List<int>();
        //    List<int> ind1 = new List<int>();
        //    List<int> ind2 = new List<int>();
        //    double minCost = avgCost.Min();
        //    double minDuration = avgDuration.Min();
        //    for(int m = 0; m < avgCost.Count; m++)
        //    {
        //        if (avgCost[m] == minCost)
        //            ind1.Add(avgCost.IndexOf(minCost, m));
        //    }
        //    for (int l = 0; l < avgDuration.Count; l++)
        //    {
        //        if (avgDuration[l] == minDuration)
        //            ind2.Add(avgCost.IndexOf(minDuration, l));
        //    }
        //    ind = ind1.Union(ind2).ToList();

            //ind.Add(avgCost.IndexOf(avgCost.Min()));
            //if (avgCost.IndexOf(avgCost.Min()) != avgDuration.IndexOf(avgDuration.Min()))
            //{
            //    ind.Add(avgDuration.IndexOf(avgDuration.Min()));
            //}                           
        //    return DeleteClusters(toOutput, ind);
        //}


        private void GetRandomObjects(int n1, Dictionary<int, Set> set1, Dictionary<int, Set> set)
        {
            List<int> randomList = new List<int>();
            Random a = new Random();
            int index;
            int countOfData = set1.Count;
            for (int j = countOfData; set1.Count > 0 && countOfData - j < n1; j--)
            {
                index = a.Next(0, j);
                Set elem = set1.ElementAt(index).Value;
                set.Add(set1.ElementAt(index).Key, elem);
                set1.Remove(set1.ElementAt(index).Key);
            }
        }
        public Dendogram Lance_Wiliams(string nameOfDistanceFunc, ref string log)
        {
            var myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            Dendogram dendogram;
            if (type == "string")
                dendogram = new DendogramString(fullData, 20, 20, 15, 30);
            else
                dendogram = new DendogramDouble(fullData, 20, 20, 15, 30);
            //инициализация set
            InitSet(ref log, dendogram.set);
            if (fullData.Count > 1)
            {
                // Определили расстояния между заданными векторами
                for (int i = 0; i < fullData.Count; i++)
                {
                    for (int j = i + 1; j < fullData.Count; j++)
                    {
                        R.Add(new Tuple<int, int>(i, j), FindSimpleDistance(i, j));
                    }
                }
                // АЛГОРИТМ
                for (int n = dendogram.set.Count; dendogram.set.Count != 1; n++)
                {
                    int[] key = new int[2]; //множества для объединения
                                            // сортировка массива расстояний
                    R = R.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                    Tuple<int, int> min = R.ElementAt(0).Key;
                    log += "\r\nМинимальное расстояние: " + R[min].ToString() + "\r\n";
                    key[0] = min.Item1;
                    key[1] = min.Item2;
                    //Объединилимножества
                    // dendogram.set.Add(n, new List<int>(set[key[0]].Concat(set[key[1]]).ToList()));
                    dendogram.AddUnion(n, R.ElementAt(0).Value, key);
                    // Определиликонстанты
                    if (nameOfDistanceFunc == "среднее расстояние" || nameOfDistanceFunc == "расстояние между центрами")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            a[i] = (double)dendogram.set[key[i]].countOfElem / dendogram.set[n].countOfElem;
                        }
                        if (nameOfDistanceFunc == "расстояние между центрами")
                        {
                            // case "group average distance": b = 0; g = 0; break;
                            b = -a[0] * a[1];
                        }
                    }
                    CorrectDistances(dendogram.set, key, n, null, null, null, 0);
                    //удалилисаморасстояниеимножества
                    R.Remove(new Tuple<int, int>(Math.Min(key[0], key[1]), Math.Max(key[0], key[1])));
                    dendogram.set.Remove(key[0]);
                    dendogram.set.Remove(key[1]);
                    OutputSets(ref log, dendogram.set);
                    // добавлениестрокивфайл
                    File.AppendAllText("log1.txt", log);
                    log = "";
                }
            }
            myStopwatch.Stop();
            dendogram.time = myStopwatch.ElapsedMilliseconds;
            return dendogram;
        }
        public Dendogram Fast_Lance_Wiliams(string nameOfDistanceFunc, ref string log)
        {
            var myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            double delta = 0;
            bool needToChangeDelta = true;
            Dendogram dendogram;
            if (type == "string")
                dendogram = new DendogramString(fullData, 20, 20, 15, 30);
            else
                dendogram = new DendogramDouble(fullData, 20, 20, 15, 30);
            //инициализация set
            InitSet(ref log, dendogram.set);
            if (fullData.Count > 1)
            {
                // Определили расстояния между заданными векторами
                for (int i = 0; i < fullData.Count; i++)
                {
                    for (int j = i + 1; j < fullData.Count; j++)
                    {
                        R.Add(new Tuple<int, int>(i, j), FindSimpleDistance(i, j));
                    }
                }
                //выбрали n рандомом
                Dictionary<Tuple<int, int>, double> P = new Dictionary<Tuple<int, int>, double>();
                // List <ref obj> P = List
                if (n1 < R.Count)
                    GetRandom(P, n1);
                else
                    foreach (Tuple<int, int> k in R.Keys)
                        P.Add(k, R[k]);
                // АЛГОРИТМ
                for (int n = dendogram.set.Count; dendogram.set.Count != 1; n++)
                {
                    if (P.Count == 0)
                    {
                        needToChangeDelta = true;
                        if (R.Count <= n1)
                        {
                            foreach (Tuple<int, int> k in R.Keys)
                                P.Add(k, R[k]);
                        }
                        else
                            GetRandom(P, n1);
                    }
                    int[] key = new int[2]; //множества для объединения
                                            // сортировка массива расстояний
                                            // P = P.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                    double minVal = Int32.MaxValue;
                    Tuple<int, int> min = null;
                    foreach (Tuple<int, int> k in P.Keys)
                    {
                        if (P[k] < minVal)
                        {
                            minVal = P[k];
                            min = k;
                        }
                    }
                    //  Tuple<int, int> min = P.ElementAt(0).Key;
                    if (needToChangeDelta)
                    {
                        delta = P.ElementAt(0).Value;
                        needToChangeDelta = false;
                    }
                    log += "\r\nМинимальноерасстояние: " + R[min].ToString() + "\r\n";
                    key[0] = min.Item1;
                    key[1] = min.Item2;
                    //Объединилимножества
                    dendogram.AddUnion(n, P[min], key);
                    // Определиликонстанты
                    if (nameOfDistanceFunc == "среднее расстояние" || nameOfDistanceFunc == "расстояние между центрами")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            a[i] = (double)dendogram.set[key[i]].countOfElem / dendogram.set[n].countOfElem;
                        }
                        if (nameOfDistanceFunc == "расстояние между центрами")
                        {
                            // case "group average distance": b = 0; g = 0; break;
                            b = -a[0] * a[1];
                        }
                    }
                    CorrectDistances1(dendogram.set, key, n, P, delta);
                    //удалилисаморасстояниеимножества
                    R.Remove(new Tuple<int, int>(Math.Min(key[0], key[1]), Math.Max(key[0], key[1])));
                    P.Remove(new Tuple<int, int>(Math.Min(key[0], key[1]), Math.Max(key[0], key[1])));
                    dendogram.set.Remove(key[0]);
                    dendogram.set.Remove(key[1]);
                    OutputSets(ref log, dendogram.set);
                    // добавлениестрокивфайл
                    File.AppendAllText("log1.txt", log);
                    log = "";
                }
            }
            myStopwatch.Stop();
            dendogram.time = myStopwatch.ElapsedMilliseconds;
            return dendogram;
        }
        private void GetRandom(Dictionary<Tuple<int, int>, double> P, int n1)
        {
            Random rand = new Random();
            for (int i = 0; i < n1; i++)
            {
                int idx;
                do
                { idx = rand.Next(0, R.Count); }
                while (P.ContainsKey(R.ElementAt(idx).Key));
                P.Add(R.ElementAt(idx).Key, R.ElementAt(idx).Value);
            }
        }
        private void CorrectDistances1(Dictionary<int, Set> set, int[] key, int n, Dictionary<Tuple<int, int>, double> P, double delta)
        {
            double[] r = new double[3];
            double d;
            // добавить расстояния от нового кластера до всех других кроме v1 и v2, т к они входят в состав объединенного
            foreach (int i in set.Keys)//= 0; i < set.Count; i++)
            {
                if (i != key[0] && i != key[1] && i != n)
                {
                    if (yorchil)//расстояниеуоршила
                    {
                        int icount = set[i].countOfElem;
                        a[0] = (double)(set[key[0]].countOfElem + icount) / (set[n].countOfElem + icount);
                        a[1] = (double)(set[key[1]].countOfElem + icount) / (set[n].countOfElem + icount);
                        b = (double)-icount / (set[n].countOfElem + icount);
                        //g = 0; 
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        Tuple<int, int> t = new Tuple<int, int>(Math.Min(i, key[j]), Math.Max(i, key[j]));
                        r[j] = R[t];
                        R.Remove(t);   //удалили расстояния где есть объединенные множества
                        if (P.ContainsKey(t))
                            P.Remove(new Tuple<int, int>(Math.Min(i, key[j]), Math.Max(i, key[j])));
                    }
                    r[2] = R[new Tuple<int, int>(key[0], key[1])];
                    //посчиталирасстояние
                    d = a[0] * r[0] + a[1] * r[1] + b * r[2] + g * Math.Abs(r[0] - r[1]);
                    R.Add(new Tuple<int, int>(i, n), d);
                    if (d <= delta)
                    {
                        P.Add(new Tuple<int, int>(i, n), d);
                    }
                }
            }
        }
    }

}
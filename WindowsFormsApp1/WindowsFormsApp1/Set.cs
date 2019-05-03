using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Set
    {
        int number;
        public int countOfElem;
        public Dictionary<int, Set> elements;
        public Point[] points;
        public int Number
        {
            get { return number; }
        }
        public double r;
        public Set(int Number, double R, Set s1, Set s2, int count)
        {
            countOfElem = count;
            number = Number;
            r = R;
            points = new Point[2];
            if (s1 != null)
            {
                elements = new Dictionary<int, Set>();
                elements.Add(s1.Number, s1);
                elements.Add(s2.Number, s2);
            }
        }
    }

}

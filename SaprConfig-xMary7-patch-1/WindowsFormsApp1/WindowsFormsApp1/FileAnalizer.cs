using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class FileAnalizer
    {
        public List<List<Object>> GetNumericData(string fileName, string ind)
        {
            List<List<Object>> data = new List<List<Object>>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string str = sr.ReadLine();
                while (str != null)
                {
                    Regex numbersReg = new Regex(@"[a-z]");
                    Regex myReg = new Regex(ind);
                    if (myReg.IsMatch(str))
                    {
                        List<Object> newObject = new List<Object>();
                        foreach (string s in str.Split(' ').ToList())
                        {
                            //if ((s != "") && (!myReg.IsMatch(s))) newObject.Add(Double.Parse(s));
                            if ((s != "") && (!numbersReg.IsMatch(s)))
                                newObject.Add(Double.Parse(s));
                            else if (numbersReg.IsMatch(s))
                            {   if (!myReg.IsMatch(s))
                                {
                                    newObject.Add(s);
                                }
                            }
                        }

                        data.Add(newObject);
                    }
                    str = sr.ReadLine();
                }

            }
            return data;
        }
        public List<List<string>> GetStringData(string fileName)
        {
            List<List<string>> data = new List<List<string>>();
            List<string> nameOfProperties = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = "";
                line = RewindToSign(sr, "", '{');
                while (line != "-")// not end of file
                {
                    List<string> newObject = new List<string>();
                    while (!IsTheEndOfObject(sr, ref line))
                    {
                        line = RewindToSign(sr, line, '"');
                        string property = ReadString(ref line);
                        line = RewindToSign(sr, line, '"');
                        string value = ReadString(ref line);
                        if (!nameOfProperties.Exists(x => x == property))
                        {
                            nameOfProperties.Add(property);
                        }


                        newObject.Insert(nameOfProperties.FindIndex(x => x == property), value);
                    }
                    data.Add(newObject);
                    line = RewindToSign(sr, line, '{');
                }
            }
            return data;
        }
        private bool IsTheEndOfObject(StreamReader sr, ref string line)
        {
            while (line.Length == 0)
                line = sr.ReadLine();
            while (line[0] != '}' && line[0] != '"')
            {
                line = line.Remove(0, 1);
                while (line.Length == 0)
                    line = sr.ReadLine();
            }
            if (line[0] == '}')
                return true;
            else
                return false;
        }
        private string ReadString(ref string line)
        {
            int ind = line.IndexOf('"');
            string res = line.Substring(0, ind);
            line = line.Remove(0, ind + 1);
            return res;
        }
        private string RewindToSign(StreamReader sr, string line, char sign)
        {
            int signPos = -1;
            while (signPos == -1) // sign not found
            {
                while (line == "\n" || line == "")
                {

                    if (sr.Peek() != -1)
                        line = sr.ReadLine();
                    else return "-";// file ended
                }

                signPos = line.IndexOf(sign);
                if (signPos != -1)
                    line = line.Remove(0, signPos + 1);
                else
                    line = "";
            }

            return line;
        }
    }

}

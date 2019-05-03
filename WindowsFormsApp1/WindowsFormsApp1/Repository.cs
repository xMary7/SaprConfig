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
        public static void AddPicture(Dendogram d)
        {
            countOfPages++;
            pictures.Add(d);
            Bitmap btm = d.GetPicture(0);
            Page page = new Page(countOfPages, d);
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

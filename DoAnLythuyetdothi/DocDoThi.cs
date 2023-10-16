using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi
{
    public class DocDoThi
    {
        public static int XacDinhDoThi()
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothiCau1.txt");
            int n = int.Parse(fileDoc.ReadLine());
            fileDoc.Close();
            return n;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau_4
{
    public class XuLy
    {
        public void InMang(int[] mang)
        {
            foreach (int i in mang)
            {
                Console.Write($"{i}, ");
            }
            Console.Write("\n");
        }
        public bool PhanTuCoTrongMang(int phanTu, int[] mang)
        {
            if (mang.Contains(phanTu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[] XoaPhanTuTrongMang(int phanTuXoa, int[] mang)
        {
            return mang.Except(new int[] { phanTuXoa }).ToArray();
        }
    }
}

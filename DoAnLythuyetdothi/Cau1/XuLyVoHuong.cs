using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau1
{
    public class XuLyVoHuong
    {
        public static int TimSoDiem()
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothiCau1.txt");
            int n = int.Parse(fileDoc.ReadLine());
            string[] SoDiem = fileDoc.ReadLine().Split(' ');
            return SoDiem.Length;
        }
        public static int TimSoCanh(int SoDiem)
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothiCau1.txt");
            int n = int.Parse(fileDoc.ReadLine());
            int[] CacDinh = new int[SoDiem * SoDiem];
            int CacDinhIndex = 0;
            for (int i = 0; i < SoDiem; i++)
            {
                string[] MangKyTu = fileDoc.ReadLine().Split(' ');
                for (int j = 0; j < MangKyTu.Length; j++)
                {
                    CacDinh[CacDinhIndex] = int.Parse(MangKyTu[j]);
                    CacDinhIndex++;
                }
            }
            int DemCanh = 0;
            for (int k = 0; k < CacDinh.Length; k++)
            {
                if (CacDinh[k] != 0)
                {
                    DemCanh += CacDinh[k];
                }
            }


            return DemCanh;
        }
        public static int TimSoCanhKhuyen(int[,] MaTran)
        {
            int SoCanhKhuyen = 0;
            for (int i = 0; i < MaTran.GetLength(0); i++)
            {
                for (int j = 0; j < MaTran.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (MaTran[i, j] == 1)
                        {
                            SoCanhKhuyen++;
                        }
                    }
                }
            }
            return SoCanhKhuyen;

        }
        public static int TimCanhBoi(int[,] MaTran)
        {
            int SocanhBoi = 0;
            for (int i = 0; i < MaTran.GetLength(0); i++)
            {
                for (int j = 0; j < MaTran.GetLength(1); j++)
                {
                    if (MaTran[i, j] == 2 && MaTran[i, j] == MaTran[j, i])
                    {
                        SocanhBoi++;
                    }
                }
            }
            return SocanhBoi;
        }
        public static int[,] DocMaTran(int SoDiem)
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothiCau1.txt");
            int n = int.Parse(fileDoc.ReadLine());
            int[] CacDinh = new int[SoDiem * SoDiem];
            int CacDinhIndex = 0;
            for (int i = 0; i < SoDiem; i++)
            {

                string[] MangKyTu = fileDoc.ReadLine().Split(' ');
                for (int j = 0; j < MangKyTu.Length; j++)
                {
                    CacDinh[CacDinhIndex] = int.Parse(MangKyTu[j]);
                    CacDinhIndex++;
                }

            }
            CacDinhIndex = 0;
            int[,] MaTran = new int[SoDiem, SoDiem];
            for (int i = 0; i < SoDiem; i++)
            {
                for (int j = 0; j < SoDiem; j++)
                {
                    MaTran[i, j] = CacDinh[CacDinhIndex];
                    CacDinhIndex++;
                }
            }
            return MaTran;
        }
        public static int[] ChuoiBacVoHuong(int[,] MaTran)
        {
            for (int i = 0; i < MaTran.GetLength(0); i++)
            {
                for (int j = 0; j < MaTran.GetLength(1); j++)
                {
                    if (i == j && MaTran[i, j] != 0)
                    {
                        MaTran[i, j]++;
                    }
                }
            }
            int[] ChuoiBacVoHuong = new int[MaTran.GetLength(0)];
            for (int m = 0; m < ChuoiBacVoHuong.Length; m++)
            {

                for (int i = 0; i < MaTran.GetLength(0); i++)
                {
                    ChuoiBacVoHuong[m] += MaTran[m, i];
                }
            }
            return ChuoiBacVoHuong;
        }
        public static void XuatMaTran(int[,] Matran)
        {
            for (int i = 0; i < Matran.GetLength(0); i++)
            {
                for (int j = 0; j < Matran.GetLength(1); j++)
                {
                    Console.Write($"{Matran[i, j]}" + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

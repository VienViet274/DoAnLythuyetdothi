using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnLythuyetdothi.Entities;

namespace DoAnLythuyetdothi.Cau1
{
    public class XuLyCoHuong
    {
        public static int TimSoDiem()
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothi.txt");
            int n = int.Parse(fileDoc.ReadLine());
            string[] SoDiem = fileDoc.ReadLine().Split(' ');
            return SoDiem.Length;
        }
        public static int TimSoCanh(int SoDiem)
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothi.txt");
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
                    if (MaTran[i, j] == 2)
                    {
                        SocanhBoi++;
                    }
                }
            }
            return SocanhBoi;
        }
        public static int[,] DocMaTran(int SoDiem)
        {
            StreamReader fileDoc = new StreamReader("D:\\File C#\\fileLyThuyetdothi.txt");
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
        public static int[] ChuoiBacVaoBacRa(out BacCoHuong[] ChuoiBac, int[,] MaTran)
        {
            ChuoiBac = new BacCoHuong[MaTran.GetLength(0)];
            int[] TongBac = new int[MaTran.GetLength(0)];
            for (int m = 0; m < ChuoiBac.Length; m++)
            {
                for (int j = 0; j < MaTran.GetLength(1); j++)
                {
                    if (MaTran[m, j] != 0)
                        ChuoiBac[m].BacVao += MaTran[m, j];
                }
                for (int i = 0; i < MaTran.GetLength(0); i++)
                {
                    if (MaTran[i, m] != 0)
                    {
                        ChuoiBac[m].BacRa += MaTran[i, m];
                    }

                }
            }
            for (int i = 0; i < TongBac.Length; i++)
            {
                TongBac[i] = ChuoiBac[i].BacVao + ChuoiBac[i].BacRa;
            }

            return TongBac;
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

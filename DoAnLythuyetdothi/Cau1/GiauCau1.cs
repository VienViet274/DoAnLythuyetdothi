using DoAnLythuyetdothi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau1
{
	public class GiauCau1
	{
		public static void SolveDoThiVoHuong()
		{
			Console.WriteLine("Do Thi Vo Huong");
			int SoDiem = 0;
			SoDiem = XuLyVoHuong.TimSoDiem();

			int[,] Matran = XuLyVoHuong.DocMaTran(SoDiem);
			XuLyVoHuong.XuatMaTran(Matran);
			Console.WriteLine($"Do thi co {SoDiem} dinh");
			int SoCanh = XuLyVoHuong.TimSoCanh(SoDiem);
			Console.WriteLine($"Do thi co {SoCanh} canh");
			int SoCanhBoi = XuLyVoHuong.TimCanhBoi(Matran);
			Console.WriteLine($"So canh boi: {SoCanhBoi}");
			int SoCanhKhuyen = XuLyVoHuong.TimSoCanhKhuyen(Matran);
			Console.WriteLine($"So canh khuyen la:{SoCanhKhuyen}");


			int[] ChuoibacVohuong = XuLyVoHuong.ChuoiBacVoHuong(Matran);
			int SoDinhTreo = 0;
			int SoDinhCoLap = 0;
			for (int i = 0; i < ChuoibacVohuong.Length; i++)
			{
				if (ChuoibacVohuong[i] == 0)
				{
					SoDinhCoLap++;
				}
				else if (ChuoibacVohuong[i] == 1)
				{
					SoDinhTreo++;
				}
			}
			Console.WriteLine($"Do thi co {SoDinhTreo} dinh treo");
			Console.WriteLine($"Do thi co {SoDinhCoLap} dinh co lap");
			Console.WriteLine("Bac ra - Bac vao cua tung dinh");
			for (int i = 0; i < ChuoibacVohuong.Length; i++)
			{
				Console.WriteLine($"{i}({ChuoibacVohuong[i]})");
			}
		}
		public static void SolveDoThiCoHuong()
		{
			Console.WriteLine("Do Thi Co Huong");
			int SoDiem = 0;
			SoDiem = XuLyCoHuong.TimSoDiem();

			int[,] Matran = XuLyCoHuong.DocMaTran(SoDiem);
			XuLyCoHuong.XuatMaTran(Matran);
			Console.WriteLine($"Do thi co {SoDiem} dinh");
			int SoCanh = XuLyCoHuong.TimSoCanh(SoDiem);
			Console.WriteLine($"Do thi co {SoCanh} canh");
			int SoCanhBoi = XuLyCoHuong.TimCanhBoi(Matran);
			Console.WriteLine($"So canh boi: {SoCanhBoi}");
			int SoCanhKhuyen = XuLyCoHuong.TimSoCanhKhuyen(Matran);
			Console.WriteLine($"So canh khuyen la:{SoCanhKhuyen}");

			BacCoHuong[] MangBac;
			int[] TongBacVaoRa = XuLyCoHuong.ChuoiBacVaoBacRa(out MangBac, Matran);
			int SoDinhTreo = 0;
			int SoDinhCoLap = 0;
			for (int i = 0; i < TongBacVaoRa.Length; i++)
			{
				if (TongBacVaoRa[i] == 0)
				{
					SoDinhCoLap++;
				}
				else if (TongBacVaoRa[i] == 1)
				{
					SoDinhTreo++;
				}
			}
			Console.WriteLine($"Do thi co {SoDinhTreo} dinh treo");
			Console.WriteLine($"Do thi co {SoDinhCoLap} dinh co lap");
			Console.WriteLine("Bac ra - Bac vao cua tung dinh");
			for (int i = 0; i < TongBacVaoRa.Length; i++)
			{
				Console.WriteLine($"{i}({MangBac[i].BacVao},{MangBac[i].BacRa})");
			}
		}
	}
}

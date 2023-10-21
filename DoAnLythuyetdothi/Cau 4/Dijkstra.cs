using DoAnLythuyetdothi.Cau_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau_4
{

    public class DoThi
    {
        public int n;
        public int[,] data;
        XuLy xuLy;

        //Constructors
        public DoThi()
        {
            this.xuLy = new XuLy();
        }


        //YÊU CẦU 1: PHÂN TÍCH THÔNG TIN ĐỒ THỊ____________________________________________________________________
        //a. (0.25đ) Ma trận kề của đồ thị
        public bool TaoMaTranKe(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("This file does not exist.");
                return false;
            }

            string[] lines = File.ReadAllLines(filename);

            //Số đỉnh của đồ thị, nằm ở dòng đầu tiên của file input.txt
            n = Int32.Parse(lines[0]);

            //Ma trận kề có n dòng, n cột
            data = new int[n, n];

            //Duyệt từng dòng của input và tạo từng dòng cho ma trận kề
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);    //tokens = {"2", "1", "5", "3", "40"}

                //Chuyển đổi mảng string của dòng thành mảng int
                int[] intTokens = new int[tokens.Length];
                for (int k = 0; k < intTokens.Length; k++)
                {
                    intTokens[k] = int.Parse(tokens[k]);                                                            //intTokens = {2, 1, 5, 3, 40}
                }

                //Tạo dòng cho ma trận kề
                if (intTokens[0] != 0)
                {
                    for (int j = 0; j < intTokens[0]; j++)
                    {
                        data[i, intTokens[2 * j + 1]] = intTokens[2 * j + 2];                                       //data[1,j] = {0, 5, 0, 10}
                    }
                }
            }
            return true;
        }
        public void XuatMaTranKe()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(data[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        //b. (0.25đ) Xác định tính có hướng của đồ thị: đây là đồ thị có hướng hay đồ thị vô hướng
        //c. (0.25đ) Số đỉnh của đồ thị(kể cả đỉnh đặc biệt)
        //d. (0.25đ) Số cạnh của đồ thị(kể cả cạnh đặc biệt)
        //e. (0.25đ) Số lượng cặp đỉnh xuất hiện cạnh bội, số cạnh khuyên
        //f. (0.25đ) Số đỉnh treo, số đỉnh cô lập
        //g. (0.5đ) Xác định bậc(nếu là đồ thị vô hướng) hoặc bậc vào – bậc ra(nếu là đồ thị có hướng) của từng đỉnh trong đồ thị

        //YÊU CẦU 4: TÌM ĐƯỜNG ĐI NGẮN NHẤT____________________________________________________________________
        public bool DoThiCoTrongSoDuong()
        {
            bool kiemTra = true;
            foreach (int i in data)
            {
                if (i < 0)
                {
                    kiemTra = false;
                    break;
                }
            }
            return kiemTra;
        }

        //a. (1đ) Nếu đó là đồ thị có trọng số dương, tìm đường đi ngắn nhất từ source đến các đỉnh còn lại bằng giải thuật Dijkstra.Ngược lại, dừng.
        public void DuongDiNganNhatDijkstra(int diemBatDau, int diemKetThuc)
        {
            //Tập các đỉnh chưa xét T
            int[] T = new int[n];
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = i;                       //T = {0, 1, 2, 3}
            }

            //Mảng độ dài đường đi L
            int[] L = new int[n];
            for (int i = 0; i < L.Length; i++)
            {
                L[i] = int.MaxValue;
            }
            L[diemBatDau] = 0;                  //L = {0, +inf, +inf, +inf}

            //Mảng đánh dấu đỉnh liền trước
            int[] prev = new int[n];
            for (int i = 0; i < L.Length; i++)
            {
                prev[i] = -1;
            }
            prev[diemBatDau] = int.MinValue;       //prev = {-inf, -1, -1, -1}



            //Duyệt đồ thị
            while (T.Contains(diemKetThuc))
            {
                //Console.Write("T = ");
                //xuLy.InMang(T);

                //Console.Write("L = ");
                //xuLy.InMang(L);

                //Console.Write("prev = ");
                //xuLy.InMang(prev);

                int chiPhiNhoNhat = int.MaxValue;
                int viTriNhoNhat = int.MaxValue;

                //Bước 3: Chọn đỉnh i trong T sao cho L[i] nhỏ nhất
                for (int i = 0; i < T.Length; ++i)
                {
                    if (L[T[i]] < chiPhiNhoNhat)
                    {
                        chiPhiNhoNhat = L[T[i]];
                        viTriNhoNhat = T[i];
                    }
                }

                T = xuLy.XoaPhanTuTrongMang(viTriNhoNhat, T);   //T = {1, 2, 3}

                //Bước 4
                for (int k = 0; k < T.Length; k++)
                {
                    if (this.CoCanhNoi(viTriNhoNhat, T[k]) && L[T[k]] > L[viTriNhoNhat] + data[viTriNhoNhat, T[k]])
                    {
                        L[T[k]] = L[viTriNhoNhat] + data[viTriNhoNhat, T[k]];
                        prev[T[k]] = viTriNhoNhat;
                    }
                }
            }

            //Dựa vào prev tính xuất ra kết quả đường đi và chi phí
            Console.WriteLine($"Duong di ngan nhat den {diemKetThuc}:");
            int conTroQuayLui = diemKetThuc;
            string chuoi = "";
            while (conTroQuayLui != int.MinValue)
            {
                chuoi += $"{conTroQuayLui} <- ";
                conTroQuayLui = prev[conTroQuayLui];
            }
            chuoi = chuoi.Remove(chuoi.Length - 4); //Xoá dấu mũi tên ở cuối
            Console.WriteLine($"Cost = {L[diemKetThuc]}  Path = {chuoi}");
        }
        public void DuongDiNganNhatDijkstraToiTatCaCacDinh(int diemBatDau)
        {
            Console.WriteLine($"Source: {diemBatDau}");
            for (int i = 0; i < n; i++)
            {
                DuongDiNganNhatBellman(diemBatDau, i);
            }
        }
        //b. (1đ) Tìm đường đi ngắn nhất từ source đến các đỉnh còn lại bằng giải thuật Ford-Bellman. In ra màn hình kết quả tìm đường đi ngắn nhất theo quy cách tương tự như ở câu a.
        public void DuongDiNganNhatBellman(int diemBatDau, int diemKetThuc)
        {
            //Tập tất cả các đỉnh V
            int[] V = new int[n];
            for (int i = 0; i < V.Length; i++)
            {
                V[i] = i;                               //V = {0, 1, 2, 3}
            }

            //Tập chi phí đến các đỉnh V
            int[] pi = new int[n];
            for (int i = 0; i < pi.Length; i++)
            {
                pi[i] = int.MaxValue;
            }
            pi[diemBatDau] = 0;                         //pi = {0, +inf, +inf, +inf}

            int k = 0;

            //Mảng đánh dấu đỉnh liền trước
            int[] prev = new int[n];
            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = V[i];                         //prev = {0, 1, 2, 3}
            }

            //Duyệt đồ thị
            while (k < n)
            {
                //Console.Write("pi = ");
                //xuLy.InMang(pi);
                //Console.Write("prev = ");
                //xuLy.InMang(prev);
                //Console.Write("\n");

                for (int i = 0; i < V.Length; i++)  //i=0
                {
                    for (int j = 0; j < V.Length; j++)  //j=1
                    {
                        if (CoCanhNoi(j, i) && i != j)
                        {
                            int a = pi[i];
                            int b = pi[j] + data[j, i];
                            pi[i] = Math.Min(a, b);
                            if (pi[i] == b)
                            {
                                prev[i] = j;
                            }
                        }
                    }
                }
                k++;
            }
            //Dựa vào prev tính xuất ra kết quả đường đi và chi phí
            Console.WriteLine($"Duong di ngan nhat den {diemKetThuc}:");
            int conTroQuayLui = diemKetThuc;
            string chuoi = "";
            while (conTroQuayLui != diemBatDau)
            {
                chuoi += $"{conTroQuayLui} <- ";
                conTroQuayLui = prev[conTroQuayLui];
            }
            chuoi += diemBatDau;
            Console.WriteLine($"Cost = {pi[diemKetThuc]}  Path = {chuoi}");
        }
        public void DuongDiNganNhatBellmanToiTatCaCacDinh(int diemBatDau)
        {
            Console.WriteLine($"Source: {diemBatDau}");
            for (int i = 0; i < n; i++)
            {
                DuongDiNganNhatBellman(diemBatDau, i);
                //if (i!=diemBatDau)
                //{

                //}
            }
        }
        //Xy ly
        private bool CoCanhNoi(int dinh1, int dinh2)
        {
            if (data[dinh1, dinh2] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Prim()
        {
            List<int> Y = new List<int>();
            Y.Add(0);
            List<int>V= new List<int>();
			for (int i = 0; i < this.data.GetLength(0); i++)
			{
                bool flag= false;
                for(int j = 0; j < Y.Count; j++)
                {
                    if (i == Y[j])
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    V.Add(i);
                }
			}
			List<Et> Et1 = new List<Et>();
            
            while (Et1.Count < this.data.GetLength(0) - 1)
            {
                for(int i=0;i<Y.Count;i++)
                {
                    List<Et>EtTemp= new List<Et>();
                    for(int j = 0; j < V.Count; j++)
                    {
                        if (CoCanhNoi(Y[i], V[j]))
                        {
                            Et Dinh= new Et();
                            Dinh.DinhDau = Y[i];
                            Dinh.DinhCuoi= V[j];
                            Dinh.DoDai = data[Y[i], V[j]];
                            EtTemp.Add(Dinh);
                        }
                    }
					int Min = int.MaxValue;
					foreach (var s in EtTemp)
                    {
                        
                        if (s.DoDai < Min)
                        {
                            Min = s.DoDai;
                        }
                    }
                    foreach(var s in EtTemp)
                    {
						if (s.DoDai == Min)
						{
							Et1.Add(s);
                            Y.Add(s.DinhCuoi);
                            V.Remove(s.DinhCuoi);
						}
					}
                }
            }

            foreach(var e in Et1)
            {
                Console.WriteLine($"{e.DinhDau}---{e.DinhCuoi}: {e.DoDai}");
            }
        }
        //      public void Kruskal()
        //      {
        //          List<Et> ListCanh= new List<Et>();
        //          for(int i = 0; i < data.GetLength(0); i++)
        //          {
        //              for(int j = 0; j < data.GetLength(1); j++)
        //              {
        //                  if (data[i,j] != 0)
        //                  {
        //                      Et canh= new Et();
        //                      canh.DinhDau = i;
        //                      canh.DinhCuoi = j;
        //                      canh.DoDai = data[i,j];
        //                      ListCanh.Add(canh);
        //                  }
        //              }
        //          }

        //          for(int i=0;i<ListCanh.Count-1;i++)
        //          {
        //              for(int j=1;j<ListCanh.Count;j++)
        //              {
        //                  if (ListCanh[i].DoDai > ListCanh[j].DoDai)
        //                  {
        //                      Et Temp= new Et();
        //                      Temp = ListCanh[i];
        //                      ListCanh[i] = ListCanh[j];
        //                      ListCanh[j] = Temp;
        //                  }
        //              }
        //          }
        //          List<Et> result= new List<Et>();
        //          for(int i = 0; i < ListCanh.Count; i++)
        //          {
        //              if (ChuaTaoChuTrinh(result, ListCanh[i]))
        //              {
        //                  result.Add(ListCanh[i]);
        //              }
        //              if (result.Count == data.GetLength(0) - 1)
        //              {
        //                  break;
        //              }
        //          }
        //	foreach (var e in result)
        //	{
        //		Console.WriteLine($"{e.DinhDau}---{e.DinhCuoi}: {e.DoDai}");
        //	}

        //}
        public void Kruskal1()
        {
            int SoCanh = 0;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] != 0)
                    {
                        SoCanh++;
                    }
                }
            }
            Et[] MangBanDau = new Et[SoCanh];
            int MangBanDauIndex = 0;
			for (int i = 0; i < data.GetLength(0); i++)
			{
				for (int j = 0; j < data.GetLength(1); j++)
				{
					if (data[i, j] != 0)
					{
						Et temp= new Et();
                        temp.DinhDau = i;
                        temp.DinhCuoi = j;
                        temp.DoDai = data[i, j];
                        MangBanDau[MangBanDauIndex] = temp;
                        MangBanDauIndex++;
					}
				}
			}
            for(int i = 0; i < MangBanDau.Length - 1; i++)
            {
                for(int j = i+1; j < MangBanDau.Length; j++)
                {
                    if (MangBanDau[i].DoDai > MangBanDau[j].DoDai)
                    {
                        Et temp= new Et();
                        temp = MangBanDau[i];
                        MangBanDau[i] = MangBanDau[j];
                        MangBanDau[j]= temp;
                    }
                }
            }
            int kkk= data.GetLength(0)-1;
			List<Et> result = new List<Et>();
            for (int i = 0; i < MangBanDau.Length; i++)
            {
                if (ChuaTaoChuTrinh(result, MangBanDau[i]))
                {
                    result.Add(MangBanDau[i]);
                }
                if (result.Count == data.GetLength(0) - 1)
                {
                    break;
                }
            }
            foreach (var e in result)
            {
                Console.WriteLine($"{e.DinhDau}---{e.DinhCuoi}: {e.DoDai}");
            }
        }
		public bool ChuaTaoChuTrinh(List<Et> result, Et DinhMoiThem)
        {
            if (result.Count == 0)
            {
                return true;
            }
            List<int> CacDinh = new List<int>();
            foreach(var temp in result)
            {
                CacDinh.Add(temp.DinhDau);
                CacDinh.Add(temp.DinhCuoi);
            }
            bool ketqua = true;
            foreach(var Dinh in CacDinh)
            {
                int TrunngDInh = 0;
                if (DinhMoiThem.DinhDau == Dinh)
                {
                    TrunngDInh++;
                }
                if (DinhMoiThem.DinhCuoi == Dinh)
                {
					TrunngDInh++;
				}
                if (TrunngDInh==2)
                {
                    ketqua = false;
                }
                
            }
            return ketqua;
        }

    }
}

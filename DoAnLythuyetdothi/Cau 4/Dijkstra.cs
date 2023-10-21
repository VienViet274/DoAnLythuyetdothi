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
                Console.Write("Duong di ngan nhat: ");
                int conTroQuayLui = diemKetThuc;
                while (conTroQuayLui != int.MinValue)
                {
                    Console.Write($"{conTroQuayLui} <- ");
                    conTroQuayLui = prev[conTroQuayLui];
                }
                Console.WriteLine();
                Console.WriteLine($"Chi phi duong di ngan nhat: {L[diemKetThuc]}");
            }

            //b. (1đ) Tìm đường đi ngắn nhất từ source đến các đỉnh còn lại bằng giải thuật Ford-Bellman. In ra màn hình kết quả tìm đường đi ngắn nhất theo quy cách tương tự như ở câu a.

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
        }
    
}

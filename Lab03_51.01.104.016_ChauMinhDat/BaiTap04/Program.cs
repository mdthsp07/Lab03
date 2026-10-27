using System;

namespace Baitap04 //Lớp Đa Thức
{
    class DaThuc
    {
        private int bac;
        private double[] heSo;

        public int Bac { get { return bac; } }

        // Hàm khởi tạo đa thức bậc n với các hệ số = 0
        public DaThuc(int n)
        {
            bac = n;
            heSo = new double[n + 1];
        }

        // Indexer để lấy và gán hệ số a_k
        public double this[int k]
        {
            get
            {
                if (k >= 0 && k <= bac) return heSo[k];
                throw new IndexOutOfRangeException("Chi so vuot qua bac cua da thuc.");
            }
            set
            {
                if (k >= 0 && k <= bac) heSo[k] = value;
                else throw new IndexOutOfRangeException("Chi so vuot qua bac cua da thuc.");
            }
        }

        // Phép cộng 2 đa thức
        public static DaThuc operator +(DaThuc a, DaThuc b)
        {
            int maxBac = Math.Max(a.bac, b.bac);
            DaThuc ketQua = new DaThuc(maxBac);

            for (int i = 0; i <= maxBac; i++)
            {
                double hsA = (i <= a.bac) ? a[i] : 0;
                double hsB = (i <= b.bac) ? b[i] : 0;
                ketQua[i] = hsA + hsB;
            }
            return ketQua;
        }

        // Phép trừ 2 đa thức
        public static DaThuc operator -(DaThuc a, DaThuc b)
        {
            int maxBac = Math.Max(a.bac, b.bac);
            DaThuc ketQua = new DaThuc(maxBac);

            for (int i = 0; i <= maxBac; i++)
            {
                double hsA = (i <= a.bac) ? a[i] : 0;
                double hsB = (i <= b.bac) ? b[i] : 0;
                ketQua[i] = hsA - hsB;
            }
            return ketQua;
        }

        // Tính giá trị đa thức khi x = b
        public double TinhGiaTri(double b)
        {
            double ketQua = 0;
            for (int i = 0; i <= bac; i++)
            {
                ketQua += heSo[i] * Math.Pow(b, i);
            }
            return ketQua;
        }

        public override string ToString()
        {
            string chuoi = "";
            for (int i = bac; i >= 0; i--)
            {
                if (heSo[i] != 0)
                {
                    if (chuoi != "" && heSo[i] > 0) chuoi += " + ";
                    else if (heSo[i] < 0) chuoi += " - ";

                    double triTuyetDoi = Math.Abs(heSo[i]);
                    if (i == 0) chuoi += triTuyetDoi;
                    else if (i == 1) chuoi += (triTuyetDoi == 1 ? "" : triTuyetDoi.ToString()) + "x";
                    else chuoi += (triTuyetDoi == 1 ? "" : triTuyetDoi.ToString()) + "x^" + i;
                }
            }
            return chuoi == "" ? "0" : chuoi;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Đa thức P = 2x^2 + 3x + 1
            DaThuc p1 = new DaThuc(2);
            p1[0] = 1; p1[1] = 3; p1[2] = 2;

            // Đa thức Q = x^3 - 2x + 5
            DaThuc p2 = new DaThuc(3);
            p2[0] = 5; p2[1] = -2; p2[2] = 0; p2[3] = 1;

            Console.WriteLine("Da thuc P: " + p1.ToString());
            Console.WriteLine("Da thuc Q: " + p2.ToString());

            DaThuc tong = p1 + p2;
            Console.WriteLine("\nTong P + Q: " + tong.ToString());

            DaThuc hieu = p1 - p2;
            Console.WriteLine("Hieu P - Q: " + hieu.ToString());

            Console.WriteLine("\nGia tri P khi x = 2 la: " + p1.TinhGiaTri(2));

            Console.ReadKey();
        }
    }
}
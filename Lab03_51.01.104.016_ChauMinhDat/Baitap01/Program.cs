using System;

namespace Baitap01 // Lớp Điểm và Đường tròn
{
    class Diem
    {
        private int x;
        private int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public Diem() { x = 0; y = 0; }
        public Diem(int _x, int _y) { x = _x; y = _y; }
        public Diem(Diem p) { X = p.X; Y = p.Y; }

        public double KhoangCach(Diem b)
        {
            return Math.Sqrt(Math.Pow(this.X - b.X, 2) + Math.Pow(this.Y - b.Y, 2));
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    class DuongTron
    {
        private Diem tam;
        private int banKinh;

        public Diem Tam { get { return tam; } set { tam = value; } }
        public int BanKinh { get { return banKinh; } set { banKinh = value; } }

        public DuongTron() { tam = new Diem(); banKinh = 0; }
        public DuongTron(Diem t, int r) { Tam = t; BanKinh = r; }
        public DuongTron(DuongTron dt) { Tam = dt.Tam; BanKinh = dt.BanKinh; }

        public double TinhChuVi() { return 2 * Math.PI * BanKinh; }
        public double TinhDienTich() { return Math.PI * BanKinh * BanKinh; }

        public void Xuat()
        {
            Console.WriteLine("Tam: " + tam.ToString() + ", Ban kinh: " + banKinh);
        }

        // Kiểm tra tương đối giữa 2 đường tròn
        public void KiemTraTuongDoi(DuongTron dt2)
        {
            double khoangCachTam = this.Tam.KhoangCach(dt2.Tam);
            double tongBanKinh = this.BanKinh + dt2.BanKinh;
            double hieuBanKinh = Math.Abs(this.BanKinh - dt2.BanKinh);

            if (khoangCachTam > tongBanKinh) Console.WriteLine("Hai duong tron roi nhau.");
            else if (khoangCachTam == tongBanKinh) Console.WriteLine("Hai duong tron tiep xuc ngoai.");
            else if (khoangCachTam < hieuBanKinh) Console.WriteLine("Duong tron nho nam trong duong tron lon.");
            else if (khoangCachTam == hieuBanKinh) Console.WriteLine("Hai duong tron tiep xuc trong.");
            else Console.WriteLine("Hai duong tron cat nhau.");
        }

        // Kiểm tra điểm so với đường tròn
        public void KiemTraDiem(Diem p)
        {
            double kc = Tam.KhoangCach(p);
            if (kc > BanKinh) Console.WriteLine("Diem nam ngoai duong tron.");
            else if (kc < BanKinh) Console.WriteLine("Diem nam trong duong tron.");
            else Console.WriteLine("Diem nam tren duong tron.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Diem p1 = new Diem(1, 3);
            DuongTron dt1 = new DuongTron(p1, 5);
            DuongTron dt2 = new DuongTron(new Diem(4, 7), 3);

            Console.WriteLine("--- DUONG TRON 1 ---");
            dt1.Xuat();
            Console.WriteLine("Chu vi: " + dt1.TinhChuVi());
            Console.WriteLine("Dien tich: " + dt1.TinhDienTich());

            Console.WriteLine("\n--- DUONG TRON 2 ---");
            dt2.Xuat();

            Console.WriteLine("\n--- KIEM TRA TUONG DOI ---");
            dt1.KiemTraTuongDoi(dt2);

            Console.WriteLine("\n--- KIEM TRA DIEM (2, 2) VOI DT1 ---");
            dt1.KiemTraDiem(new Diem(2, 2));

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace Baitap02 // Quản lý Hình học (Kế thừa + Đọc/Ghi File)
{
    public class HinhHoc
    {
        public double DienTich { get; set; }
        public double ChuVi { get; set; }
        public virtual void TinhDienTichChuVi() { }
        public override string ToString()
        {
            return string.Format("S = {0:0.00}; P = {1:0.00}.", DienTich, ChuVi);
        }
    }

    public class HinhChuNhat : HinhHoc
    {
        private double mChieuDai, mChieuRong;
        public double ChieuDai
        {
            get { return mChieuDai; }
            set { if (value > 0) mChieuDai = value; else throw new Exception("Chieu dai am"); }
        }
        public double ChieuRong
        {
            get { return mChieuRong; }
            set { if (value > 0) mChieuRong = value; else throw new Exception("Chieu rong am"); }
        }

        public HinhChuNhat(double d, double r) { ChieuDai = d; ChieuRong = r; }

        public override void TinhDienTichChuVi()
        {
            DienTich = ChieuDai * ChieuRong;
            ChuVi = (ChieuDai + ChieuRong) * 2;
        }

        public override string ToString()
        {
            return string.Format("L = {0}, W = {1}; {2}", ChieuDai, ChieuRong, base.ToString());
        }
    }

    public class HinhTron : HinhHoc
    {
        private double mBanKinh;
        public double BanKinh
        {
            get { return mBanKinh; }
            set { if (value > 0) mBanKinh = value; else throw new Exception("Ban kinh am"); }
        }

        public HinhTron(double r) { BanKinh = r; }

        public override void TinhDienTichChuVi()
        {
            DienTich = Math.PI * BanKinh * BanKinh;
            ChuVi = 2 * Math.PI * BanKinh;
        }

        public override string ToString()
        {
            return string.Format("R = {0}; {1}", BanKinh, base.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo dữ liệu mẫu từ đề bài vào file input.txt
            string inputPath = "input.txt";
            File.WriteAllText(inputPath, "1\t5.3\t3.2\n2\t9.1\n1\t11\t2\n2\t1\n1\t2\t12.9\n10\t2\t4.5\n2\t3.4\n1\t77\t55");

            List<HinhHoc> danhSach = new List<HinhHoc>();
            string[] lines = File.ReadAllLines(inputPath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('\t');
                if (parts[0] == "1") // HCN
                {
                    danhSach.Add(new HinhChuNhat(double.Parse(parts[1]), double.Parse(parts[2])));
                }
                else if (parts[0] == "2") // HT
                {
                    danhSach.Add(new HinhTron(double.Parse(parts[1])));
                }
            }

            double tongDienTich = 0;
            double tongChuVi = 0;
            HinhChuNhat maxHCN = null;
            HinhTron minHT = null;

            foreach (var h in danhSach)
            {
                h.TinhDienTichChuVi();
                tongDienTich += h.DienTich;
                tongChuVi += h.ChuVi;

                if (h is HinhChuNhat hcn)
                {
                    if (maxHCN == null || hcn.DienTich > maxHCN.DienTich) maxHCN = hcn;
                }
                else if (h is HinhTron ht)
                {
                    if (minHT == null || ht.ChuVi < minHT.ChuVi) minHT = ht;
                }
            }

            // Xuất ra file output.txt
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("So hinh: " + danhSach.Count);
                sw.WriteLine("Tong dien tich: " + tongDienTich.ToString("0.00"));
                sw.WriteLine("Tong chu vi: " + tongChuVi.ToString("0.00"));
                sw.WriteLine("Hinh chu nhat co dien tich lon nhat: " + (maxHCN != null ? maxHCN.ToString() : "Khong co"));
                sw.WriteLine("Hinh tron co chu vi nho nhat: " + (minHT != null ? minHT.ToString() : "Khong co"));
            }

            Console.WriteLine("Da xu ly xong! Kiem tra file output.txt trong thu muc bin/Debug.");
            Console.ReadKey();
        }
    }
}
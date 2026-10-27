using System;

namespace Baitap03 //Quản lý Nhân viên
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }

        public Nguoi() { }
        public Nguoi(string ten, DateTime ns, string dc)
        {
            HoTen = ten; NgaySinh = ns; DiaChi = dc;
        }

        public int LayTuoi
        {
            get { return DateTime.Now.Year - NgaySinh.Year; }
        }

        public virtual void XemThongTin()
        {
            Console.WriteLine("Ho ten: {0}, Ngay sinh: {1:dd/MM/yyyy}, Dia chi: {2}, Tuoi: {3}", HoTen, NgaySinh, DiaChi, LayTuoi);
        }
    }

    class SinhVien : Nguoi
    {
        public string MaSV { get; set; }
        public string MaLop { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }

        public SinhVien() : base() { }
        public SinhVien(string ten, DateTime ns, string dc, string msv, string lop, string email, string sdt)
            : base(ten, ns, dc)
        {
            MaSV = msv; MaLop = lop; Email = email; DienThoai = sdt;
        }

        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine(" -> SV: MaSV: {0}, Lop: {1}, Email: {2}, SDT: {3}", MaSV, MaLop, Email, DienThoai);
        }
    }

    class NhanVien : Nguoi
    {
        public string MaNhanVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public DateTime NgayLamViec { get; set; }
        public string MaCongTy { get; set; }

        public NhanVien() : base() { }
        public NhanVien(string ten, DateTime ns, string dc, string mnv, string email, string sdt, DateTime nlv, string mct)
            : base(ten, ns, dc)
        {
            MaNhanVien = mnv; Email = email; DienThoai = sdt; NgayLamViec = nlv; MaCongTy = mct;
        }

        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine(" -> NV: MaNV: {0}, Cong ty: {1}, Ngay vao lam: {2:dd/MM/yyyy}", MaNhanVien, MaCongTy, NgayLamViec);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SinhVien sv = new SinhVien("Chau Minh Dat", new DateTime(2003, 5, 20), "HCM", "SV01", "51.01.104", "dat@email.com", "0123456789");
            NhanVien nv = new NhanVien("Nguyen Van A", new DateTime(1990, 1, 1), "Ha Noi", "NV01", "a@email.com", "0987654321", new DateTime(2015, 10, 10), "Cong ty ABC");

            Console.WriteLine("--- THONG TIN SINH VIEN ---");
            sv.XemThongTin();

            Console.WriteLine("\n--- THONG TIN NHAN VIEN ---");
            nv.XemThongTin();

            Console.ReadKey();
        }
    }
}